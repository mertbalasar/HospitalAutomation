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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hastane yetkilileri tarafından kayıt için gerekli olan 9 haneli algoritmik koddur.");
        }

        public static bool Onay_Kodu_Kontrol(string onaykodu)
        {
            bool eşleşti = true;
            if (onaykodu.Length == 9)
            {
                if ((Char.GetNumericValue(onaykodu[0]) * Char.GetNumericValue(onaykodu[1])) % 10 != Char.GetNumericValue(onaykodu[2]))
                {
                    eşleşti = false;
                }
                if ((Char.GetNumericValue(onaykodu[3]) * Char.GetNumericValue(onaykodu[4])) % 10 != Char.GetNumericValue(onaykodu[5]))
                {
                    eşleşti = false;
                }
                if ((Char.GetNumericValue(onaykodu[6]) * Char.GetNumericValue(onaykodu[7])) % 10 != Char.GetNumericValue(onaykodu[8]))
                {
                    eşleşti = false;
                }
            }
            else
            {
                eşleşti = false;
            }
            return eşleşti;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            foreach (Form _f in Application.OpenForms)
            {
                if (_f.Name == "Form1")
                {
                    f1 = (Form1)_f;
                }
            }
            f1.Enabled = false;
        }

        private void Form2_Closing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            foreach (Form _f in Application.OpenForms)
            {
                if (_f.Name == "Form1")
                {
                    f1 = (Form1)_f;
                }
            }
            f1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı adı boş bırakılamaz", "Kullanıcı Adı Boş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Şifre boş bırakılamaz", "Şifre Boş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("Şifre tekrar alanı boş bırakılamaz", "Şifre Tekrarı Boş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Onay kodu boş bırakılamaz", "Onay Kodu Boş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (textBox2.Text != textBox3.Text)
                            {
                                MessageBox.Show("Şifre tekrarı eşleşmedi", "Şifreler Eşleşmiyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (Onay_Kodu_Kontrol(textBox4.Text) == false)
                                {
                                    MessageBox.Show("Onay kodunuz yanlış", "Onay Kodu Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    // KULLANICI ADININ VAR OLUP OLMADIĞINI KONTROL ETTİR
                                    YönetimDb db = new YönetimDb();
                                    bool varmı = false;
                                    foreach (var eleman in db.Kullanıcılar)
                                    {
                                        if (eleman.KullanıcıAdı == textBox1.Text)
                                        {
                                            MessageBox.Show("Kullanıcı adı kullanımda", "Kullanıcı Adı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            varmı = true;
                                            break;
                                        }
                                    }
                                    if (varmı == false)
                                    {
                                        Kullanıcılar kullanıcı = new Kullanıcılar();
                                        kullanıcı.KullanıcıAdı = textBox1.Text;
                                        kullanıcı.Şifre = textBox2.Text;
                                        db.Kullanıcılar.Add(kullanıcı);
                                        db.SaveChanges();
                                        MessageBox.Show("Kayıt başarıyla tamamlandı", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    /*bağlantı = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=" + veriTabanıİsmi + "; Integrated Security=True");
                                    bağlantı.Open();
                                    adaptör = new SqlDataAdapter("SELECT kullanıcıadı FROM kullanıcılar", bağlantı);
                                    tablo = new DataTable();
                                    adaptör.Fill(tablo);
                                    bool varmı = false;
                                    for (int i = 0; i < tablo.Rows.Count; i++)
                                    {
                                        if (tablo.Rows[i]["kullanıcıadı"].ToString() == textBox1.Text)
                                        {
                                            MessageBox.Show("Kullanıcı adı kullanımda", "Kullanıcı Adı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            varmı = true;
                                            break;
                                        }
                                    }
                                    bağlantı.Close();
                                    if (varmı == false)
                                    {
                                        bağlantı = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=" + veriTabanıİsmi + "; Integrated Security=True");
                                        bağlantı.Open();
                                        komut = new SqlCommand();
                                        komut.Connection = bağlantı;
                                        komut.CommandText = "INSERT INTO kullanıcılar (kullanıcıadı, şifre) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
                                        komut.ExecuteNonQuery();
                                        bağlantı.Close();
                                        MessageBox.Show("Kayıt başarıyla tamamlandı", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();*/
                                    }
                                }
                            }
                        }
                    }
                }
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '●';
                textBox3.PasswordChar = '●';
            }
        }
    }
}
