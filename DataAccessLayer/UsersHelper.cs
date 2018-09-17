using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Mail;

namespace DataAccessLayer
{
    public class UsersHelper
    {
        public static int AddUser(string fname, string lname, string email, long mobile, DateTime dob, string address, string role, string status, string uname, string password)
        {
            int r1 = 0, r2 = 0, r3 = 0;
            string query = "insert into tblUsers(fname, lname, email, mobile, dob, address, role, status) values('" + fname + "','" + lname + "','" + email + "'," + mobile + ",'" + dob + "','" + address + "','" + role + "','" + status + "')";
            r1 = SqlHelper.ExecuteNonSelect(query);
            if (r1 == 1)
            {
                query = "select uid from tblUsers where email = '" + email + "'";
                int uid = SqlHelper.GetIntValue(query);
                query = "insert into tblAuthenticate(uid, userName, password, dateAdded) values(" + uid + ",'" + uname + "',HASHBYTES('SHA2_512','" + password + "'), GETDATE())";
                r2 = SqlHelper.ExecuteNonSelect(query);
                if(r2 != 1)
                {
                    query = "delete from tblUsers where email = '" + email + "'";
                    r3 = SqlHelper.ExecuteNonSelect(query);
                }
                query = "insert into tblWallet(uid, balance) values(" + uid + ",10000);";
                r3 = SqlHelper.ExecuteNonSelect(query);
            }
            return r2;
        }
    }
}
