using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            YönetimDb db = new YönetimDb();
            db.Database.CreateIfNotExists();
            label3.Location = new Point(178, 140);
            if (Properties.Settings.Default.kullanıcıAdı != "" && Properties.Settings.Default.şifre != "")
            {
                textBox1.Text = Properties.Settings.Default.kullanıcıAdı;
                textBox2.Text = Properties.Settings.Default.şifre;
            }
            if (Properties.Settings.Default.beniHatırla == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.beniHatırla = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.kullanıcıAdı = null;
                Properties.Settings.Default.şifre = null;
                Properties.Settings.Default.beniHatırla = false;
                Properties.Settings.Default.Save();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanıcıAdı = textBox1.Text;
            string şifre = textBox2.Text;
            bool hataVar = true;

            YönetimDb db = new YönetimDb();
            foreach (var eleman in db.Kullanıcılar)
            {
                if (eleman.KullanıcıAdı == kullanıcıAdı)
                {
                    if (eleman.Şifre == şifre)
                    {
                        hataVar = false;
                        if (checkBox1.Checked == true)
                        {
                            Properties.Settings.Default.kullanıcıAdı = kullanıcıAdı;
                            Properties.Settings.Default.şifre = şifre;
                            Properties.Settings.Default.Save();
                        }
                        Form3 f3 = new Form3();
                        f3.kullanıcıAdı = textBox1.Text;
                        f3.Show();
                        this.Hide();
                    }
                }
            }

            if (hataVar == true)
            {
                label3.Location = new Point(178, 112);
            }
        }
    }
}
