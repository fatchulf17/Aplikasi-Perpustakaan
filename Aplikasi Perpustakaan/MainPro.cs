using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aplikasi_Perpustakaan
{
    public partial class MainPro : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=FATCHULFAJRI\FATCHULFAJRI;Initial Catalog=Perpustakaan;Persist Security Info=True;User ID=sa;Password=Gensu1711");
        public MainPro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into (Transaksi) (NIM, Nama, Telepon, Alamat, JudulBK, Pengarang, Penerbit, TanggalPJM) values ('"+textBox1+"','"+textBox4+"','"+textBox3+"', '"+textBox2+"','"+textBox5+"','"+textBox6+"','"+textBox7+"','"+dateTimePicker1.Text+"')";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            MessageBox.Show("Successfull");
        }

        public void display_data()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Transaksi]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            koneksi.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
