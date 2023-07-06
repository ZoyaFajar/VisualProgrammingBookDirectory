using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;

namespace OELVP
{
    public partial class InsertBook : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("Select * From Book", conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "Name";
                ListBox1.DataValueField = "Passport_ID";
                ListBox1.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string pub = txtPublisher.Text;
            string year = txtYear.Text;
            SqlCommand cmd = new SqlCommand("Insert INTO Book(Book_Title, Book_Year, Publisher) VALUES(@title, @year.  @publisher)", conn);
 cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@publisher", pub);
            cmd.Parameters.AddWithValue("@year", year);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            cmd = new SqlCommand("Select * From Book Where Book_Title = @title", conn);
            cmd.Parameters.AddWithValue("@title", title);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (int j in ListBox1.GetSelectedIndices())
            {
                cmd = new SqlCommand("INSERT INTO AuthorBook VALUES(@ISBN, @psid)", conn);
            cmd.Parameters.AddWithValue("@ISBN", dt.Rows[0][0]);
                cmd.Parameters.AddWithValue("@psid",
               ListBox1.Items[j].Value);
                conn.Open();
                int k = cmd.ExecuteNonQuery();
                conn.Close();
            }
            if (i > 0)
            {
                Label1.Text = "Inserted";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label1.Text = "Not Inserted";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookPage.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}