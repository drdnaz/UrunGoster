using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
namespace urunGosterir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public class Urun
        {
            public string UrunAdi { get; set; }
            public decimal Fiyat { get; set; }
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            string dosyaYolu = "urunler.json";

            if (File.Exists(dosyaYolu))
            {
                string jsonString = File.ReadAllText(dosyaYolu);
                List<Urun> urunler = JsonSerializer.Deserialize<List<Urun>>(jsonString);

                lstUrunler.Items.Clear();

                foreach (Urun urun in urunler)
                {
                    lstUrunler.Items.Add($"Ürün: {urun.UrunAdi} - Fiyat: {urun.Fiyat} TL");
                }
            }
            else
            {
                MessageBox.Show("JSON dosyası bulunamadı.");
            }
        }
    }
}
