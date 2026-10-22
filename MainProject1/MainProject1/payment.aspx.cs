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
    public partial class payment : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string amt = "select total_amt from tbl_invoice where order_id='" + Session["order_id"].ToString() + "'";
                string total = dbcon.fn_scalar(amt);
                AmountLabel.Text = total;

                bindacc();
            }
        }
        public void bindacc()
        {
            string uid = Session["uid"].ToString();
            string sel = "select acc_name,acc_number,bal from tbl_account where user_id='" + uid + "'";
            SqlDataReader dr = dbcon.fn_reader(sel);
            if (dr.Read())
            {
                AccountNumberTextBox.Text = dr["acc_number"].ToString();
                AccountHolderTextBox.Text = dr["acc_name"].ToString();
                BalanceTextBox.Text = dr["bal"].ToString();
            }
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            string uid = Session["uid"].ToString();
            string orderid = Session["order_id"].ToString();
            string sel = "select acc_number from tbl_account where user_id='" + uid + "'";
            string account = dbcon.fn_scalar(sel);
            if (account == "")
            {
                string ins = "insert into tbl_account values('" + uid + "','" + AccountNumberTextBox.Text + "','" + AccountHolderTextBox.Text + "','" +Convert.ToDecimal(BalanceTextBox.Text) + "')";
                dbcon.fn_nonquery(ins);
            }
            else
            {
                string upd = "update tbl_account set acc_name='" + AccountHolderTextBox.Text + "', acc_number='" + AccountNumberTextBox.Text +"', bal=" + Convert.ToDecimal(BalanceTextBox.Text) +" where user_id='" + uid + "'";
                dbcon.fn_nonquery(upd);
            
            }
            string accountno = AccountNumberTextBox.Text;
            PaymentServiceReference1.ServiceClient service = new PaymentServiceReference1.ServiceClient();
            decimal orderAmount = Convert.ToDecimal(AmountLabel.Text);
            decimal balanceAmount = service.GetBal(accountno);

            if (balanceAmount < orderAmount)
            {
                MessageLabel.Text = "Payment Declined: Insufficient Balance";
                restoreCart();
                return;
            }
            bool result = service.BalUpdate(accountno, orderAmount);
            if (result == true)
            {
                string updorder = "update tbl_order set order_status='Paid' where order_id='" + orderid + "' and user_id='" + uid + "'";
                dbcon.fn_nonquery(updorder);

                string selproducts = "select product_id, quantity from tbl_order where order_id='" + orderid + "' and user_id='" + uid + "'";
                DataSet ds = dbcon.fn_adapter(selproducts);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string productid = row["product_id"].ToString();
                    string quantity = row["quantity"].ToString();
                    string updstock = "update tbl_product set stock = stock - " + quantity + " where product_id='" + productid + "'";
                    dbcon.fn_nonquery(updstock);
                }

                MessageLabel.Text = "Payment Successful!";
                Response.Redirect("ThankYou.aspx");
            }
            else
            {
                MessageLabel.Text = "Payment Declined";
            }
        }
        public void restoreCart()
        {
            string uid = Session["uid"].ToString();
            string orderid = Session["order_id"].ToString();

            string sel = "select product_id, quantity, size, subtotal from tbl_order where order_id='" + orderid + "' and user_id='" + uid + "'";
            DataSet ds = dbcon.fn_adapter(sel);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string productid = row["product_id"].ToString();
                string quantity = row["quantity"].ToString();
                string size = row["size"].ToString();
                string subtotal = row["subtotal"].ToString();

                string check = "select count(*) from tbl_cart where user_id='" + uid + "' and product_id='" + productid + "' and size='" + size + "'";
                string count = dbcon.fn_scalar(check);
                if (count == "0")
                {
                    string ins = "insert into tbl_cart(user_id, product_id, quantity, size, subtotal) values('" + uid + "','" + productid + "','" + quantity+"','" + size + "','" + subtotal + "')";
                    dbcon.fn_nonquery(ins);
                }
                else
                {
                    string upd = "update tbl_cart set quantity = quantity + " + quantity +", subtotal = subtotal + " + subtotal +" where user_id='" + uid + "' and product_id='" + productid +"' and size='" + size + "'";
                    dbcon.fn_nonquery(upd);
                }
            }

            string delorder = "delete from tbl_order where order_id='" + orderid +"' and user_id='" + uid + "' and order_status='Pending'";
            dbcon.fn_nonquery(delorder);
            string delinvoice = "delete from tbl_invoice where order_id='" + orderid +"' and user_id='" + uid + "'";

            dbcon.fn_nonquery(delinvoice);
        }
    }
}