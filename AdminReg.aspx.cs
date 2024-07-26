using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiUserApplication
{
    public partial class AdminReg : System.Web.UI.Page
    {
        ConCls clsobj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select max(Reg_Id) from Login_tbl";
            string s = clsobj.fn_execute_scalar(str);
            
            int regid = 0;
            if (s == "")
            {
                regid = 1;
            }
            else
            {
                int s1 = Convert.ToInt32(s);
                regid = s1 + 1;
            }
            string ins = "insert into Admin_Reg values(" + regid + ",'" + TextBox1.Text + "','" + TextBox2.Text + "')";
            int i = clsobj.fn_execute_nonquery(ins);
            if (i == 1)
            {
                string inslog = "insert into Login_tbl values(" + regid + ",'" + TextBox3.Text + "','" + TextBox4.Text + "','admin','active')";
                int j = clsobj.fn_execute_nonquery(inslog);
            }
        }
    }
}