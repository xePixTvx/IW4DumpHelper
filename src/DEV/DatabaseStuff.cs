using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace IW4DumpHelperWinForms.DEV
{
    class DatabaseStuff
    {
        private DatabaseController DB;
        private ConsoleController CSL;

        public DatabaseStuff(DatabaseController DbCtrl, ConsoleController cmd_ctrl)
        {
            DB = DbCtrl;
            CSL = cmd_ctrl;
        }


        //Get All Table Names
        public List<string> DEV_GetAllTableNames()
        {
            List<string> Names = new List<string>();

            DB.OpenConnection();

            SQLiteDataReader Reader;
            var cmd = DB.GetCurrentConnection().CreateCommand();
            cmd.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1";

            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Names.Add(Reader.GetString(0));
            }

            DB.CloseConnection();

            return Names;
        }

        //Get Table Item Count
        public int DEV_GetTableItemCount(string tableId)
        {
            int count = 0;

            DB.OpenConnection();

            SQLiteDataReader Reader;
            var cmd = DB.GetCurrentConnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM " + tableId;

            Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                count++;
            }

           DB.CloseConnection();


            return count;
        }

        //Delete All Tables
        public void DEV_ClearDataBase()
        {
            List<string> TableNames = DEV_GetAllTableNames();

            DB.OpenConnection();

            var DB_CMD = DB.GetCurrentConnection().CreateCommand();

            foreach (string table in TableNames)
            {
                //if (table != "maps") //--- keep table
                //{
                    DB_CMD.CommandText = "DROP TABLE IF EXISTS " + table;
                    DB_CMD.ExecuteNonQuery();
                //}
            }

            CSL.Println("DEV: Database Cleared!");
            DB.CloseConnection();
        }


        //Add Maps to the maps table
        public void DEV_AddMapsToMapsTable()
        {
            //Read Maps info file
            List<string> Maps = Utils.GetLinesFromFile(Path.Combine(Environment.CurrentDirectory, "dev", "infos", "maps.txt"));


            //Open Database connection
            DB.OpenConnection();


            //Create Database Command
            var DB_CMD = DB.GetCurrentConnection().CreateCommand();


            //Remove maps table if it already exists
            DB_CMD.CommandText = "DROP TABLE IF EXISTS maps";
            DB_CMD.ExecuteNonQuery();
            CSL.Println("DEV: maps table dropped!");


            //Create Table
            DB_CMD.CommandText = "CREATE TABLE maps" +
            "(\"MAP_ID\"                        TEXT    DEFAULT 'UNKNOWN_MAP_ID'," +
            "\"CLIENT_TYPE\"                    TEXT    DEFAULT 'UNKNOWN_CLIENT_TYPE'," +
            "\"HAS_ALTERNATE_RAWFILE_PATH\"     TEXT    DEFAULT 'UNKNOWN_HAS_ALT_PATH_BOOL'," +
            "\"ALTERNATE_RAWFILE_PATH\"         TEXT    DEFAULT 'UNKNOWN_ALTERNATE_RAWFILE_PATH')";
            DB_CMD.ExecuteNonQuery();
            CSL.Println("DEV: maps table added!");


            //Add to table cmd
            DB_CMD.CommandText = "INSERT INTO maps(MAP_ID,CLIENT_TYPE,HAS_ALTERNATE_RAWFILE_PATH,ALTERNATE_RAWFILE_PATH) VALUES(@ID,@IW4_CLIENT_TYPE,@HAS_ALT_PATH,@ALT_PATH)";


            //Get infos and add them to the table
            foreach(string line in Maps)
            {
                string[] infos = line.Split(';');

                string name = infos[0];
                string client_type = infos[1];
                string has_alt_path = infos[2];
                string alt_path = ((infos.Length-1) <= 2 ? "NOT USED" : infos[3]);


                DB_CMD.Parameters.AddWithValue("ID", name);
                DB_CMD.Parameters.AddWithValue("IW4_CLIENT_TYPE", client_type);
                DB_CMD.Parameters.AddWithValue("HAS_ALT_PATH", has_alt_path);
                DB_CMD.Parameters.AddWithValue("ALT_PATH", alt_path);
                DB_CMD.ExecuteNonQuery();
                DB_CMD.Parameters.Clear();

                CSL.Println("DEV: map " + name + " added to maps table!");
            }

            //Close Database connection
            DB.CloseConnection();

            CSL.Println("DEV: maps table Updated!");
        }


        //Add Weapon Tables for all Maps + Multiplayer
        public void DEV_AddWeaponsToDB()
        {
            int WeaponFileScanCount = 0;

            //Read Maps Info File
            List<string> Maps = Utils.GetLinesFromFile(Path.Combine(Environment.CurrentDirectory, "dev", "infos", "maps.txt"));

            //MP Maps
            List<string> MP_Maps = new List<string>();

            //Init Weapon File Scanner
            WeaponFileScanner WeaponScanner = new WeaponFileScanner();

            //Current WeaponInfo List(clear after every map cylce)
            List<DevWeaponInfo> CurrentWeaponInfoList = new List<DevWeaponInfo>();

            //Open Database connection
            DB.OpenConnection();

            //Create Database Command
            var DB_CMD = DB.GetCurrentConnection().CreateCommand();

            //Cycle through all maps
            foreach (string map in Maps)
            {
                //Get Map Infos
                string[] infos = map.Split(';');
                string name = infos[0];
                string mapClientType = infos[1];
                string has_alt_path = infos[2];
                string alt_path = ((infos.Length - 1) <= 2 ? "NOT USED" : infos[3]);

                //SP + SO Maps
                if (mapClientType != "MP")
                {
                    //Remove map weapon table if it already exists
                    DB_CMD.CommandText = "DROP TABLE IF EXISTS weapons_" + name;
                    DB_CMD.ExecuteNonQuery();

                    //Add map weapon table
                    DB_CMD.CommandText = "CREATE TABLE weapons_" + name +
                    "(\"WEAPON_ID\"         TEXT    DEFAULT 'UNKNOWN_WEAPON_ID'," +
                    "\"DEV_FILE_PATH\"      TEXT    DEFAULT 'UNKNOWN_FILE_PATH'," +
                    "\"LOCALIZED_STRING\"   TEXT    DEFAULT 'UNKNOWN_LOCALIZED_STRING'," +
                    "\"WEAPON_CLASS\"       TEXT    DEFAULT 'UNKNOWN_WEAPON_CLASS')";
                    DB_CMD.ExecuteNonQuery();

                    //Get weapon ids for current map
                    List<string> WeaponNames = Utils.GetLinesFromFile(Path.Combine(Environment.CurrentDirectory, "dev", "infos", "weapons", name + ".txt"));

                    //Scan & add all infos to CurrentWeaponInfoList
                    foreach (string wepName in WeaponNames)
                    {
                        if (has_alt_path == "true")
                        {
                            CurrentWeaponInfoList.Add(WeaponScanner.ScanWeaponFile(alt_path, wepName));
                        }
                        else
                        {
                            CurrentWeaponInfoList.Add(WeaponScanner.ScanWeaponFile(name, wepName));
                        }
                        WeaponFileScanCount++;
                    }

                    //Cycle through weapon infos & add them to the database
                    DB_CMD.CommandText = "INSERT INTO weapons_" + name + "(WEAPON_ID,DEV_FILE_PATH,LOCALIZED_STRING,WEAPON_CLASS) VALUES(@WEP_ID,@RAWFILE_PATH,@LOC_STRING,@WEP_CLASS)";
                    foreach (DevWeaponInfo info in CurrentWeaponInfoList)
                    {
                        DB_CMD.Parameters.AddWithValue("WEP_ID", info.Id);
                        DB_CMD.Parameters.AddWithValue("RAWFILE_PATH", info.RawfilePath);
                        DB_CMD.Parameters.AddWithValue("LOC_STRING", info.LocString);
                        DB_CMD.Parameters.AddWithValue("WEP_CLASS", info.WeaponClass);
                        DB_CMD.ExecuteNonQuery();
                        DB_CMD.Parameters.Clear();

                        CSL.Println("DEV: Weapon --- " + info.Id + " --- added for Map --- " + name);
                    }


                    //Clear CurrentWeaponInfoList
                    CurrentWeaponInfoList.Clear();
                }
                else
                {
                    MP_Maps.Add(map);
                }
            }

            //MP Maps
            if(MP_Maps.Count > 0)
            {
                //Remove weapon table if it already exists
                DB_CMD.CommandText = "DROP TABLE IF EXISTS weapons_multiplayer";
                DB_CMD.ExecuteNonQuery();

                //Add weapon table
                DB_CMD.CommandText = "CREATE TABLE weapons_multiplayer" +
                "(\"WEAPON_ID\"         TEXT    DEFAULT 'UNKNOWN_WEAPON_ID'," +
                "\"DEV_FILE_PATH\"      TEXT    DEFAULT 'UNKNOWN_FILE_PATH'," +
                "\"LOCALIZED_STRING\"   TEXT    DEFAULT 'UNKNOWN_LOCALIZED_STRING'," +
                "\"WEAPON_CLASS\"       TEXT    DEFAULT 'UNKNOWN_WEAPON_CLASS')";
                DB_CMD.ExecuteNonQuery();

                //Clear CurrentWeaponInfoList
                CurrentWeaponInfoList.Clear();

                //Add weapons to table
                List<string> WeaponNames = Utils.GetLinesFromFile(Path.Combine(Environment.CurrentDirectory, "dev", "infos", "weapons", "weapons_mp.txt"));

                //Scan Weapon Files
                foreach (string wepName in WeaponNames)
                {
                    CurrentWeaponInfoList.Add(WeaponScanner.ScanWeaponFile("mp", wepName));
                    WeaponFileScanCount++;
                }

                //Cycle through weapon infos & add them to the database
                DB_CMD.CommandText = "INSERT INTO weapons_multiplayer(WEAPON_ID,DEV_FILE_PATH,LOCALIZED_STRING,WEAPON_CLASS) VALUES(@WEP_ID,@RAWFILE_PATH,@LOC_STRING,@WEP_CLASS)";
                foreach (DevWeaponInfo info in CurrentWeaponInfoList)
                {
                    DB_CMD.Parameters.AddWithValue("WEP_ID", info.Id);
                    DB_CMD.Parameters.AddWithValue("RAWFILE_PATH", info.RawfilePath);
                    DB_CMD.Parameters.AddWithValue("LOC_STRING", info.LocString);
                    DB_CMD.Parameters.AddWithValue("WEP_CLASS", info.WeaponClass);
                    DB_CMD.ExecuteNonQuery();
                    DB_CMD.Parameters.Clear();

                    CSL.Println("DEV: Weapon --- " + info.Id + " --- added for Multiplayer ---");
                }

            }


            DB.CloseConnection();

            CSL.Println("DEV: " + WeaponFileScanCount + " weaponfiles scanned!");
            CSL.Println("DEV: All Weapons Updated!");
        }



        //Add Strings Tables
        public void DEV_AddStringTables()
        {
            //Init StringFile Scanner
            //StringFileScanner FileScanner = new StringFileScanner(CSL, false);

            //Open Database connection
            DB.OpenConnection();

            //Create Database Command
            var DB_CMD = DB.GetCurrentConnection().CreateCommand();

            //Remove string tables if they already exist
            DB_CMD.CommandText = "DROP TABLE IF EXISTS strings_sp";
            DB_CMD.ExecuteNonQuery();

            DB_CMD.CommandText = "DROP TABLE IF EXISTS strings_mp";
            DB_CMD.ExecuteNonQuery();

            //Add string tables
            //SP
            DB_CMD.CommandText = "CREATE TABLE strings_sp" +
            "(\"REFERENCE\"         TEXT    DEFAULT 'UNKNOWN_REFERENCE'," +
            "\"LANG_ENGLISH\"       TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_FRENCH\"        TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_GERMAN\"        TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_ITALIAN\"       TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_POLISH\"        TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_RUSSIAN\"       TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_SPANISH\"       TEXT    DEFAULT 'UNKNOWN_STRING')";
            DB_CMD.ExecuteNonQuery();

            //MP
            DB_CMD.CommandText = "CREATE TABLE strings_mp" +
            "(\"REFERENCE\"         TEXT    DEFAULT 'UNKNOWN_REFERENCE'," +
            "\"LANG_ENGLISH\"       TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_FRENCH\"        TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_GERMAN\"        TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_ITALIAN\"       TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_POLISH\"        TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_RUSSIAN\"       TEXT    DEFAULT 'UNKNOWN_STRING'," +
            "\"LANG_SPANISH\"       TEXT    DEFAULT 'UNKNOWN_STRING')";
            DB_CMD.ExecuteNonQuery();


            /*

            //Scan StringFiles SP
            List<DevStringInfo> StringInfos_sp_english = FileScanner.ScanStringFile(LANGUAGES.english, "SP");
            List<DevStringInfo> StringInfos_sp_french = FileScanner.ScanStringFile(LANGUAGES.french, "SP");
            List<DevStringInfo> StringInfos_sp_german = FileScanner.ScanStringFile(LANGUAGES.german, "SP");
            List<DevStringInfo> StringInfos_sp_italian = FileScanner.ScanStringFile(LANGUAGES.italian, "SP");
            List<DevStringInfo> StringInfos_sp_polish = FileScanner.ScanStringFile(LANGUAGES.polish, "SP");
            List<DevStringInfo> StringInfos_sp_russian = FileScanner.ScanStringFile(LANGUAGES.russian, "SP");
            List<DevStringInfo> StringInfos_sp_spanish = FileScanner.ScanStringFile(LANGUAGES.spanish, "SP");

            //Scan StringFiles MP
            List<DevStringInfo> StringInfos_mp_english = FileScanner.ScanStringFile(LANGUAGES.english, "MP");
            List<DevStringInfo> StringInfos_mp_french = FileScanner.ScanStringFile(LANGUAGES.french, "MP");
            List<DevStringInfo> StringInfos_mp_german = FileScanner.ScanStringFile(LANGUAGES.german, "MP");
            List<DevStringInfo> StringInfos_mp_italian = FileScanner.ScanStringFile(LANGUAGES.italian, "MP");
            List<DevStringInfo> StringInfos_mp_polish = FileScanner.ScanStringFile(LANGUAGES.polish, "MP");
            List<DevStringInfo> StringInfos_mp_russian = FileScanner.ScanStringFile(LANGUAGES.russian, "MP");
            List<DevStringInfo> StringInfos_mp_spanish = FileScanner.ScanStringFile(LANGUAGES.spanish, "MP");


            */







            //Close Database connection
            DB.CloseConnection();


            CSL.Println("TEST DONE!");
        }


    }
}
