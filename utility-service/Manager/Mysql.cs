using System;
using MySql.Data.MySqlClient;

namespace utility_service.Manager
{
    public class Mysql
    {
        public MySqlConnection Connection = new MySqlConnection();
        public Configuration.Mysql config;


        public Mysql()
        {

        }
        public Mysql(Configuration.Mysql _config)
        {
            config = _config;
            Connection = config.ToMysqlConnection();
        }

        public void Close()
        {
            Connection.Close();
            Connection.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public MySqlDataReader ExecuteDataReader(string sql)
        {
            return new MySqlCommand(sql, Connection).ExecuteReader();
        }

        public void ExecuteNonQuery(string sql)
        {
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, Connection);
            cmd.ExecuteNonQuery();
        }
    }

}