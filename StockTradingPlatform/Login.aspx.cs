using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockTradingPlatform.Models;
using System.Drawing;

namespace StockTradingPlatform
{
    public partial class Login : System.Web.UI.Page
    {
        StpDBEntities stpDBEntities = new StpDBEntities();

        private bool validateUser(string userName, string password)
        {
            bool status = false;
            var userAuth = stpDBEntities.tblAuthenticates.FirstOrDefault(u => u.userName == userName & u.password == password);
            if (userAuth != null)
            {
                var user = stpDBEntities.tblUsers.FirstOrDefault(u => u.uid == userAuth.uid);
                if (user != null)
                {
                    Session["user"] = user;
                    Session["userName"] = userAuth.userName;
                    HttpCookie ck1 = new HttpCookie("userCk");
                    ck1.Expires.AddDays(2);
                    Response.Cookies.Add(ck1);
                    status = true;
                }
            }

            return status;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["userName"] != null)
            {
                var user = Session["user"] as tblUser;
                if(user.role == "A")
                {
                    Response.Redirect("/Admin/Index");
                }
                else if (user.role == "U")
                {
                    Response.Redirect("/User/Dashboard");
                }
            }
                
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (validateUser(email.Text, password.Text))
            {
                Label1.Text = "Success";

                var user = Session["user"] as tblUser;

                if (user.role == "U")
                {
                    Response.Redirect("User/Dashboard");
                }
                else if(user.role == "A")
                {
                    Response.Redirect("Admin/Index");
                }
                else
                {
                    Label1.Text = "Some error ocuured , please contact us at cme.stp@gmail.com";
                    Label1.ForeColor = Color.Red;
                }
            }
            else
            {
                Label1.Text = "Invalid Credentials";
                Label1.ForeColor = Color.Red;
            }
        }
    }
}