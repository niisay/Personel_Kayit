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

namespace Personel_Kayit
{
    public partial class Frmistatistik: Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=YAVUZ\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count (*) From PersonelTablosu", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //evli personel sayısı
            baglanti.Open();
            SqlCommand Komut2 = new SqlCommand("Select count (*) From PersonelTablosu where PerDurum=1", baglanti);
            SqlDataReader dr2 = Komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvli.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //bekar personel sayısı için
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count (*) From PersonelTablosu where PerDurum = 0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekar.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Şehir için
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count (distinct (PerSehir)) From PersonelTablosu",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(PerMaas) From PersonelTablosu", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ort maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select avg(PerMaas) From PersonelTablosu", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
