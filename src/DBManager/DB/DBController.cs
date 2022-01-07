using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using DBManager.Infos;

namespace DBManager.DB
{
    class DBController
    {
        private SQLiteConnection DBConnection;

        public DBController()
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

        //Get Current Connection
        public SQLiteConnection GetCurrentConnection()
        {
            return DBConnection;
        }



        //Get All Table Names
        public List<string> GetAllTableNames()
        {
            List<string> Names = new List<string>();

            OpenConnection();

            SQLiteDataReader Reader;
            var cmd = GetCurrentConnection().CreateCommand();
            cmd.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1";

            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Names.Add(Reader.GetString(0));
            }

            CloseConnection();

            return Names;
        }

        //Get Table Item Count
        public int GetTableItemCount(string tableId)
        {
            int count = 0;

            OpenConnection();

            SQLiteDataReader Reader;
            var cmd = GetCurrentConnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM " + tableId;

            Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                count++;
            }

            CloseConnection();


            return count;
        }


        //Delete a Table
        public void DeleteTable(string tableId)
        {
            OpenConnection();

            var DB_CMD = GetCurrentConnection().CreateCommand();

            DB_CMD.CommandText = "DROP TABLE IF EXISTS " + tableId;
            DB_CMD.ExecuteNonQuery();

            Console.WriteLine("Table " + tableId + " Cleared!");

            CloseConnection();
        }

        //Delete All Tables
        public void ClearDataBase()
        {
            List<string> TableNames = GetAllTableNames();

            OpenConnection();

            var DB_CMD = GetCurrentConnection().CreateCommand();

            foreach (string table in TableNames)
            {
                DB_CMD.CommandText = "DROP TABLE IF EXISTS " + table;
                DB_CMD.ExecuteNonQuery();
            }

            Console.WriteLine("Database Cleared!");
            CloseConnection();
        }


        #region Maps

        //Get Map Infos from DB
        public List<Infos.MapInfo> GetMapsFromDB()
        {
            //Check if maps table Exists
            if(!Utils.IsStringInList("maps",GetAllTableNames()))
            {
                return null;
            }

            List<Infos.MapInfo> maps = new List<Infos.MapInfo>();

            OpenConnection();

            SQLiteDataReader Reader;
            var cmd = GetCurrentConnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM maps";

            Reader = cmd.ExecuteReader();

            //0 = id
            //1 = type
            //2 = has alt path
            //3 = alt path
            while (Reader.Read())
            {
                maps.Add(new Infos.MapInfo(Reader.GetString(0), Utils.GetClientTypeByString(Reader.GetString(1)),Utils.ConvertStringToBool(Reader.GetString(2)), Reader.GetString(3)));
            }

            CloseConnection();

            return maps;
        }


        //Add Maps to Database
        public void UpdateMapsTable(List<MapInfo> Maps)
        {
            //Open Database Connection
            OpenConnection();

            //Create Database Command
            var cmd = GetCurrentConnection().CreateCommand();

            //Remove Table if it already exists
            cmd.CommandText = "DROP TABLE IF EXISTS maps";
            cmd.ExecuteNonQuery();

            //Create Table
            cmd.CommandText = "CREATE TABLE maps" +
            "(\"MAP_ID\"                        TEXT    DEFAULT 'UNKNOWN_MAP_ID'," +
            "\"CLIENT_TYPE\"                    TEXT    DEFAULT 'UNKNOWN_CLIENT_TYPE'," +
            "\"HAS_ALTERNATE_RAWFILE_PATH\"     TEXT    DEFAULT 'UNKNOWN_HAS_ALT_PATH_BOOL'," +
            "\"ALTERNATE_RAWFILE_PATH\"         TEXT    DEFAULT 'UNKNOWN_ALTERNATE_RAWFILE_PATH')";
            cmd.ExecuteNonQuery();

            //Change cmd to a 'Add to table' command
            cmd.CommandText = "INSERT INTO maps(MAP_ID,CLIENT_TYPE,HAS_ALTERNATE_RAWFILE_PATH,ALTERNATE_RAWFILE_PATH) VALUES(@ID,@IW4_CLIENT_TYPE,@HAS_ALT_PATH,@ALT_PATH)";

            //Loop through all the map infos and add them to the table
            foreach(MapInfo map in Maps)
            {
                cmd.Parameters.AddWithValue("ID", map.ID);
                cmd.Parameters.AddWithValue("IW4_CLIENT_TYPE", map.TYPE.ToString());
                cmd.Parameters.AddWithValue("HAS_ALT_PATH", map.HAS_ALT_PATH.ToString());
                cmd.Parameters.AddWithValue("ALT_PATH", map.ALT_PATH);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                Console.WriteLine("Map Added: " + map.ID);
            }

            //Close Database Connection
            CloseConnection();
        }

        #endregion Maps



    }
}
