using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace OELVP
{
    public partial class DeleteAuthor : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("Select * From Author", conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Passport_ID";
                DropDownList1.DataBind();
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int Pass = Convert.ToInt32(DropDownList1.SelectedValue);
            SqlCommand cmd = new SqlCommand("Delete From AuthorBook Where Passport_ID = @pass", conn);
           
            cmd.Parameters.AddWithValue("@pass", Pass);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            cmd = new SqlCommand("Delete From Author Where Passport_ID = @pass",conn);
            cmd.Parameters.AddWithValue("@pass", Pass);
            conn.Open();
            int j = cmd.ExecuteNonQuery();
            conn.Close();
            if (j > 0)
            {
                Label1.Text = "Deleted";
                Label1.ForeColor = Color.Green;
            }
            else
            {
                Label1.Text = "Not Deleted";
                Label1.ForeColor = Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorPage.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}