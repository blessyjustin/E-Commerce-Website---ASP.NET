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
    public partial class singleProduct : System.Web.UI.Page
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
            string prodid = Session["productid"].ToString();
            string sel="Select * from tbl_product where product_id='"+prodid+"'";
            SqlDataReader rd = dbcon.fn_reader(sel);
            while (rd.Read())
            {
                ProductImage.ImageUrl = rd["image"].ToString();
                ProductName.Text = rd["product_name"].ToString();
                ProductDescription.Text = rd["description"].ToString();
                ProductPrice.Text = rd["price"].ToString();
                ProductStock.Text = rd["stock"].ToString() + " Stock left "; 
            }
        }
        protected void btnMinus_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(lblQuantity.Text);
            if (qty > 1)
            {
                qty--;
            }
            lblQuantity.Text = qty.ToString();
        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(lblQuantity.Text);
            qty++;
            lblQuantity.Text = qty.ToString();

        }

        protected void SizeS_Click(object sender, EventArgs e)
        {
            SelectedSize.Text = "S";
            SizeS.CssClass = "size-button selected";
            SizeM.CssClass = "size-button";
            SizeL.CssClass = "size-button";
            SizeXL.CssClass= "size-button";
        }

        protected void SizeM_Click(object sender, EventArgs e)
        {
            SelectedSize.Text = "M";
            SizeS.CssClass = "size-button";
            SizeM.CssClass = "size-button selected";
            SizeL.CssClass = "size-button";
            SizeXL.CssClass ="size-button";
        }

        protected void SizeL_Click(object sender, EventArgs e)
        {
            SelectedSize.Text = "L";
            SizeS.CssClass = "size-button";
            SizeM.CssClass = "size-button";
            SizeL.CssClass = "size-button selected";
            SizeXL.CssClass = "size-button";
        }

        protected void SizeXL_Click(object sender, EventArgs e)
        {
            SelectedSize.Text = "XL";
            SizeS.CssClass = "size-button";
            SizeM.CssClass = "size-button";
            SizeL.CssClass = "size-button";
            SizeXL.CssClass = "size-button selected";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            string uid = Session["uid"].ToString();
            string prodid = Session["productid"].ToString();
            string quantity = lblQuantity.Text;
            string size = SelectedSize.Text;
            string pricesel = "select price from tbl_product where product_id='" + prodid + "'";
            string price = dbcon.fn_scalar(pricesel);
            decimal subtotal = Convert.ToDecimal(price) * Convert.ToInt32(quantity);

            string check = "select count(*) from tbl_cart where user_id='" + uid + "'and product_id='" + prodid +"' and size='" + size + "'";
            string count = dbcon.fn_scalar(check);
            if (count != "0")
            {
                string update = "update tbl_cart set quantity = quantity + " + quantity + ",subtotal = subtotal + " + subtotal +" where user_id='" + uid +"' and product_id='" + prodid +"' and size='" + size + "'";
                dbcon.fn_nonquery(update);
            }
            else
            {
                string ins = "insert into tbl_cart (user_id,product_id,quantity,size,subtotal) values('" +uid + "','" + prodid + "','" + quantity + "','" + size + "',"+subtotal+")";
                dbcon.fn_nonquery(ins);
            }

            Site1 master = (Site1)this.Master;
            master.bindCartCount();
        }
    }
    
}