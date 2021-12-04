using System;
using System.Collections.Generic;
using System.IO;

namespace IW4DumpHelperWinForms.DEV
{
    class WeaponFileScanner
    {
        public WeaponFileScanner()
        {
        }



        public DevWeaponInfo ScanWeaponFile(string mapId, string wepId)
        {
            string filePath = "";

            //Create Rawfile Path
            if(mapId == "mp")
            {
                filePath = Path.Combine("dev", "raw", "weapons", "mp", wepId);
            }
            else
            {
                filePath = Path.Combine("dev", "raw", "weapons", "sp", mapId, wepId);
            }
            
            //Check if rawfile exists
            if(!File.Exists(filePath))
            {
                if (mapId == "mp")
                {
                    return new DevWeaponInfo("MP", wepId, filePath, "SCAN ERROR(File Not Found!)", "SCAN ERROR(File Not Found!)");
                }
                return new DevWeaponInfo(mapId, wepId, filePath, "SCAN ERROR(File Not Found!)", "SCAN ERROR(File Not Found!)");
            }

            //Infos we want to have
            string info_loc_string = "UNKNOWN";
            string info_wep_class = "UNKNOWN";

            //Read Rawfile
            string infoFull = File.ReadAllText(filePath);

            //Get loc_string
            if (infoFull.Contains("displayName\\"))
            {
                info_loc_string = infoFull.Substring(infoFull.IndexOf("displayName\\")).Split('\\')[1];
                if (info_loc_string == "" || info_loc_string == null)
                {
                    info_loc_string = "SCAN ERROR(Localized String not found!)";
                }
            }

            //Get wep_class
            if (infoFull.Contains("weaponClass\\"))
            {
                info_wep_class = infoFull.Substring(infoFull.IndexOf("weaponClass\\")).Split('\\')[1];
                if (info_wep_class == "" || info_wep_class == null)
                {
                    info_wep_class = "SCAN ERROR(Weapon Class not found!)";
                }
            }

            //Create + Return Weapon Info
            if (mapId == "mp")
            {
                return new DevWeaponInfo("MP", wepId, filePath, info_loc_string, info_wep_class);
            }
            return new DevWeaponInfo(mapId, wepId, filePath, info_loc_string, info_wep_class);
        }



    }
}
