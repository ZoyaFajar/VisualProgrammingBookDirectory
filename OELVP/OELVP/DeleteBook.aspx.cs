using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OELVP
{
    public partial class DeleteBook : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("Select * From Book", conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "Book_Title";
                DropDownList1.DataValueField = "ISBN";
                DropDownList1.DataBind();
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int isbn = Convert.ToInt32(DropDownList1.SelectedValue);
            SqlCommand cmd = new SqlCommand("Delete From AuthorBook Where ISBN = @isbn", conn);
           
            cmd.Parameters.AddWithValue("@isbn", isbn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            cmd = new SqlCommand("Delete FROM Book WHERE ISBN=@isbn", conn);
            cmd.Parameters.AddWithValue("@isbn", isbn);
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
        Response.Redirect("BookPage.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}