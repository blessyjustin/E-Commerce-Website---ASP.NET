using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MainProject1
{
    public partial class AdminFeedback : System.Web.UI.Page
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
            string sel = "select feedback_id,user_name,user_email,feedback,feedback_date from tbl_feedback order by feedback_date desc";
            DataSet ds = dbcon.fn_adapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reply")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string feedbackid = GridView1.DataKeys[index].Value.ToString();
                Response.Redirect("FeedbackReply.aspx?feedback_id=" + feedbackid);
            }
        }
    }
}