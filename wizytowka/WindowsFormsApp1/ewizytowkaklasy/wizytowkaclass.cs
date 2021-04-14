using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ewizytowkaklasy
{
    class wizytowkaclass
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Numer { get; set; }
        public string Adres { get; set; }
        public string Plec { get; set; }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        // Wybieranie danych z bazy
        public DataTable Select()
        {
            // łączenie z bazą
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                // komenda SQL
                string sql = "SELECT * From tbl_contact";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        //dodaj dane do BD
        public bool Insert(wizytowkaclass c)
        {
            //tworzenie domyślnego return type i ustawienie na false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //zapytanie sql
                string sql = "INSERT INTO tbl_contact (Imie,Nazwisko,Numer,Adres,Plec) VALUES (@Imie,@Nazwisko,@Numer,@Adres,@Plec)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                // tworzenie wartości aby dodać do BD
                cmd.Parameters.AddWithValue("@Imie", c.Imie);
                cmd.Parameters.AddWithValue("@Nazwisko", c.Nazwisko);
                cmd.Parameters.AddWithValue("@Numer", c.Numer);
                cmd.Parameters.AddWithValue("@Adres", c.Adres);
                cmd.Parameters.AddWithValue("@Plec", c.Plec);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //jesli zapytanie się powiedzie do wartości bedą >0 a jesli nie to =0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Update(wizytowkaclass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Zapytanie SQL
                string sql = "UPDATE tbl_contact SET Imie=@Imie, Nazwisko=@Nazwisko, Numer=@Numer, Adres=@Adres, Plec=@Plec WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Imie", c.Imie);
                cmd.Parameters.AddWithValue("@Nazwisko", c.Nazwisko);
                cmd.Parameters.AddWithValue("@Numer", c.Numer);
                cmd.Parameters.AddWithValue("@Adres", c.Adres);
                cmd.Parameters.AddWithValue("@Plec", c.Plec);
                cmd.Parameters.AddWithValue("ID", c.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Delete(wizytowkaclass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM tbl_contact WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        
    }
}
