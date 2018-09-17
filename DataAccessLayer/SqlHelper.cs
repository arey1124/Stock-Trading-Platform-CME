using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccessLayer
{
    public class SqlHelper
    {
        static SqlConnection cn = null;
        static SqlCommand cmd = null;

        public static int ExecuteNonSelect(string query)
        {
            int r = 0;
            try
            {
                string cs = "server=USER-PC;user id=sa;password=1234;database=StpDB";
                cn = new SqlConnection(cs);
                cn.Open();
                cmd = new SqlCommand(query, cn);
                r = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n\nException message : {0}\n\n", ex);
                return r;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
            return r;
        }

        public static int GetIntValue(string query)
        {
            int res = 0;
            try
            {
                string cs = "server=USER-PC;user id=sa;password=1234;database=StpDB";
                cn = new SqlConnection(cs);
                cn.Open();
                cmd = new SqlCommand(query, cn);
                res = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
            return res;
        }
    }
}
