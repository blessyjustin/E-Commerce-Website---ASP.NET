using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MainProject1
{
    public partial class adminReg : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string maxsel = "select max(reg_id) from login";
            string maxid = dbcon.fn_scalar(maxsel);
            int admin_id = 0;
            if (maxid == "")
            {
                admin_id = 1;
            }
            else
            {
                admin_id = Convert.ToInt32(maxid) + 1;
            }
            string insadmin = "insert into admin_reg values(" + admin_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "')";
            int i = dbcon.fn_nonquery(insadmin);
            if (i == 1)
            {
                string inslogin = "insert into login values(" + admin_id + ",'" + TextBox3.Text + "','" + TextBox4.Text + "','admin','active')";
                int j = dbcon.fn_nonquery(inslogin);
                if (j == 1)
                {
                    Label6.Visible = true;
                    Label6.Text = "Registration Successfull";
                }
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            string selid = "select count(reg_id) from login where username='" + TextBox3.Text + "'";
            string count = dbcon.fn_scalar(selid);
            if (Convert.ToInt32(count) >= 1)
            {
                Label5.Visible = true;
                Label5.Text = "Username already exists";
            }
            else
            {
                Label5.Visible = false;
            }
        }
    }
}