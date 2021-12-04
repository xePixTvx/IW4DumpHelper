using System;
using System.Collections.Generic;
using System.IO;

namespace IW4DumpHelperWinForms
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


        //Check if string already exists in a list
        private static bool IsDuplicate(List<string> list, string text)
        {
            foreach (string str in list)
            {
                if (str == text)
                {
                    return true;
                }
            }
            return false;
        }
    
    
    }
}
