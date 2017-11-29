using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kayitİslemi
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        //static string conString = "Server=WISSEN-PC;Database=TelRehberi;Uid=sa;Password=1234;";
        //SqlConnection baglanti = new SqlConnection(conString);

        TelRehberiEntities db = new TelRehberiEntities();
      
        void doldur()
        {

            LstKayitlar.DataSource = db.Kisiler.ToList();
            LstKayitlar.DisplayMember = "KisiAdi";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Kisiler kisiler = new Kisiler();
            kisiler.KisiAdi = textBox1.Text;
            kisiler.KisiSoyadi = textBox2.Text;
            kisiler.TelefonNumarasi = textBox3.Text;
            db.Kisiler.Add(kisiler);
            db.SaveChanges();
            doldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doldur();
        }
        Kisiler secili;
        private void button2_Click(object sender, EventArgs e)
        {
            secili = (Kisiler)LstKayitlar.SelectedItem;
            var guncellenecek = db.Kisiler.Where(w => w.KisiID == secili.KisiID).FirstOrDefault();
            guncellenecek.KisiAdi = textBox1.Text;
            guncellenecek.KisiSoyadi = textBox2.Text;
            guncellenecek.TelefonNumarasi = textBox3.Text;
            db.SaveChanges();
            doldur();
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            secili = (Kisiler)LstKayitlar.SelectedItem;
            var silinecekkisi = db.Kisiler.Where(w => w.KisiID == secili.KisiID).FirstOrDefault();
            db.Kisiler.Remove(silinecekkisi);
            db.SaveChanges();
            doldur();
        }
    }
}
