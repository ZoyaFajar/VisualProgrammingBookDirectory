using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Login Page Code: 
namespace OELVP
{
    public partial class HomePage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = TextBox1.Text;
            string pass = TextBox2.Text;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE Username = @User AND Password = @Pass", conn);
            cmd.Parameters.AddWithValue("@User", user);
            cmd.Parameters.AddWithValue("@Pass", pass);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count >= 0)
            {
                Application["enter"] = true;
                Response.Redirect("Home.aspx");
            }
            else
                Application["enter"] = false;
                Label1.Text = "Not Logged In!";
        }
    }
}