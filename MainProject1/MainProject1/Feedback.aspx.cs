using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MainProject1
{
    public partial class Feedback : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string feedback = FeedbackTextBox.Text;
            string ins = "insert into tbl_feedback(user_name,user_email,feedback,feedback_date) values('" + name + "','" + email + "','" + feedback + "',GETDATE())";
            dbcon.fn_nonquery(ins);          
            string body = "Name: " + name +"<br/><br/>Email: " + email +"<br/><br/>Feedback: " + feedback;
            SendEmail2("Novara Store","blessyjustin04@gmail.com", "okaeezxpzwwxgxgu","Novara Admin","blessyjustin04@gmail.com","Customer Feedback", body,email );
            MessageLabel.Text = "Thank you for your feedback!";
        }

        public static void SendEmail2(string yourName, string yourGmailUserName,string yourGmailPassword,string toName,string toEmail,string subject,string body, string userEmail)
        {
            string to = toEmail;
            string from = yourGmailUserName;

            MailMessage message = new MailMessage();

            message.From = new MailAddress(from, yourName);

            message.To.Add(to);

            message.Subject = subject;
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(userEmail);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential( yourGmailUserName,yourGmailPassword );

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

