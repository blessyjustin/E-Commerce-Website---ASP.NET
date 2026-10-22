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
    public partial class cart : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                bind();
            }
        }
        public void bind()
        {
            string uid = Session["uid"].ToString();
            string sel = "select c.cart_id, c.quantity, c.size, c.subtotal, p.product_name, p.price, p.image from tbl_cart c inner join tbl_product p on c.product_id=p.product_id where c.user_id='" + uid + "'";
            DataSet ds = dbcon.fn_adapter(sel);
            DataList1.DataSource = ds;
            DataList1.DataBind();

            string subtotalsel = "select isnull(sum(subtotal),0) from tbl_cart where user_id='" + uid + "'";
            string subtotal = dbcon.fn_scalar(subtotalsel);
            Subtotal.Text = subtotal;
        }
        protected void Button_Minus_Command(object sender, CommandEventArgs e)
        {
            int cartid = Convert.ToInt32(e.CommandArgument);
            string sel = "select quantity from tbl_cart where cart_id=" + cartid + "";
            string quantity = dbcon.fn_scalar(sel);
            int qty = Convert.ToInt32(quantity);
            if (qty > 1)
            {
                qty--;
                string pricequery = "select p.price from tbl_cart c inner join tbl_product p on c.product_id=p.product_id where c.cart_id=" + cartid;
                string price = dbcon.fn_scalar(pricequery);
                decimal subtotal1 = Convert.ToDecimal(price) * qty;

                string update = "update tbl_cart set quantity='" + qty + "',subtotal='"+subtotal1+"' where cart_id=" + cartid + "";
                dbcon.fn_nonquery(update);
            }

            Site1 master = (Site1)this.Master;
            master.bindCartCount();
            bind();
        }

        protected void Button_Plus_Command(object sender, CommandEventArgs e)
        {
            int cartid = Convert.ToInt32(e.CommandArgument);
            string sel = "select quantity from tbl_cart where cart_id=" + cartid + "";
            string quantity = dbcon.fn_scalar(sel);
            int qty = Convert.ToInt32(quantity);
            qty++;
            string pricequery = "select p.price from tbl_cart c inner join tbl_product p on c.product_id=p.product_id where c.cart_id=" + cartid;
            string price = dbcon.fn_scalar(pricequery);
            decimal subtotal1 = Convert.ToDecimal(price) * qty;

            string upd = "update tbl_cart set quantity=" + qty + ",subtotal="+subtotal1+" where cart_id=" + cartid + "";
            dbcon.fn_nonquery(upd);

            Site1 master = (Site1)this.Master;
            master.bindCartCount();
            bind();
        }

        protected void Button_Remove_Command(object sender, CommandEventArgs e)
        {
            int cartid = Convert.ToInt32(e.CommandArgument);
            string del = "delete from tbl_cart where cart_id=" + cartid + "";
            dbcon.fn_nonquery(del);

            Site1 master = (Site1)this.Master;
            master.bindCartCount();
            bind();
        }

        protected void Order_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["uid"]);
            string orderidsel = "select isnull(max(order_id),100) + 1 from tbl_order";
            int orderid = Convert.ToInt32(dbcon.fn_scalar(orderidsel));
            string prodidsel = "select product_id from tbl_cart where user_id=" + uid + "";
            SqlDataReader dr = dbcon.fn_reader(prodidsel);
            List<int> prdtl = new List<int>();
            while (dr.Read())
            {
                prdtl.Add(Convert.ToInt32(dr["product_id"]));
            }
            foreach(int pid in prdtl)
            {
                string sel = "select quantity , subtotal,size from tbl_cart where product_id=" + pid + " and user_id=" + uid + "";
                SqlDataReader dr1 = dbcon.fn_reader(sel);
                decimal st = 0;
                int qt = 0;
                string sze = "";
                while (dr1.Read())
                {
                    st = Convert.ToDecimal(dr1["subtotal"]);
                    qt= Convert.ToInt32(dr1["quantity"]);
                    sze = dr1["size"].ToString();
                }
                string ins = "insert into tbl_order (order_id,user_id,product_id,quantity,size,subtotal,order_date,order_status)values("+orderid+"," + uid + "," + pid + "," + qt + ",'" + sze + "'," + st + ",GETDATE(),'Pending') ";
                dbcon.fn_nonquery(ins);
                string del = "delete from tbl_cart where user_id=" + uid + " and product_id="+pid+" and size='"+sze+"'";
                dbcon.fn_nonquery(del);
            }
            Session["order_id"] = orderid.ToString();
            Response.Redirect("checkout.aspx");
        }
    }
    
}