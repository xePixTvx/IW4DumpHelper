using System;
using System.IO;
using System.Collections.Generic;
using DBManager.Infos;

namespace DBManager.DB.Scanning
{
    internal class MapScanner
    {
        public MapScanner()
        {
        }



        public List<MapInfo> ScanMaps()
        {
            //Map Info List
            List<MapInfo> Maps = new List<MapInfo>();

            //Read Maps Info File
            List<string> Map_Info_Lines = Utils.GetLinesFromFile(Path.Combine(Environment.CurrentDirectory, "data", "infos", "maps.txt"));

            int count = 0;

            //Loop through map info file lines
            foreach(string line in Map_Info_Lines)
            {
                //Get Infos from Current Line and add them to the MapInfo Maps List
                string[] infos = line.Split(';');
                string map_id = infos[0];
                string client_type = infos[1];
                string has_alt_path = infos[2];
                string alt_path = ((infos.Length - 1) <= 2 ? "NOT USED" : infos[3]);
                Maps.Add(new MapInfo(map_id, Utils.GetClientTypeByString(client_type), Utils.ConvertStringToBool(has_alt_path), alt_path));
                count++;
            }

            Console.WriteLine("Scanned: " + count + " Maps!");

            return Maps;
        }



    }
}
