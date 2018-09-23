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
    public partial class ChangePassword : System.Web.UI.Page
    {
        StpDBEntities db = new StpDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if(pass1.Text == pass2.Text)
            {
                tblUser user = Session["user"] as tblUser;
                tblAuthenticate auth = db.tblAuthenticates.SingleOrDefault(x => x.uid == user.uid);
                auth.password = pass1.Text;
                db.SaveChanges();
                Session["userName"] = auth.userName;
                if (user.role == "U")
                {
                    Response.Redirect("User/Dashboard");
                }
                else if (user.role == "A")
                {
                    Response.Redirect("Admin/Index");
                }
                else
                {
                    Label1.Text = "Some error ocuured , please contact us at cme.stp@gmail.com";
                    Label1.ForeColor = Color.Red;
                }
            }
        }
    }
}