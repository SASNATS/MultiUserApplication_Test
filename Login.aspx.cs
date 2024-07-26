using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiUserApplication
{
    public partial class Login : System.Web.UI.Page
    {
        ConCls clsobj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Reg_Id) from Login_tbl where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string s = clsobj.fn_execute_scalar(str);
            int s1 = Convert.ToInt32(s);


            if (s1 == 1)
            {
                string str1 = "select Reg_Id from Login_tbl where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string s2 = clsobj.fn_execute_scalar(str1);
                Session["userid"] = s2;

                string str2 = "select LogType from Login_tbl where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string logtype = clsobj.fn_execute_scalar(str2);
                if (logtype == "admin")
                {
                    Label1.Text = "Admin";

                }
                else if (logtype == "user")
                {
                    Label1.Text = "user";
                }
            }
            else
            {
                Label1.Text = "invalid";
            }




        }

    }
}