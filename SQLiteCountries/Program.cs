﻿using System;
using System.Data.SQLite;

namespace SQLiteCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCountries();
        }

        private static void ReadCountries()
        {
            Database databaseObj = new Database();

            string query = "SELECT Country.countryName AS Country, Capital.capitalname As Capital FROM Capital JOIN Country ON Capital.countryID = Country.rowid";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObj.myConnection);
            databaseObj.OpenConnection();

            SQLiteDataReader data = myCommand.ExecuteReader();

            if(data.HasRows)
            {
                while(data.Read())
                {
                    Console.WriteLine($"Country: {data["Country"]}. Capital: {data["Capital"]}");

                }
            }

            databaseObj.CloseConnection();
        }
    }
}
