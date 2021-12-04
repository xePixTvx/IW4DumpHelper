using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SQLite;

namespace IW4DumpHelperWinForms
{
    class DatabaseController
    {
        private SQLiteConnection DBConnection;

        public DatabaseController()
        {
            DBConnection = new SQLiteConnection(GetConnectionString());
        }

        //Get Connection String
        public string GetConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        //Open Connection to DB
        public void OpenConnection()
        {
            DBConnection.Open();
        }

        //Close Connection to DB
        public void CloseConnection()
        {
            DBConnection.Close();
        }

        public SQLiteConnection GetCurrentConnection()
        {
            return DBConnection;
        }


        //Get Map Infos from DB
        public List<Info.MapInfo> GetMapsFromDB()
        {
            List<Info.MapInfo> maps = new List<Info.MapInfo>();

            OpenConnection();

            SQLiteDataReader Reader;
            var cmd = DBConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM maps";

            Reader = cmd.ExecuteReader();

            //0 = id
            //1 = type
            while (Reader.Read())
            {
                maps.Add(new Info.MapInfo(Reader.GetString(1), Reader.GetString(0)));
            }

            CloseConnection();

            return maps;
        }



        //Get Weapon Infos from DB Table
        public List<Info.WeaponInfo> GetWeaponInfosFromDBTable(Info.MapInfo map)
        {
            List<Info.WeaponInfo> weapons = new List<Info.WeaponInfo>();

            OpenConnection();

            SQLiteDataReader Reader;
            var cmd = DBConnection.CreateCommand();

            if (map.TYPE == "MP")
            {
                cmd.CommandText = "SELECT * FROM weapons_multiplayer";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM weapons_" + map.ID;
            }

            Reader = cmd.ExecuteReader();


            //0 = id
            //1 = file path
            //2 = loc string
            //3 = weapon class
            while (Reader.Read())
            {
                weapons.Add(new Info.WeaponInfo(map, Reader.GetString(0), Reader.GetString(2), Reader.GetString(3)));
            }

            CloseConnection();


            return weapons;
        }

    }
}
