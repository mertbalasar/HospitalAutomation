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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.PasswordChar = '\0';
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            } else
            {
                textBox1.PasswordChar = '●';
                textBox2.PasswordChar = '●';
                textBox3.PasswordChar = '●';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanıcıadı = Properties.Settings.Default.kullanıcıAdı;
            string eskik = Properties.Settings.Default.şifre;
            string eski = textBox1.Text;
            string yeni = textBox2.Text;
            string yenit = textBox3.Text;
            if (eski == "" || yeni == "" || yenit == "")
            {
                MessageBox.Show("Alanlardan birisi bile boş bırakılamaz", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (yeni != yenit)
                {
                    MessageBox.Show("Şifre ve tekrarı uyuşmuyor", "Yanlış Şifre Tekrarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    if (eskik != eski)
                    {
                        MessageBox.Show("Eski şifrenizi yanlış girdiniz", "Yanlış Şifre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        YönetimDb db = new YönetimDb();
                        foreach (var kullanıcı in db.Kullanıcılar)
                        {
                            if (kullanıcıadı == kullanıcı.KullanıcıAdı)
                            {
                                kullanıcı.Şifre = yeni;
                                break;
                            }
                        }
                        db.SaveChanges();
                        MessageBox.Show("Şifreniz başarıyla değiştirildi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }
    }
}
