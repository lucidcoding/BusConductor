using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace BusConductor.UI.IntegrationTests.Helpers
{
    public static class ScriptRunner
    {
        public static void RunScript()
        {
            //todo: clean all this up.
            //var connectionString = ConfigurationManager.ConnectionStrings["BusConductor"].ConnectionString;
            var connectionString =
                @"Data Source=localhost\sql2008r2;Initial Catalog=BusConductor;Integrated Security=true;";
            var cn = new SqlConnection(connectionString);
            var assembly = Assembly.GetExecutingAssembly();

            var filePath = Environment.CurrentDirectory + "\\..\\..\\..\\SqlScripts\\";

            var file = new FileInfo(filePath + "00001_CreateDatabases.sql");

            string script = file.OpenText().ReadToEnd();

            var conn = new SqlConnection(connectionString);

            var server = new Server(new ServerConnection(conn));

            server.ConnectionContext.ExecuteNonQuery(script);


        }
    }
}
