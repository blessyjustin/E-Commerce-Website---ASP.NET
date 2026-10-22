using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace MainProject1
{
    public partial class Category : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        { 
            if(!IsPostBack)
            {
                bind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/Pics/categories/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string ins = "insert into tbl_category values('" + TextBox1.Text + "','" + p + "')";
            int i = dbcon.fn_nonquery(ins);
            if (i == 1)
            {
                bind();
                Label3.Visible = true;
                Label3.Text = "Successfully Added";
            }

        }
        public void bind()
        {
            string sel = "select * from tbl_category";
            DataSet ds = dbcon.fn_adapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from tbl_category where category_id=" + getid + "";
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
            TextBox txtcategoryname = (TextBox)GridView1.Rows[i].Cells[1].Controls[0];
            FileUpload flphoto = (FileUpload)GridView1.Rows[i].Cells[2].FindControl("FileUpload2");
            Image iphoto = (Image)GridView1.Rows[i].Cells[2].FindControl("Image2");
            string p = iphoto.ImageUrl;
            if (flphoto.HasFile)
            {
                p = "~/Pics/categories/" + flphoto.FileName;
                flphoto.SaveAs(MapPath(p));
            }
            iphoto.ImageUrl = p;
            string update = "update tbl_category set category_name='" + txtcategoryname.Text + "',image='" + p + "' where category_id="+getid+"";
            int j = dbcon.fn_nonquery(update);
            if(j==1)
            {
                GridView1.EditIndex = -1;
                bind();
            }
        }
    }
}