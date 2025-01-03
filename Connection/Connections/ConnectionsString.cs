using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Connections
{
    public static class ConnectionsString
    {
        public static string Connection1 { get; set; }

        static ConnectionsString()
        {
            Connection1 = @"Data Source=DESKTOP-7D9S1GO;Initial Catalog=Bank;Integrated Security=SSPI;TrustServerCertificate=True;";
        }
    }
}
