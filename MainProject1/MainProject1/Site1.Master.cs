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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
            if (Session["uid"] != null)
            {
                loginMenu.Visible = false;
                registerMenu.Visible = false;

                accountMenu.Visible = true;
                logoutMenu.Visible = true;

                cartCount.Visible = true;

                bindCartCount();
            }
            else
            {
                loginMenu.Visible = true;
                registerMenu.Visible = true;

                accountMenu.Visible = false;
                logoutMenu.Visible = false;

                cartCount.Visible = false;
            }
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("HomePage.aspx");
        }
        public void bind()
        {
            string sel = "select * from tbl_category";
            DataSet ds = dbcon.fn_adapter(sel);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }

        protected void CategoryLink_Command(object sender, CommandEventArgs e)
        {
            string catid = e.CommandArgument.ToString();
            Session["catid"] = catid;
            Session["subcatid"] = null;
            Response.Redirect("productPage.aspx");
        }
        public void bindCartCount()
        {
            string uid = Session["uid"].ToString();
            string sel = "select isnull(sum(quantity),0) from tbl_cart where user_id='" + uid + "'";
            string count = dbcon.fn_scalar(sel);
            cartCount.Text = count;
        }
    }
}