using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OleDB.4.0; Data Source=C:\\Users\\Akın\\Desktop\\Database1.mdb");
        OleDbDataAdapter da;

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            da = new OleDbDataAdapter("Select * From apartman", con);
            da.Fill(dt);
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            textBox1.DataBindings.Add("Text", bs, "Kimlik");
            textBox2.DataBindings.Add("Text", bs, "Ad");
            textBox3.DataBindings.Add("Text", bs, "Soyad");
            textBox4.DataBindings.Add("Text", bs, "Daire");
            textBox5.DataBindings.Add("Text", bs, "Tel");
            textBox6.DataBindings.Add("Text", bs, "SahipKira");
            textBox7.DataBindings.Add("Text", bs, "Borc");
            dataGridView1.ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            bs.AddNew();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string ins = "insert into apartman(Ad, Soyad, Daire, Tel, SahipKira, Borc) values(@ad, @soyad, @daire, @tel, @sahipkira, @borc)";


            OleDbCommand com = new OleDbCommand(ins, con);
            con.Open();
            com.Parameters.AddWithValue("@ad", textBox2.Text);
            com.Parameters.AddWithValue("@soyad", textBox3.Text);
            com.Parameters.AddWithValue("@daire", textBox4.Text);
            com.Parameters.AddWithValue("@tel", textBox5.Text);
            com.Parameters.AddWithValue("@sahipkira", textBox6.Text);
            com.Parameters.AddWithValue("@borc", textBox7.Text);
            com.ExecuteNonQuery();
            con.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            string up = ("update apartman set Ad'" + textBox2.Text + "',Soyad'" + textBox3.Text + "',Daire'" + textBox4.Text + "',Tel'" + textBox5.Text + "',SahipKira'" + textBox6.Text + "',Borc'" + textBox7.Text);
            OleDbCommand com = new OleDbCommand(up, con);
            con.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            string del = ("delete from apartman where Kimlik = " + textBox1.Text + "");
            OleDbCommand com = new OleDbCommand(del, con);
            com.ExecuteNonQuery();
            con.Close();

        }
    }
}
