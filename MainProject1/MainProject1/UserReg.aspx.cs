using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MainProject1
{
    public partial class UserReg : System.Web.UI.Page
    {
        DBConnection dbcon = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string maxsel = "select max(reg_id) from login";
            string maxid = dbcon.fn_scalar(maxsel);
            int user_id = 0;
            if (maxid == "")
            {
                user_id = 1;
            }
            else
            {
                user_id = Convert.ToInt32(maxid) + 1;
            }
            string insuser = "insert into user_reg values(" + user_id + ",'" + TextBox1.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + TextBox4.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "')";
            int i = dbcon.fn_nonquery(insuser);
            if (i == 1)
            {
                string inslogin = "insert into login values(" + user_id + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','user','active')";
                int j = dbcon.fn_nonquery(inslogin);
                if (j == 1)
                {
                    Label8.Visible = true;
                    Label8.Text = "Registration Successfull";
                }
            }

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            string selid = "select count(reg_id) from login where username='" + TextBox5.Text + "'";
            string count = dbcon.fn_scalar(selid);
            if (Convert.ToInt32(count) >= 1)
            {
                Label9.Visible = true;
                Label9.Text = "Username already exists";
            }
            else
            {
                Label9.Visible = false;
            }
        }
    }
}