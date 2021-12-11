using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IW4DumpHelperWinForms.DEV
{
    class StringFileScanner
    {
        private ConsoleController CMD;
        private bool DEV_MSGS;

        public StringFileScanner(ConsoleController cmd, bool show_dev_msgs = false)
        {
            CMD = cmd;
            DEV_MSGS = show_dev_msgs;
        }

        public List<DevCombinedStringInfo> ScanStringFilesAndCombineLangs(string type = "MP")
        {
            //List with all CombinedInfoStrings
            List<DevCombinedStringInfo> CombinedInfoStrings = new List<DevCombinedStringInfo>();


            //List of all supported languages
            List<LANGUAGES> Languages = Enum.GetValues(typeof(LANGUAGES)).Cast<LANGUAGES>().ToList();

            //Dictionary of all StringInfos for all languages
            Dictionary<LANGUAGES, List<DevStringInfo>> StringInfos = new Dictionary<LANGUAGES, List<DevStringInfo>>();

            //Scan String Files
            foreach(LANGUAGES lang in Languages)
            {
                List<DevStringInfo> tmp_info_list = ScanStringFile(lang, (type != "MP" ? "SP" : "MP"));
                if (tmp_info_list != null)
                {
                    StringInfos.Add(lang, tmp_info_list);
                }
            }

            CMD.Println("");
            CMD.Println("");
            CMD.Println("---------------------- COMBINING STRING LANGUAGES ----------------------");

            int AddedReferenceCount = 0;
            int AddedLangStringCount = 0;

            //Loop through StringInfos Dictionary
            foreach (KeyValuePair<LANGUAGES,List<DevStringInfo>> Infos in StringInfos)
            {
                //Current Language
                LANGUAGES CurrentLanguage = Infos.Key;

                //Current List of Scanned Strings
                List<DevStringInfo> CurrentStrings = Infos.Value;

                //Loop through Current List
                foreach(DevStringInfo DevInfo in CurrentStrings)
                {
                    string CurrentReference = DevInfo.Reference;
                    string CurrentLangString = DevInfo.Lang_String;

                    //Check if Reference already exists
                    if(CombinedInfoStrings.Any(refer => refer.Reference == CurrentReference))
                    {
                        CombinedInfoStrings.Find(refer => refer.Reference == CurrentReference).SetLangString(CurrentLanguage, CurrentLangString);
                        if (DEV_MSGS)
                        {
                            CMD.Println("Added string for Reference: " + CurrentReference + " in Language: " + CurrentLanguage);
                        }
                        AddedLangStringCount++;
                    }
                    else
                    {
                        DevCombinedStringInfo tmp_infoString = new DevCombinedStringInfo();
                        tmp_infoString.SetReference(CurrentReference);
                        tmp_infoString.SetLangString(CurrentLanguage, CurrentLangString);
                        CombinedInfoStrings.Add(tmp_infoString);
                        if (DEV_MSGS)
                        {
                            CMD.Println("Created StringInfo with Reference: " + CurrentReference);
                            CMD.Println("Added string for Reference: " + CurrentReference + " in Language: " + CurrentLanguage);
                        }
                        AddedReferenceCount++;
                        AddedLangStringCount++;
                    }
                }
            }

            CMD.Println("References: " + AddedReferenceCount);
            CMD.Println("Language Strings: " + AddedLangStringCount);
            CMD.Println("DONE!");
            CMD.Println("------------------------------------------------------------------------");
            return CombinedInfoStrings;
        }


        //Reads a string file and returns a list with DevStringInfos(language, reference, string)
        public List<DevStringInfo> ScanStringFile(LANGUAGES lang, string type = "MP")
        {
            //Collect Strings
            List<DevStringInfo> StringInfos = new List<DevStringInfo>();

            //Use the right file path + name
            string fileName = (type == "MP") ? "iw4mp.str" : "iw4sp.str";
            string filePath = Path.Combine(Environment.CurrentDirectory, "dev", "raw", "localizedstrings", lang.ToString(), fileName);

            //return if the file doesnt exist
            if(!File.Exists(filePath))
            {
                CMD.Println("");
                CMD.Println("------------------------- String File Scan Infos -------------------------");
                CMD.Println("ERROR: File Not Found!");
                CMD.Println("Scanned File: " + filePath);
                CMD.Println("Language: " + lang.ToString());
                CMD.Println("Scanned Lines Total: NONE");
                CMD.Println("Reference Lines: NONE");
                CMD.Println("Language String Lines: NONE");
                CMD.Println("String Infos Loaded: NONE");
                CMD.Println("--------------------------------------------------------------------------");
                CMD.Println("");
                return null;
            }

            //General Line Count
            int LineCount = 0;

            //REFERENCE Line Count
            int ReferenceLineCount = 0;

            //LANG_LANGUAGENAMEHERE Line Count
            int StringLineCount = 0;

            //Reference + String Lines Lists for scanning
            List<string> ReferenceLines = new List<string>();
            List<string> StringLines = new List<string>();

            //Scan
            try
            {
                if (DEV_MSGS)
                {
                    CMD.Println("Scanning Stringfile: " + fileName + " --- LANG: " + lang.ToString());
                }

                //Read File
                using (StreamReader Reader = new StreamReader(filePath))
                {
                    //Current Line
                    string LineString;

                    //Read File line by line
                    while ((LineString = Reader.ReadLine()) != null)
                    {
                        //Skip empty + end lines
                        if((LineString == "") || (LineString == "ENDMARKER"))
                        {
                            continue;
                        }

                        if(LineString.StartsWith("REFERENCE"))
                        {
                            ReferenceLines.Add(LineString);
                            ReferenceLineCount++;
                        }
                        else if(LineString.StartsWith("LANG_"))
                        {
                            StringLines.Add(LineString);
                            StringLineCount++;
                        }

                        LineCount++;
                    }
                }
            }
            catch(Exception e)
            {
                CMD.Println(e.Message);
                return null;
            }

            //Convert to DevStringInfo
            for(int i = 0; i < ReferenceLines.Count; i++)
            {
                string CurrentReference = Utils.RemoveFromString(ReferenceLines[i], new string[] { " ", "REFERENCE" });
                string CurrentLangString = StringLines[i].Split('\"')[1];
                StringInfos.Add(new DevStringInfo(lang, CurrentReference, CurrentLangString));
                if (DEV_MSGS)
                {
                    CMD.Println("String Loaded: " + CurrentReference + " --- Language: " + lang.ToString());
                }
            }


            //Scan Infos
            CMD.Println("");
            CMD.Println("------------------------- String File Scan Infos -------------------------");
            CMD.Println("Scanned File: " + filePath);
            CMD.Println("Language: " + lang.ToString());
            CMD.Println("Scanned Lines Total: " + LineCount);
            CMD.Println("Reference Lines: " + ReferenceLineCount);
            CMD.Println("Language String Lines: " + StringLineCount);
            CMD.Println("String Infos Loaded: " + StringInfos.Count);
            CMD.Println("--------------------------------------------------------------------------");
            CMD.Println("");

            //Return Infos
            return StringInfos;

        }
    }
}
