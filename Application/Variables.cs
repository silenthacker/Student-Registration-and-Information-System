using System;
using System.Web;
using System.Data.SqlClient;

namespace Application
{
    class Variables
    {
        public string pathname = "PTLE Solutions\\CLAYGO\\Current User Settings";
        public string _64BaseStringHash = "NATXqhdVV2uTTk89B3hhWegDQYFT0hy0bTvKtsc2NBnAkJKQ1JkjKKOLldovUtHE";

        string TempConnString;
        public string UserSqlConnectionString
        {
            get {
                return TempConnString;
            }

            set {
                TempConnString = value;
            }
        }
    }
}
