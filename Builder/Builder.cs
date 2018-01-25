using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class ConnectionStringBuilder
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public bool Encrypt { get; set; }
        public string UserID { get; set; }
        public  string Password { get; set; }
        public  int ConnectTimeout { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (DataSource != null)
            {
                sb.Append("Data Source=" + DataSource + ";");
            }
            if (InitialCatalog != null)
            {
                sb.Append("Initial Catalog=" + InitialCatalog + ";");
            }

            if (Encrypt)
            {
                sb.Append("Encrypt=" + Encrypt + ";");
            }
            if (UserID != null)
            {
                sb.Append("User ID=" + UserID + ";");
            }
            if (Password != null)
            {
                sb.Append("Password=" + Password + ";");
            }
            if (ConnectTimeout != 0)
            {
                sb.Append("Connect Timeout=" + ConnectTimeout + ";");
            }
            return sb.ToString();
        }
    }

    public class CreateConnectioString
    {
        public IUseDB Create()
        {
            return new InitialDB();
        }
    }

    public class InitialDB : IUseDB
    {
        public IUseCatalog UseDB(string db)
        {

            return new InitialCatalog("Data Source=" + db + ";");
        }
    }

   
    public class InitialCatalog : IUseCatalog
    {
        private string Value { get; set; }

        public InitialCatalog(string value)
        {
            this.Value = value;
        }

        public IUseUser UseCatalog(string val)
        {
            return new UserId(Value + "Initial Catalog=" + val + ";");
        }
    }

    public class UserId: IUseUser
    {
        private string Value { get; set; }

        public UserId(string value)
        {
            Value = value;
        }

        public IPassword UseUser(string name)
        {
            return new Password(Value+ "User ID=" + name + ";");
        }
    }

   

    public class Password: IPassword
    {
        private string Value { get; set; }

        public Password(string value)
        {
            Value = value;
        }

        public IConectionTimeout WithPassword(string password)
        {
            return  new ConnectionTimeout(Value + "Password=" + password + ";");
        }
    }

   
    public class ConnectionTimeout: IConectionTimeout
    {
        private string Value { get; set; }

        public ConnectionTimeout(string value)
        {
            Value = value;
        }

        public IBuild WithTimeout(int timeout)
        {
            return new BuildConnection(Value+ "Connect Timeout=" + timeout + ";");
        }
    }

   

    public class BuildConnection:IBuild
    {
        private string Value { get; set; }

        public BuildConnection(string value)
        {
            Value = value;
        }

        public string Build()
        {
            return Value;
        }
    }

   
}
