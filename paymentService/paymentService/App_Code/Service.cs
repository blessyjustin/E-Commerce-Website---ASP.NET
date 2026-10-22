using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	SqlConnection con = new SqlConnection(@"server=DESKTOP-E6AQAHH\SQLEXPRESS;database=project_twolayer;integrated security=true;");
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}
	public decimal GetBal(string accno)
    {
		decimal bal = 0;
		string sel = "select bal from tbl_account where acc_number='" + accno + "'";
		SqlCommand cmd = new SqlCommand(sel, con);
		con.Open();
		SqlDataReader dr = cmd.ExecuteReader();
		while (dr.Read())
		{
			bal = Convert.ToDecimal(dr["bal"]);
		}
		con.Close();
		return bal;
	}
	public bool BalUpdate(string accno, decimal amount)
    {
		string query = "update tbl_account set bal = bal - " + amount + " where acc_number='" + accno + "' and bal >= " + amount;
		SqlCommand cmd = new SqlCommand(query, con);
		con.Open();
		int i = cmd.ExecuteNonQuery();
		con.Close();
        if (i > 0)
        {
			return true;
        }
        else
        {
			return false;
        }
	}
	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
