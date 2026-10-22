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
    public partial class productPage : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCategoryLabel();
                bindProducts();
                bindSubcategory();
            } 
        }
        public void bindCategoryLabel()
        {
            string catid = Session["catid"].ToString();
            string sel = "select category_name from tbl_category where category_id = " + catid;
            string catname = dbcon.fn_scalar(sel);
            Label1.Text = catname;            
        }
        public void bindProducts()
        {
            string catid = Session["catid"].ToString();
            string sel;
            if (Session["subcatid"] == null)
            {
                sel = "select p.* from tbl_product p inner join tbl_subcategory s on p.subcategory_id=s.subcategory_id where s.category_id='" + catid + "'";
            }
            else
            {
                string subcatid = Session["subcatid"].ToString();
                sel = "select * from tbl_product where subcategory_id='" + subcatid + "'";
            }
            
            DataSet ds = dbcon.fn_adapter(sel);
            DataList2.DataSource = ds;
            DataList2.DataBind();
        }
        public void bindSubcategory()
        {
            string catid = Session["catid"].ToString();
            string sel = "select * from tbl_subcategory where category_id = " + catid;
            DataSet ds = dbcon.fn_adapter(sel);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }

        protected void Subcategory_Command(object sender, CommandEventArgs e)
        {
            string subcatid = e.CommandArgument.ToString();
            Session["subcatid"] = subcatid;
            Response.Redirect("productPage.aspx");
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            string productid = e.CommandArgument.ToString();
            Session["productid"] = productid;
            Response.Redirect("singleProduct.aspx");
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string productid = e.CommandArgument.ToString();
            Session["productid"] = productid;
            Response.Redirect("singleProduct.aspx");
        }
    }
}