using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Net;
using System.Net.Mail;


namespace BusinessLogicLayer
{
    public class UsersBO
    {
        public static int AddUser(string fname, string lname, string email, long mobile, DateTime dob, string address, string role, string status, string uname, string password)
        {
            return UsersHelper.AddUser(fname, lname, email, mobile, dob, address, role, status, uname, password);
        }
        public static int SendMail(string eMail, string fname, string uName, string password)
        {
            int s = 0;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("cme.stp@gmail.com");
                mail.To.Add(eMail);
                mail.Subject = "Welcome to Stock Trading Platform of CME Group!";
                mail.Body = "Hello " + fname + ",\n\nWe are excited to have you on board with us on CME Group Stock Trading Platform.\n\nPlease find below your credentails to login:\nUserName : " + uName + "\nPassword : " + password + "\n\nYou can change your password after login!\n\nHappy Trading!";
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("cme.stp@gmail.com", "%TGB6yhn^YHN5tgb");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                s = 1;
            }
            catch(Exception ex)
            {
                s = 0;
            }
            return s;
        }
    }
}
