using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ewizytowkaklasy;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        wizytowkaclass c = new wizytowkaclass();
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Wyczyść
            Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            // pobierz wartość z pola
            c.Imie = Imie.Text;
            c.Nazwisko = Nazwisko.Text;
            c.Numer = Numer_telefonu.Text;
            c.Adres = Adres.Text;
            c.Plec = Plec.Text;
            //dodawanie danych do BD
            bool success = c.Insert(c);
            if(success=true)
            {
                MessageBox.Show("Nowy kontakt został dodany");
                Clear();
            }
            else
            {
                MessageBox.Show("Nie udało się dodać kontaktu");
            }
            DataTable dt = c.Select();
            dgvWizytowka.DataSource = dt;
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //wyświetl dane
            DataTable dt = c.Select();
            dgvWizytowka.DataSource = dt;
        }
        public void Clear()
        {
            ID.Text = "";
            Imie.Text = "";
            Nazwisko.Text= "";
            Numer_telefonu.Text= "";
            Adres.Text= "";
            Plec.Text= "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Aktualizuj
            c.ID = int.Parse(ID.Text);
            c.Imie = Imie.Text;
            c.Nazwisko = Nazwisko.Text;
            c.Numer = Numer_telefonu.Text;
            c.Adres = Adres.Text;
            c.Plec = Plec.Text;
            bool success = c.Update(c);
            if (success = true)
            {
                MessageBox.Show("kontakt został zaktualizowany");
                DataTable dt = c.Select();
                dgvWizytowka.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Nie udało się zaktualizować kontaktu");
            }
            
        }

        private void dgvWizytowka_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            ID.Text = dgvWizytowka.Rows[rowIndex].Cells[0].Value.ToString();
            Imie.Text = dgvWizytowka.Rows[rowIndex].Cells[1].Value.ToString();
            Nazwisko.Text = dgvWizytowka.Rows[rowIndex].Cells[2].Value.ToString();
            Numer_telefonu.Text = dgvWizytowka.Rows[rowIndex].Cells[3].Value.ToString();
            Adres.Text = dgvWizytowka.Rows[rowIndex].Cells[4].Value.ToString();
            Plec.Text = dgvWizytowka.Rows[rowIndex].Cells[5].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.ID = Convert.ToInt32(ID.Text);
            bool success = c.Delete(c);
            if(success==true)
            {
                MessageBox.Show("Udało się usunąć kontakt");
                DataTable dt = c.Select();
                dgvWizytowka.DataSource = dt;
                Clear();
            }    
            else
            {
                MessageBox.Show("Nie duało się usunąć kontaktu");
            }
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox3.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter ananas = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE Imie LIKE '%" + keyword + "%' OR Nazwisko LIKE '%" + keyword + "%' OR Adres LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            ananas.Fill(dt);
            dgvWizytowka.DataSource = dt;
        }
    }
}
