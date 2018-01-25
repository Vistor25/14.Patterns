using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionStringBuilder connection = new ConnectionStringBuilder();
            connection.DataSource = "MyDB";
            connection.UserID = "sqlserver1";
            connection.Password = "123456789";
            connection.InitialCatalog = "server1";
            connection.ConnectTimeout = 45;
            Console.WriteLine(connection);
            CreateConnectioString cs = new CreateConnectioString();
            Console.WriteLine(cs.Create()
                .UseDB("MyDB")
                .UseCatalog("server1")
                .UseUser("sqlserver1")
                .WithPassword("123456789")
                .WithTimeout(30)
                .Build());
            Console.ReadKey();
        }
    }
}
