using Microsoft.VisualBasic.CompilerServices;
using MySql.Data.MySqlClient;

namespace utility_service.Model
{
    public class Settings
    {
        public string Name;
        public string JSON_Arguments;

        public Settings()
        {

        }

        public Settings(MySqlDataReader reader)
        {
            Name = Conversions.ToString(reader["name"]);
            JSON_Arguments = Conversions.ToString(reader["json_argument"]);
        }
    }

}