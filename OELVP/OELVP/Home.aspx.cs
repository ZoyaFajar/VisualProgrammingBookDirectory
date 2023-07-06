using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OELVP
{
    public partial class Home : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("SELECT Book.Book_Title,  Book.Book_Year, Book.Publisher, Author.Name AS 'Author Name', Author.Country AS 'Author Country',Author.URL AS 'Author URL', Author.Biography AS 'Author Bio' " +
            "FROM Author, AuthorBook, Book Where " +
            "AuthorBook.Passport_ID =Author.Passport_ID AND " +
            "AuthorBook.ISBN = Book.ISBN", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAuthor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorPage.aspx");
        }
        protected void btnBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookPage.aspx");
        }
    }
}