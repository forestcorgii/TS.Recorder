using System;
using MySql.Data.MySqlClient;

namespace utility_service.Controller
{
    public class Settings
    {
        public static Model.Settings GetSettings(Manager.Mysql databaseManager, string settingsName, string databaseName = "")
        {
            Model.Settings settings = null;
            try
            {
                if (string.IsNullOrEmpty(databaseName))
                {
                    databaseName = databaseManager.Connection.Database;
                }

                if (string.IsNullOrEmpty(databaseName)) // if database name is still empty, throw an error
                {
                    throw new Exception("Database name is Required.");
                }

                using (var reader = databaseManager.ExecuteDataReader(string.Format("SELECT * FROM {0}.settings WHERE name='{1}';", databaseName, settingsName)))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        settings = new Model.Settings(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return settings;
        }

        public static void SaveSettings(Manager.Mysql databaseManager, Model.Settings settings, string databaseName = "")
        {
            try
            {
                if (string.IsNullOrEmpty(databaseName))
                {
                    databaseName = databaseManager.Connection.Database;
                }

                if (string.IsNullOrEmpty(databaseName)) // if database name is still empty, throw an error
                {
                    throw new Exception("Database name is Required.");
                }

                var command = new MySqlCommand(string.Format("REPLACE INTO {0}.settings(name,json_argument) VALUES(?,?);", databaseName), databaseManager.Connection);
                command.Parameters.AddWithValue("name", settings.Name);
                command.Parameters.AddWithValue("json_argument", settings.JSON_Arguments);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}