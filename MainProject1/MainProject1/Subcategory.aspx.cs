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
    public partial class Subcategory : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                string sel = "select category_id,category_name from tbl_category";
                DataSet da = dbcon.fn_adapter(sel);
                DropDownList1.DataSource = da;
                DropDownList1.DataTextField = "category_name";
                DropDownList1.DataValueField = "category_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--Select category--");

                
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            string ins = "insert into tbl_subcategory(subcategory_name,category_id) values('" + TextBox1.Text + "','" + DropDownList1.SelectedItem.Value + "')";
            int i = dbcon.fn_nonquery(ins);
            if (i == 1)
            {
                Label3.Visible = true;
                Label3.Text = "Added Successfully";
            }
            bind();
        }
        public void bind()
        {
            string sel ="select s.subcategory_id, s.subcategory_name, c.category_name from tbl_subcategory s inner join tbl_category c on s.category_id = c.category_id order by s.subcategory_id"; 
            DataSet ds = dbcon.fn_adapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from tbl_subcategory where subcategory_id=" + getid + "";
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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtsubcategoryname = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            string update = "update tbl_subcategory set subcategory_name='" + txtsubcategoryname.Text + "' where subcategory_id=" + getid + "";
            int j = dbcon.fn_nonquery(update);
            if (j == 1)
            {
                GridView1.EditIndex = -1;
                bind();
            }
        }
    }
}