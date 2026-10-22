using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MainProject1
{
    public class DBConnection
    {
        SqlConnection con;
        SqlCommand cmd;
        public DBConnection()
        {
            con = new SqlConnection(@"server=DESKTOP-E6AQAHH\SQLEXPRESS;database=project_twolayer;integrated security=true;");
        }
        public int fn_nonquery(string query)
        {
            if (ConnectionState.Open == con.State)
            {
                con.Close();
            }
            cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string fn_scalar(string query)
        {
            if (ConnectionState.Open == con.State)
            {
                con.Close();
            }
            cmd = new SqlCommand(query, con);
            con.Open();
            string s = "";
            object result = cmd.ExecuteScalar();
            if(result!=null)
            {
                s = result.ToString();
            }
            return s;
        }
        public SqlDataReader fn_reader(string query)
        {
            if (ConnectionState.Open == con.State)
            {
                con.Close();
            }
            cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataSet fn_adapter(string query)
        {
            if (ConnectionState.Open == con.State)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataTable fn_adaptertable(string query)
        {
            if (ConnectionState.Open == con.State)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}