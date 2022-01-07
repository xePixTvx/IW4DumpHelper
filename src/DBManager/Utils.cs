using System;
using System.Collections.Generic;
using System.IO;

namespace DBManager
{
    public static class Utils
    {

        //Read file line by line and return lines as a List
        public static List<string> GetLinesFromFile(string file)
        {
            List<string> Lines = new List<string>();
            StreamReader Reader;
            try
            {
                using (Reader = new StreamReader(file))
                {
                    string CurrentLine;
                    while ((CurrentLine = Reader.ReadLine()) != null)
                    {
                        Lines.Add(CurrentLine);
                    }
                }
                Reader.Close();
                Reader.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return Lines;
        }

        //Remove Strings from a string object
        public static string RemoveFromString(string str, string[] n)
        {
            string line = str;
            for (int i = 0; i < n.Length; i++)
            {
                line = line.Replace(n[i], "");
            }
            return line;
        }

        //Convert String To Bool
        public static bool ConvertStringToBool(string input)
        {
            if(input == "true")
            {
                return true;
            }
            return false;
        }

        //Get ClientType by String
        public static ClientTypes GetClientTypeByString(string input)
        {
            switch(input)
            {
                case "SP":
                    return ClientTypes.SP;

                case "SO":
                    return ClientTypes.SO;

                case "MP":
                    return ClientTypes.MP;

                default:
                    return ClientTypes.UNKNOWN;
            }
        }

        //Check if string is in list
        public static bool IsStringInList(string input, List<string> list)
        {
            foreach(string str in list)
            {
                if(str == input)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
