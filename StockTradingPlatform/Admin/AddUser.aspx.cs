using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace StockTradingPlatform.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int r = 0;
            string fName = fname.Text;
            string lName = lname.Text;
            string eMail = email.Text;
            long mobile = Convert.ToInt64(mob.Text);
            string add = address.Text;
            DateTime Dob = Convert.ToDateTime(dob.Text);
            string uName = uname.Text;
            string password = pwd.Text;
            string Role = role.SelectedValue;
            string Status = status.SelectedValue;
            r = UsersBO.AddUser(fName, lName, eMail, mobile, Dob, add, Role, Status, uName, password);
            if (r != 1)
            {
                Label1.Text = "Error In Adding User.";
                Label1.ForeColor = Color.Red;
            }
            else
            {
                r = UsersBO.SendMail(eMail,fName,uName,password);
                if(r == 1)
                    Response.Redirect("~/Admin/ViewUsers");
                else
                {
                    Label1.Text = "Error In Sending Mail, but User Added Successfully.";
                    Label1.ForeColor = Color.Red;
                }
            }
        }
    }
}