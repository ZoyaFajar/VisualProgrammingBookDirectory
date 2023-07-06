using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OELVP
{
    public partial class UpdateAuthor : System.Web.UI.Page
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
            DropDownList1.Items.Add("USA");
            DropDownList1.Items.Add("Pakistan");
            DropDownList1.Items.Add("Afghanistan");
            DropDownList1.Items.Add("Turkey");
            DropDownList1.Items.Add("Malaysia");

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Author Set Name = @name, Country = @country, Biography = @bio, URL = @url Where Passport_ID = @ID", conn);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@country",
            DropDownList1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@bio", txtBio.Text);
            cmd.Parameters.AddWithValue("@url", txtURL.Text);
            cmd.Parameters.AddWithValue("@ID", Convert.ToString(txtID.Text));
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                Label1.Text = "Updated";
                Label1.ForeColor = Color.Green;
            }
            else
            {
                Label1.Text = "Not Updated";
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