using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace OELVP
{
    public partial class AuthorPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(bool)Application["enter"])
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("HomePage.aspx");
            }
            SqlCommand cmd = new SqlCommand("Select * From Author", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnInsertAuthor_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertAuthor.aspx");
        }

        protected void btnUpdateAuthor_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAuthor.aspx");
        }

        protected void btnDeleteAuthor_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteAuthor.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}