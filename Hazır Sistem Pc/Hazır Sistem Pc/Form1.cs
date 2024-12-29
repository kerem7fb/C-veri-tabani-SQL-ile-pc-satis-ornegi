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
namespace Hazır_Sistem_Pc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection yeni = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\10-M\\Hazır Sistem Pc\\HazrSistem.mdb");
        public void görüntüle() 
        {
            yeni.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From HazırSistem", yeni);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            yeni.Close();
            görüntüle();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            görüntüle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Insert into HazırSistem(PcNo,Marka,EkraKarti,İşlemci,Ram,Monitor,Anakart) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "')", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Delete From HazırSistem Where PcNo='"+textBox1.Text+"'",yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Update HazırSistem Set Marka='" + comboBox1.Text + "',EkraKarti='" + comboBox2.Text + "',İşlemci='" + comboBox3.Text + "',Ram='" + comboBox4.Text + "',Monitor='" + comboBox6.Text + "',Anakart='" + comboBox7.Text + "' Where PcNo='"+textBox1.Text+"'",yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
        }
    }
}
