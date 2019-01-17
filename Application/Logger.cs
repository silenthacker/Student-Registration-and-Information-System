using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using Microsoft.CSharp.RuntimeBinder;
using System.Diagnostics.PerformanceData;
namespace Application
{
    class Logger
    {
        public void CreateSystemLog(string Log_ID, string Log_Type, string Source, string Cumputer_Name, string Computer_IP, string Log_Content,
            string Timestamp, SqlConnection sqlconnection)
        {
            string InsertLogQuery = "INSERT INTO [Tbl.Logs]([LOG ID], [LOG TYPE], SOURCE, [COMPUTER NAME], [COMPUTER IP ADDRESS], [LOG CONTENT]," +
                "[DATE AND TIME]) VALUES(@Log_ID, @Log_Type, @Source, @Cumputer_Name, @Computer_IP, @Log_Content, @Timestamp)";
            SqlCommand sqlcommand = new SqlCommand(InsertLogQuery, sqlconnection);

            sqlcommand.Parameters.AddWithValue("@Log_ID", Log_ID);
            sqlcommand.Parameters.AddWithValue("@Log_Type", Log_Type);
            sqlcommand.Parameters.AddWithValue("@Source", Source);
            sqlcommand.Parameters.AddWithValue("@Cumputer_Name", Cumputer_Name);

            sqlcommand.Parameters.AddWithValue("@Computer_IP", Computer_IP);
            sqlcommand.Parameters.AddWithValue("@Log_Content", Log_Content);
            sqlcommand.Parameters.AddWithValue("@Timestamp", Timestamp);
            sqlcommand.ExecuteNonQuery();
            
        }
    }
}
