using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MultiUserApplication
{
    
    public class ConCls
    {
        SqlConnection con;
        SqlCommand cmd;

        public ConCls()
        {
          con = new SqlConnection(@"server=DESKTOP-8F8C15B\SQLEXPRESS;database=MultiUserDB;Integrated Security=True");

       }
        public int fn_execute_nonquery(string sqlquery)//pass query of insert,delete,update
        {
           
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public string fn_execute_scalar(string sqlquery)//pass query of aggregate fns
        {
           
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;

        }

    }
}
