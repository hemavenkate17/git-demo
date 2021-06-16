using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace WebApplication1.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("Select BookID,Title , AuthorName, Price  from tbl_Books b join tbl_Author a on b.AuthorID = a.AuthorID", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int NewBook(string Title, string Authorname, double price)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            con.Open();
             SqlCommand cmd = new SqlCommand("insert into tbl_books values(@Title ,(select AuthorID from tbl_author where AuthorName = @AuthorName),@Price)", con);

            cmd.Parameters.AddWithValue("@Title", Title);
            //cmd.Parameters.AddWithValue("@AuthorID", Aid);

            cmd.Parameters.AddWithValue("@AuthorName",Authorname);

            cmd.Parameters.AddWithValue("@Price", price);

            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable DisplayAuthor()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("Select * from tbl_Author", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewAuthor(string AuthorName)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertAuthor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", AuthorName);
            

            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable BookbyID(int bookid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tbl_Books where bookid =" +bookid, con); //we can also pass parameter by + symbol
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int UpdateBook(int Bid, string Title, int Aid , double Price)
        {

            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            con.Open();
            string sqlqry = "update tbl_books set Title = @title ,AuthorID = @aid,Price=@price where BookID= @bid";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@aid", Aid);
            cmd.Parameters.AddWithValue("@price", Price);
            cmd.Parameters.AddWithValue("@bid", Bid);
            return cmd.ExecuteNonQuery();

        }
        public int DeleteBook(int bookid)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_books where bookid = @bkid", con);
            cmd.Parameters.AddWithValue("@bkid", bookid);
            return cmd.ExecuteNonQuery();
        }

    }
}