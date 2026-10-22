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
    public partial class Product : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select category_id,category_name from tbl_category";
                DataSet ds = dbcon.fn_adapter(sel);
                DropDownList1.DataSource = ds;
                DropDownList1.DataValueField = "category_id";
                DropDownList1.DataTextField = "category_name";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--Select Category--");
                bind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/Pics/products/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string ins = "insert into tbl_product(product_name,description,price,stock,image,subcategory_id)values('" + TextBox1.Text + "','" + TextBox4.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + p + "'," + DropDownList2.SelectedItem.Value + ")";
            int i = dbcon.fn_nonquery(ins);
            if (i == 1)
            {
                Label8.Visible = true;
                Label8.Text = "Product added successfully";
            }
            bind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "select subcategory_id,subcategory_name from tbl_subcategory where category_id='" + DropDownList1.SelectedItem.Value + "'";
            DataSet ds = dbcon.fn_adapter(select);
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "subcategory_name";
            DropDownList2.DataValueField = "subcategory_id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "--Select Subcategory--");
        }
        public void bind()
        {
            string sel = "select p.product_id, c.category_name, s.subcategory_name, p.product_name, p.price, p.stock, p.description, p.image from tbl_product p inner join tbl_subcategory s on p.subcategory_id = s.subcategory_id inner join tbl_category c on s.category_id = c.category_id order by p.product_id";
            DataSet ds = dbcon.fn_adapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from tbl_product where product_id=" + getid + "";
            int j = dbcon.fn_nonquery(del);
            if (j == 1)
            {
                bind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtproductname = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
            TextBox txtprice = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtstock = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtproductdescription = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            FileUpload flphoto = (FileUpload)GridView1.Rows[i].Cells[7].FindControl("FileUpload2");
            Image iphoto = (Image)GridView1.Rows[i].Cells[7].FindControl("Image2");
            string p = iphoto.ImageUrl;
            if (flphoto.HasFile)
            {
                p = "~/Pics/products/" + flphoto.FileName;
                flphoto.SaveAs(MapPath(p));
            }
            iphoto.ImageUrl = p;
            string update = "update tbl_product set product_name='" + txtproductname.Text + "',price="+txtprice.Text+",stock="+txtstock.Text+",description='"+txtproductdescription.Text+"',image='" + p + "' where product_id=" + getid + "";
            int j = dbcon.fn_nonquery(update);
            if (j == 1)
            {
                GridView1.EditIndex = -1;
                bind();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }
    }
}