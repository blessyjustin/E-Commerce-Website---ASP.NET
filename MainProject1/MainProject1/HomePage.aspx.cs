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
    public partial class HomePage : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        public void bind()
        {
            string sel = "select * from tbl_category";
            DataSet ds = dbcon.fn_adapter(sel);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            string catid = e.CommandArgument.ToString();
            Session["catid"] = catid;
            Session["subcatid"] = null;
            Response.Redirect("productPage.aspx");
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string catid = e.CommandArgument.ToString();
            Session["catid"] = catid;
            Session["subcatid"] = null;
            Response.Redirect("productPage.aspx");
        }
    }
}