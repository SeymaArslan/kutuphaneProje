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
    public partial class Form2 : Form
    {
        public string baglantiYolu = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\emre\Desktop\c#\kütüphane\kutuphane.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Form2()
        {
            InitializeComponent();
        }

        public void Ekle(string KitapAdi, string Turu, DateTime BasimTarihi, int BasimSayisi, string Yazari, string YayinEvi, int Adeti)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into Kitaplar values (@pKitapAdi,@pTuru,@pBasimTarihi,@pBasimSayisi,@pYazari,@pYayinEvi,@pAdeti)";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            SqlParameter p1 = new SqlParameter("@pKitapAdi", KitapAdi);
            komut.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@pTuru", Turu);
            komut.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@pBasimTarihi", BasimTarihi);
            komut.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@pBasimSayisi", BasimSayisi);
            komut.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@pYazari", Yazari);
            komut.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@pYayinEvi", YayinEvi);
            komut.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@pAdeti", Adeti);
            komut.Parameters.Add(p7);


            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int BasimSayisi;
            BasimSayisi = Convert.ToInt32(textBox4.Text);
            int Adeti;
            Adeti = Convert.ToInt32(textBox18.Text);
            
            Ekle(textBox1.Text, textBox2.Text, dateTimePicker1.Value, BasimSayisi, textBox5.Text, textBox6.Text,Adeti);
            MessageBox.Show("Eklendi"); 
        }
        public DataSet Bul(string KitapAdi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = " select * from Kitaplar where KitapAdi like @pKitapAdi+'%' ";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            SqlParameter p1 = new SqlParameter("@pKitapAdi", KitapAdi);
            komut.Parameters.Add(p1);

            SqlDataAdapter adaptor = new SqlDataAdapter(komut);


            DataSet bulunanlar = new DataSet();
            baglanti.Open();
            adaptor.Fill(bulunanlar);
            baglanti.Close();

            return bulunanlar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "update Kitaplar set KitapAdi=@pKitapAdi,Turu=@pTuru,BasimTarihi=@pBasimTarihi,BasimSayisi=@pBasimSayisi,Yazari=@pYazari,YayinEvi=@pYayinEvi,Adeti=@pAdeti where KitapID=@pKitapID";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            komut.Parameters.AddWithValue("@pKitapAdi", textBox3.Text);
            komut.Parameters.AddWithValue("@pTuru", textBox7.Text);
            komut.Parameters.AddWithValue("@pBasimTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@pBasimSayisi", textBox8.Text);
            komut.Parameters.AddWithValue("@pYazari", textBox9.Text);
            komut.Parameters.AddWithValue("@pYayinEvi", textBox10.Text);
            komut.Parameters.AddWithValue("@pAdeti", textBox19.Text);

            int KitapID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pKitapID", KitapID);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Kitaplar where KitapID=@pKitapID";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            int KitapID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pKitapID", KitapID);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silindi");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];
                int KitapID = (int)secilenSatir.Cells[0].Value;

                textBox3.Text = secilenSatir.Cells[1].Value.ToString();
                textBox7.Text = secilenSatir.Cells[2].Value.ToString();
                dateTimePicker1.Value= (DateTime)secilenSatir.Cells[3].Value;
                textBox8.Text = secilenSatir.Cells[4].Value.ToString();
                textBox9.Text = secilenSatir.Cells[5].Value.ToString();
                textBox10.Text = secilenSatir.Cells[6].Value.ToString();
                textBox18.Text = secilenSatir.Cells[7].Value.ToString();

            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = new DataSet();
            bulunanlar = Bul(textBox11.Text);
            dataGridView1.DataSource = bulunanlar.Tables[0];
        }
        public void Ekle2(string AdiSoyadi, int TelNum, string Adres)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into Kullanicilar values (@pAdiSoyadi,@pTelNum,@pAdres)";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            SqlParameter p1 = new SqlParameter("@pAdiSoyadi", AdiSoyadi);
            komut.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@pTelNum", TelNum);
            komut.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@pAdres", Adres);
            komut.Parameters.Add(p3);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int TelNum;
            TelNum = Convert.ToInt32(textBox13.Text);

            Ekle2(textBox12.Text, TelNum, textBox20.Text);
            MessageBox.Show("Eklendi");
        }
        public DataSet Bul2(string AdiSoyadi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = " select * from Kullanicilar where AdiSoyadi like @pAdiSoyadi+'%' ";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            SqlParameter p1 = new SqlParameter("@pAdiSoyadi", AdiSoyadi);
            komut.Parameters.Add(p1);
            

            SqlDataAdapter adaptor = new SqlDataAdapter(komut);


            DataSet bulunanlar2 = new DataSet();
            baglanti.Open();
            adaptor.Fill(bulunanlar2);
            baglanti.Close();

            return bulunanlar2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "update Kullanicilar set AdiSoyadi=@pAdiSoyadi,TelNum=@pTelNum,Adres=@pAdres where KullaniciID=@pKullaniciID";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            komut.Parameters.AddWithValue("@pAdiSoyadi", textBox14.Text);
            komut.Parameters.AddWithValue("@pTelNum", textBox15.Text);
            komut.Parameters.AddWithValue("@pAdres", textBox21.Text);
            

            int KullaniciID = (int)dataGridView2.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pKullaniciID", KullaniciID);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Kullanicilar where KullaniciID=@pKullaniciID";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            int KullaniciID = (int)dataGridView2.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pKullaniciID", KullaniciID);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silindi");
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow secilenSatir = dataGridView2.SelectedRows[0];
                int KullaniciID = (int)secilenSatir.Cells[0].Value;

                textBox14.Text = secilenSatir.Cells[1].Value.ToString();
                textBox15.Text = secilenSatir.Cells[2].Value.ToString();
                textBox21.Text = secilenSatir.Cells[3].Value.ToString();

            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar2 = new DataSet();
            bulunanlar2 = Bul2(textBox16.Text);
            dataGridView2.DataSource = bulunanlar2.Tables[0];
        }
        public DataSet KitapCek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from kitaplar";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            adaptor.SelectCommand = komut;

            DataSet Kitaplar = new DataSet();
            baglanti.Open();
            adaptor.Fill(Kitaplar);
            baglanti.Close();

            return Kitaplar;
        }
        public DataSet KullaniciCek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand();
            komut.CommandType = CommandType.Text;
            komut.Connection = baglanti;
            komut.CommandText = "select * from Kullanicilar";

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet Kullanicilar = new DataSet();
            baglanti.Open();
            adaptor.Fill(Kullanicilar);
            baglanti.Close();

            return Kullanicilar;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "KitapAdi";
            comboBox1.ValueMember = "KitapID";

            DataSet Kitaplar = new DataSet();
            Kitaplar = KitapCek();
            comboBox1.DataSource = Kitaplar.Tables[0];
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "AdiSoyadi";
            comboBox2.ValueMember = "KullaniciID";

            DataSet Kullanicilar = new DataSet();
            Kullanicilar = KullaniciCek();
            comboBox2.DataSource = Kullanicilar.Tables[0];
        }

        
        public void Ekle3(int KullaniciID,int KitapID , DateTime VerilisTarihi)
        
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "insert into VerilenKitaplar values (@pKullaniciID,@pKitapID,@pVerilisTarihi,null)";

            SqlParameter p1 = new SqlParameter("@pKullaniciID", KullaniciID);
            komut.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@pKitapID", KitapID);
            komut.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@pVerilisTarihi", VerilisTarihi);
            komut.Parameters.Add(p3);


            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int KitapID = (int)comboBox1.SelectedValue;
            int KullaniciID = (int)comboBox2.SelectedValue;
            Ekle3(KullaniciID, KitapID, dateTimePicker3.Value);
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand guncelle = new SqlCommand("update Kitaplar set Adeti= Adeti-1 where KitapID='" + comboBox1.SelectedValue + "'", baglanti);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Eklendi");
        }

        
        public DataSet Bul3(string AdiSoyadi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand("select VerilenID,AdiSoyadi,TelNum,KitapAdi,VerilisTarihi,TeslimTarihi from Kullanicilar inner join VerilenKitaplar on Kullanicilar.KullaniciID=VerilenKitaplar.KullaniciID inner join Kitaplar on VerilenKitaplar.KitapID=Kitaplar.KitapID where AdiSoyadi like @pAdiSoyadi+'%' ", baglanti);


            SqlParameter p1 = new SqlParameter("@pAdiSoyadi", AdiSoyadi);
            komut.Parameters.Add(p1);

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet bulunanlar3 = new DataSet();
            baglanti.Open();
            adaptor.Fill(bulunanlar3);
            baglanti.Close();

            return bulunanlar3;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar3 = new DataSet();
            bulunanlar3 = Bul3(textBox17.Text.ToString());
            dataGridView3.DataSource = bulunanlar3.Tables[0];
        }
        /*public void Ekle4(int KitapID, int KullaniciID, DateTime TeslimTarihi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "insert into VerilenKitaplar values (@pKitapID,@pKullaniciID,@pTeslimTarihi)";

            SqlParameter p1 = new SqlParameter("@pKitapID", KitapID);
            komut.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@pKullaniciID", KullaniciID);
            komut.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@pTeslimTarihi", TeslimTarihi);
            komut.Parameters.Add(p3);


            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }*/

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "update VerilenKitaplar set TeslimTarihi=@pTeslimTarihi where VerilenID=@pVerilenID";
            SqlCommand komut = new SqlCommand(sql, baglanti);


            komut.Parameters.AddWithValue("@pTeslimTarihi", dateTimePicker4.Value);
            

            int VerilenID = (int)dataGridView3.SelectedRows[0].Cells[0].Value;

            komut.Parameters.AddWithValue("@pVerilenID", VerilenID);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
            
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand guncelle = new SqlCommand("update Kitaplar set Adeti= Adeti+1 where KitapAdi='" + textBox23.Text + "'", baglanti);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı!");
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow secilenSatir = dataGridView3.SelectedRows[0];
                int VerilenID = (int)secilenSatir.Cells[0].Value;

                textBox22.Text = secilenSatir.Cells[1].Value.ToString();
                textBox23.Text = secilenSatir.Cells[3].Value.ToString();
                

            }
        }

       
    }
}
