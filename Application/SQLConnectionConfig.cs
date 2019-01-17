using System;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application
{
    class SQLConnectionConfig
    {
        string str;
        public string SqlConnectionString
        {
            get {
                return str;
            }

            set {
                str = value;
            }
        }
    }
}
