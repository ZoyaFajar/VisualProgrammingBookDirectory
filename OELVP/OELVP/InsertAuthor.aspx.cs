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
    public partial class InsertAuthor : System.Web.UI.Page
    {
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
                DropDownList1.Items.Add("USA");
                DropDownList1.Items.Add("Pakistan");
                DropDownList1.Items.Add("Afghanistan");
                DropDownList1.Items.Add("Turkey");
                DropDownList1.Items.Add("Malaysia");
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"");
            string name = txtName.Text;
            string bio = txtBio.Text;
            string country = Convert.ToString(DropDownList1.SelectedItem);
            string url = txtURL.Text;
            SqlCommand cmd = new SqlCommand("Insert into Author(Country, Biography, Name, URL) VALUES(@country, @bio, @name, @url)", conn);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@bio", bio);
            cmd.Parameters.AddWithValue("@url", url);
            cmd.Parameters.AddWithValue("@name", name);
            
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                Label1.Text = "Inserted";
                Label1.ForeColor = Color.Green;
            }
            else
            {
                Label1.Text = "Not Inserted";
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