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
    public partial class checkout : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCustomerDetails();
                bindOrderDetails();
            }
        }

        public void bindCustomerDetails()
        {
            string uid = Session["uid"].ToString();
            string sel = "select * from user_reg where user_id='" + uid + "'";
            SqlDataReader dr = dbcon.fn_reader(sel);
            while (dr.Read())
            {
                CustomerNameLabel.Text = dr["user_name"].ToString();
                PhoneLabel.Text = dr["phoneno"].ToString();
            }
        }
        public void bindOrderDetails()
        {
            string orderid = Session["order_id"].ToString();
            string sel = "select o.quantity, o.size, o.subtotal,p.product_name, p.price from tbl_order o inner join tbl_product p on o.product_id = p.product_id where o.order_id='" + orderid + "'";
            DataSet ds = dbcon.fn_adapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            string totalsel = "select isnull(sum(subtotal),0) from tbl_order where order_id='" + orderid + "'";
            string total = dbcon.fn_scalar(totalsel);
            TotalAmount.Text = total;
            FinalTotal.Text = total;
        }

        protected void AddAddressbtn_Click(object sender, EventArgs e)
        {
            addAddressPanel.Visible = true;
        }

        protected void SaveAddressbtn_Click(object sender, EventArgs e)
        {
            AddressLabel.Text = AddressTextBox.Text + ",<br/>" + CityTextBox.Text + ",<br/>" + DistrictTextBox.Text + ",<br/>" + PinTextBox.Text;
            addAddressPanel.Visible = false;
        }

        protected void EditPhoneButton_Click(object sender, EventArgs e)
        {
            editPhonePanel.Visible = true;
        }

        protected void SavePhoneBtn_Click(object sender, EventArgs e)
        {
            PhoneTextBox.Text = PhoneLabel.Text;
            editPhonePanel.Visible = false;
        }

        protected void Payment_Click(object sender, EventArgs e)
        {
            string orderid = Session["order_id"].ToString();
            string uid = Session["uid"].ToString();
            string inn = "insert into tbl_invoice values('" + orderid + "','" + uid + "','" + CustomerNameLabel.Text + "','" + PhoneLabel.Text + "','" + AddressLabel.Text + "',GETDATE(),'" + FinalTotal.Text + "')";
            dbcon.fn_nonquery(inn);

            Response.Redirect("payment.aspx");

        }
    }
}
