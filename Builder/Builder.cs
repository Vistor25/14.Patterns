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
    
}
