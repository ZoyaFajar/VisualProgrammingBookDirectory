using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OELVP
{
    public partial class UpdateBook : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=Zoya\SQLEXPRESS01;Initial Catalog=OELVP;Integrated Security=True");

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
            SqlCommand cmd = new SqlCommand("SELECT * FROM book", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Book_Title";
            DropDownList1.DataValueField = "ISBN";
            DropDownList1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookPage.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}