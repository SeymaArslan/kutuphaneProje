using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Kutuphane
{
    public partial class Form1 : Form
    {
        public string baglantiYolu = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\emre\Desktop\c#\kütüphane\kutuphane.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            
            string sql = "select * from Personel where Username=@pusername and Password=@pPassword";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pusername", textBox1.Text.ToString());
            komut.Parameters.AddWithValue("@pPassword", textBox2.Text.ToString());
            SqlDataReader okuyucu = komut.ExecuteReader();
            if(okuyucu.Read())
            {
                
                        this.Hide();
                        Form2 frm2 = new Form2();
                        frm2.Show();
                    
                }
                else
                {
                    label3.Text = "Kullanıcı Adı ve/veya Şifre yanlış!";
                    textBox1.Clear();
                    textBox2.Clear();
                }
              baglanti.Close();
            }
        }

    }

