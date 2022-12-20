using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MySql.Data.MySqlClient;

namespace utility_service.Configuration
{
    public class Mysql
    {
        public string user = "";
        public string password = "";
        public string host = "";
        public string port = "";

        public string name = "";

        public Mysql()
        {
        }

        public object Setup(string envVar)
        {
            return ParseEnvVar(Environment.GetEnvironmentVariable(envVar));
        }

        public object ParseEnvVar(string raw)
        {
            try
            {
                if (!string.IsNullOrEmpty(raw))
                {
                    var mysql_regex = new Regex(@"^([\w@]+):([\w@!]+)@([\w-.]+):([\d]+)\/([\w\-]+)?$");
                    var mysql_match = mysql_regex.Match(raw);
                    user = mysql_match.Groups[1].Value;
                    password = mysql_match.Groups[2].Value;
                    host = mysql_match.Groups[3].Value;
                    port = mysql_match.Groups[4].Value;
                    name = mysql_match.Groups[5].Value;
                }
                else
                {
                    throw new Exception(string.Format("Parsing Failed, please check {0}.", raw));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public object ConnectionString
        {
            get
            {
                return string.Format("Server={0};Uid={1};Pwd={2};port={3}{4};Convert Zero Datetime=True;command Timeout=20000;SslMode=None", host, user, password, port, Interaction.IIf(string.IsNullOrEmpty(name), "", ";database=" + name));
            }
        }

        public MySqlConnection ToMysqlConnection()
        {
            if (!string.IsNullOrEmpty(host))
            {
                return new MySqlConnection(Conversions.ToString(ConnectionString));
            }
            return null;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}@{2}:{3}/{4}", user, password, host, port, name);
        }
    }
}