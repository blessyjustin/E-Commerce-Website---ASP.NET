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
    public partial class Login : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string scid = "select count(reg_id) from login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string cid = dbcon.fn_scalar(scid);
            if (cid == "1")
            {
                string sid = "select reg_id from login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string id = dbcon.fn_scalar(sid);
                Session["uid"] = id;

                string seltype = "select log_type from login where reg_id=" + Session["uid"] + "";
                string logtype = dbcon.fn_scalar(seltype);
                if (logtype == "admin")
                {
                    Label3.Visible = true;
                    Label3.Text = "Logged in as Admin";
                    Response.Redirect("adminHome.aspx");
                }
                else
                {
                    restoreOrder();
                    Label3.Visible = true;
                    Label3.Text = "Logged in as User";
                    Response.Redirect("HomePage.aspx");
                }
            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "Invalid Credentials";
            }
        }
        public void restoreOrder()
        {
            string uid = Session["uid"].ToString();
            string sel = "select order_id, product_id, quantity, size, subtotal from tbl_order where user_id='" + uid + "'and order_status='Pending'";
            SqlDataReader dr = dbcon.fn_reader(sel);
            List<string> productids = new List<string>();
            List<string> quantities = new List<string>();
            List<string> sizes = new List<string>();
            List<string> subtotals = new List<string>();
            while (dr.Read())
            {
                productids.Add(dr["product_id"].ToString());
                quantities.Add(dr["quantity"].ToString());
                sizes.Add(dr["size"].ToString());
                subtotals.Add(dr["subtotal"].ToString());
            }
            for (int i = 0; i < productids.Count; i++)
            {
                string productid = productids[i];
                string quantity = quantities[i];
                string size = sizes[i];
                string subtotal = subtotals[i];

                string check = "select count(*) from tbl_cart where user_id='" + uid + "' and product_id='" + productid + "' and size='" + size + "'";
                string count = dbcon.fn_scalar(check);
                if (count == "0")
                {
                    string ins = "insert into tbl_cart (user_id, product_id, quantity, size, subtotal) values('" + uid + "','" + productid + "','" +quantity + "','" + size + "','" + subtotal + "')";
                    dbcon.fn_nonquery(ins);
                }
            }
            string del = "delete from tbl_order where user_id='" + uid + "' and order_status='Pending'";
            dbcon.fn_nonquery(del);
        }
    }
}