using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explore
{
    class Program
    {
        
        public void SelectBooks()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("select * from tbl_Books", con);

            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    Console.WriteLine(rdr["BookID"] + " " + rdr["Title"] + " " + rdr["Price"].ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine("Server is not responding");
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertBooks()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            //SqlCommand cmd = new SqlCommand("insert into tbl_Books values ('Harry potter',3,950)", con);
          
            string qry = "insert into tbl_Books values (@Title, @AuthorID , @Price)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Title", "Davinci code");
            cmd.Parameters.AddWithValue("@AuthorID", 2);
            cmd.Parameters.AddWithValue("@Price", 400);

            //imp to catch exeception ..finally is also good to use...in this it will close after insert or server not respond ...it will save memory space
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Server is not responding");
            }
            finally
            {
                con.Close();
            }
        }
            public void UpdateBooks()
            {
                SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update  tbl_Books set Title='Titanic' , Price = 500 where AuthorID=3  ";
                cmd.Connection = con;
            try
            {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Server is not responding");
                }
                finally
                {
                    con.Close();
                }
            }

        
        public void DeleteBooks()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from tbl_Books where Title = 'Titanic' ";
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Server is not responding");
            }
            finally
            {
                con.Close();
            }
        }
        public void SelectAuthors()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("select * from tbl_Author", con);

            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    Console.WriteLine(rdr["AuthorID"] +  " " + rdr["AuthorName"].ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine("Server is not responding");
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertAuthors()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");

            string qry = "insert into tbl_Author values ( @AuthorName)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@AuthorName", "Sandaliyan");
           
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Server is not responding");
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateAuthors()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update  tbl_Author set AuthorName = 'William Shakespeare' where AuthorID=2 ";
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Server is not responding");
            }
            finally
            {
                con.Close();
            }
        }


        public void DeleteAuthors()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from tbl_Author where AuthorName = 'William Shakespeare'";
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Server is not responding");
            }
            finally
            {
                con.Close();
            }
        }
        public void SpInsertingBooks()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("sp_InsertBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", "Kadal pura");
            cmd.Parameters.AddWithValue("@AuthorID", 4);
            cmd.Parameters.AddWithValue("@Price", 400);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SpUpdatingBooks()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("sp_UpdateBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Price", 1000);
            cmd.Parameters.AddWithValue("@BookID", 1000);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SpDeletingBooks()
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("sp_DeleteBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", 1001);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SpInsertingAuthors(string AuthorName)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("sp_InsertAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = AuthorName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SpUpdatingAuthors(int aid, string name)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");

            SqlCommand cmd = new SqlCommand("sp_UpdateAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = name;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SpDeletingAuthors(int aid)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");

            SqlCommand cmd = new SqlCommand("sp_DeleteAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = aid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string BookSP(string title, int aid, double price)
        {
            SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);
            //con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            //cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            //cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            //cmd.ExecuteNonQuery();
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Title";
            parameter.SqlDbType = SqlDbType.VarChar;
            parameter.Value = title;
            cmd.Parameters.Add(parameter);
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@AuthorID";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Value = aid;
            cmd.Parameters.Add(parameter1);
            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Price";
            parameter2.SqlDbType = SqlDbType.Money;
            parameter2.Value = price;
            cmd.Parameters.Add(parameter2);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string res = "success";

            return res;
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.SpDeletingAuthors(2);
            //obj.SpUpdatingAuthors(2, "Sandiliyan");
           // obj.SpInsertingAuthors("Kalki");
           // obj.SpDeletingBooks();
           // obj.SpUpdatingBooks();
            //obj.SpInsertingBooks();
            //obj.DeleteAuthors();
            //obj.UpdateAuthors();
            //obj.InsertAuthors();
           // obj.SelectAuthors();
           // obj.SelectBooks();
           // obj.DeleteBooks();
           // obj.InsertBookSP("Harry potter" , 3, 650);
            //obj.UpdateBooks();
            //obj.InsertBooks();
            //SqlConnection con = new SqlConnection("data source =LAPTOP-FUHQ3D30\\SQLEXPRESS; database = BookDb;integrated security =true");
           
            //Console.ReadLine();
        }
    }
}
