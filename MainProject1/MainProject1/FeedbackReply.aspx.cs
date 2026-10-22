using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MainProject1
{
    public partial class FeedbackReply : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFeedback();
            }
        }

        public void bindFeedback()
        {
            string feedbackid = Request.QueryString["feedback_id"];

            string sel = "select user_name,user_email,feedback from tbl_feedback where feedback_id='" + feedbackid + "'";
            SqlDataReader dr = dbcon.fn_reader(sel);

            if (dr.Read())
            {
                CustomerNameLabel.Text = dr["user_name"].ToString();
                CustomerEmailLabel.Text = dr["user_email"].ToString();
                CustomerFeedbackLabel.Text = dr["feedback"].ToString();
            }

            dr.Close();
        }

        protected void SendReplyButton_Click(object sender, EventArgs e)
        {
            string feedbackid = Request.QueryString["feedback_id"];
            string email = CustomerEmailLabel.Text;
            string reply = ReplyTextBox.Text;

            string body = "Dear " + CustomerNameLabel.Text + ",<br/><br/>" +reply +"<br/><br/>Regards,<br/>Novara Store";

            SendEmail2("Novara Store", "blessyjustin04@gmail.com", "okaeezxpzwwxgxgu", "Customer", email, "Reply to Your Feedback", body);

            string upd = "update tbl_feedback set reply='" + reply + "', reply_date=GETDATE() where feedback_id='" + feedbackid + "'";
            dbcon.fn_nonquery(upd);

            MessageLabel.Text = "Reply sent successfully!";

            Response.AddHeader("REFRESH", "2;URL=AdminFeedback.aspx");
        }

        public static void SendEmail2(string yourName, string yourGmailUserName, string yourGmailPassword, string toName, string toEmail, string subject, string body)
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

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential(yourGmailUserName, yourGmailPassword);

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