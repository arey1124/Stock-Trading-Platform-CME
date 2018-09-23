using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockTradingPlatform.Models;
using System.Drawing;
using System.Net.Mail;

namespace StockTradingPlatform
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        StpDBEntities db = new StpDBEntities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            code.Visible = false;
            submit.Visible = false;
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            tblUser user = db.tblUsers.SingleOrDefault(x => x.email == email.Text);
            int? userId = null;
            int s = 0;
            if (user == null)
            {
                Label1.Text = "Email Not Registered";
                Label1.ForeColor = Color.Red;
            }
            else
            {
                Session["user"] = user;
                emailbtn.Visible = false;
                code.Visible = true;
                submit.Visible = true;
                userId = user.uid;
                Random r = new Random();
                String randcode = r.Next(0, 999999).ToString("D6");
                tblCode ucode = db.tblCodes.SingleOrDefault(x => x.uid == userId);
                if(ucode == null)
                {
                    tblCode newcode = new tblCode();
                    newcode.uid = userId;
                    newcode.code = randcode;
                    db.tblCodes.Add(newcode);
                    db.SaveChanges();
                }
                else
                {
                    ucode.code = randcode;
                    db.SaveChanges();
                }
                s = SendCode(randcode, email.Text, user.fname);
                if (s == 1)
                {
                    Label1.Text = "Code Sent";
                    Label1.ForeColor = Color.Green;
                }
            }
        }

        public int SendCode(string code, string email, string fname)
        {
            int s = 0;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("cme.stp@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Code To Reset Password";
                mail.Body = "Hello " + fname + ",\n\nPlease find below your 6 digits code to reset your Password:\nCode : " + code + "\n\n\nHappy Trading!";
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("cme.stp@gmail.com", "%TGB6yhn^YHN5tgb");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                s = 1;
            }
            catch (Exception ex)
            {
                s = 0;
            }
            return s;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            tblUser usr = Session["user"] as tblUser;
            tblCode vercode = db.tblCodes.SingleOrDefault(x => x.uid == usr.uid);
            if(vercode != null)
            {
                if(code.Text == vercode.code)
                {
                    Response.Redirect("ChangePassword.aspx");
                }
                else
                {
                    code.Visible = true;
                    submit.Visible = true;
                    Label1.Text = "Invalid Code";
                    Label1.ForeColor = Color.Red;
                }
            }
        }
    }
}