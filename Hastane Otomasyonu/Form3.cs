using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using Laboratuvar;

namespace Hastane_Otomasyonu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string kullanıcıAdı = "";

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            foreach (Form _f in Application.OpenForms)
            {
                if (_f.Name == "Form1")
                {
                    f1 = (Form1)_f;
                }
            }
            f1.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Hoşgeldin" + Environment.NewLine + kullanıcıAdı;
            dateTimePicker1.MaxDate = DateTime.Now.Date;
            dateTimePicker2.MinDate = DateTime.Now.Date;
        }

        private void Form3_SizeChanged(object sender, EventArgs e)
        {
            int en = 882;
            int boy = 445;
            int enFark = this.Size.Width - en;
            int boyFark = this.Size.Height - boy;

            pictureBox1.Height = 392 + boyFark;
            pictureBox5.Width = 590 + enFark;
            pictureBox6.Width = 590 + enFark;
            pictureBox7.Width = 590 + enFark;
            pictureBox8.Width = 590 + enFark;
            pictureBox9.Width = 590 + enFark;
            pictureBox10.Width = 590 + enFark;
            pictureBox11.Width = 590 + enFark;
            pictureBox12.Width = 590 + enFark;
            pictureBox13.Width = 590 + enFark;
            pictureBox14.Width = 590 + enFark;
            pictureBox15.Width = 590 + enFark;
            tabControl1.Width = 652 + enFark;
            tabControl1.Height = 421 + boyFark;
            panel2.Width = 637 + enFark;
            panel2.Height = 356 + boyFark;
            panel3.Width = 634 + enFark;
            panel3.Height = 359 + boyFark;
            panel4.Width = 634 + enFark;
            panel4.Height = 359 + boyFark;
        }

        public bool Randevu_Kontrol()
        {
            bool doluluk = false;
            string saat;
            string dakika;
            YönetimDb db = new YönetimDb();
            foreach (var eleman in db.Hastalar)
            {
                saat = eleman.RandevuSaati.Split(':')[0];
                dakika = eleman.RandevuSaati.Split(':')[1];
                if (eleman.RandevuTarihi == dateTimePicker2.Value && saat == comboBox8.Text && dakika == comboBox9.Text && eleman.Bölüm == comboBox10.Text)
                {
                    doluluk = true;
                }
            }
            return doluluk;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            dateTimePicker1.MaxDate = DateTime.Now.Date;
            dateTimePicker2.MinDate = DateTime.Now.Date;
            this.Text = "Hastane Otomasyonu [Mert Balasar] - Hasta Kayıt";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            this.Text = "Hastane Otomasyonu [Mert Balasar] - Hasta Sorgulama";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            this.Text = "Hastane Otomasyonu [Mert Balasar] - Laboratuvar Sonucu";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text[0].ToString().ToUpper() + textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                textBox1.Text = textBox1.Text[0] + textBox1.Text.Substring(1, textBox1.Text.Length - 1).ToLower();
            }
            else if (textBox1.Text.Length == 1)
                textBox1.Text = textBox1.Text[0].ToString().ToUpper();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 1)
            {
                textBox2.Text = textBox2.Text[0].ToString().ToUpper() + textBox2.Text.Substring(1, textBox2.Text.Length - 1);
                textBox2.Text = textBox2.Text[0] + textBox2.Text.Substring(1, textBox2.Text.Length - 1).ToLower();
            }
            else if (textBox2.Text.Length == 1)
                textBox2.Text = textBox2.Text[0].ToString().ToUpper();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt64(textBox3.Text);
            } catch
            {
                textBox3.Text = "";
            }
            if (textBox3.Text.Length != 11)
            {
                textBox3.Text = "";
            }
        }

        public int ücret;

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox11.Items.Clear();
            string[] doktorlar = {"Gülizar Emin", "Hakan Şahlı", "Ayhan Bileci", "Ekin Hamidiye", "Gizem Geleli",
            "Faruk Boylu", "Emin Şanlı", "Erdem Sami Aşar", "Gamze Dağdelen", "İrem Gelibol", "Cemil Sever",
            "Aras Saha", "Sevcan Sevil", "Cihan Dolunay", "Vedat Semih Sağ", "Salih Uyuyan", "Mert Çiçek",
            "Tamer Tarafsız", "Deniz Binnur Kaya", "Çağatay Akar", "Hakan Uzun", "Emine Kısa", "Arda Durdu",
            "Metin Yazıcı", "Ali Kaçak", "Ogün Soyak", "Kürşat Bedih", "Erkan Erdal", "Doğuş Güner",
            "Alp Arda Emin", "Selçuk Ayakta", "Hale Karadağ", "Feride Mermer", "Ferhunde Mermer", "Gülcan Kayaoğlu",
            "Emre Semih Dörtler", "Gülşen Yıldırım", "Esra Şimşek", "Betül Altınışık", "Halime Gümüş", "Mert Dolar",
            "Nazmi Hayırsever", "Hikmet Arasoğlu", "Osman Kısta", "Elif Candan Leylek", "Hasan Giray", "Jale Evir",
            "Bedirhan Zara", "Kamile Karyutan", "Pelin Dişçioğlu", "Gönül Atasoy", "Ferhat Sızlar"};
            comboBox11.Enabled = true;
            comboBox11.Items.Add(doktorlar[comboBox10.SelectedIndex]);
            if (comboBox10.SelectedIndex >= 0 && comboBox10.SelectedIndex < 20)
            {
                label17.Text = "80 TL";
                ücret = 80;
            }
            if (comboBox10.SelectedIndex >= 20 && comboBox10.SelectedIndex < 40)
            {
                label17.Text = "120 TL";
                ücret = 120;
            }
            if (comboBox10.SelectedIndex >= 40 && comboBox10.SelectedIndex < 52)
            {
                label17.Text = "150 TL";
                ücret = 150;
            }
        }

        public bool Hasta_Kayıtlımı(long tcNo)
        {
            bool kayıt = false;
            YönetimDb db = new YönetimDb();
            foreach (var satır in db.Hastalar)
            {
                if (satır.TCNo == tcNo)
                {
                    kayıt = true;
                }
            }
            return kayıt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ad boş bırakılamaz", "Ad Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Soyad boş bırakılamaz", "Soyad Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    if (comboBox1.Text == "")
                    {
                        MessageBox.Show("Cinsiyet boş bırakılamaz", "Cinsiyet Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        if (textBox3.Text == "")
                        {
                            MessageBox.Show("T.C. Numarası boş bırakılamaz", "T.C. Numara Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } else
                        {
                            if (comboBox8.Text == "" || comboBox9.Text == "")
                            {
                                MessageBox.Show("Randevu Saati boş bırakılamaz", "Randevu Saati Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            } else
                            {
                                if (comboBox10.Text == "")
                                {
                                    MessageBox.Show("Bölüm boş bırakılamaz", "Bölüm Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                } else
                                {
                                    if (comboBox11.Text == "")
                                    {
                                        MessageBox.Show("Doktor boş bırakılamaz", "Doktor Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    } else
                                    {
                                        if (Hasta_Kayıtlımı(Convert.ToInt64(textBox3.Text)) == true)
                                        {
                                            MessageBox.Show("Hasta zaten kayıtlı", "Kayıtlı Hasta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        } else
                                        {
                                            if (Randevu_Kontrol() == true)
                                            {
                                                MessageBox.Show("Seçtiğiniz tarih ve bölüm için randevu alınmış", "Randevu Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            } else
                                            {
                                                bool hatalı = false;
                                                if (dateTimePicker2.Value.Date == DateTime.Now.Date)
                                                {
                                                    if (Convert.ToInt32(comboBox8.SelectedItem) <= DateTime.Now.Hour)
                                                    {
                                                        if (Convert.ToInt32(comboBox9.SelectedItem) <= DateTime.Now.Minute)
                                                        {
                                                            MessageBox.Show("Geçmişten randevu alamazsınız", "Randevu Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            hatalı = true;
                                                        }
                                                    }
                                                }
                                                if (hatalı == false)
                                                {
                                                    // KAYIT KISMI
                                                    YönetimDb db = new YönetimDb();
                                                    Hastalar hasta = new Hastalar();
                                                    hasta.Ad = textBox1.Text;
                                                    hasta.Soyad = textBox2.Text;
                                                    hasta.Cinsiyet = comboBox1.Text;
                                                    hasta.TCNo = Convert.ToInt64(textBox3.Text);
                                                    hasta.DoğumTarihi = dateTimePicker1.Value;
                                                    hasta.RandevuTarihi = dateTimePicker2.Value;
                                                    hasta.RandevuSaati = comboBox8.Text + ":" + comboBox9.Text;
                                                    hasta.Bölüm = comboBox10.Text;
                                                    hasta.Doktor = comboBox11.Text;
                                                    hasta.Ücret = ücret;
                                                    db.Hastalar.Add(hasta);
                                                    db.SaveChanges();
                                                    // MAİL KISMI
                                                    if (checkBox1.Checked == true)
                                                    {
                                                        MailMessage mail = new MailMessage();
                                                        mail.From = new MailAddress(Properties.Settings.Default.gönderenMail);
                                                        mail.To.Add(Properties.Settings.Default.gönderilenMail);
                                                        mail.Subject = "Hastane Otomasyonu Mert Balasar";
                                                        mail.Body = textBox3.Text + " T.C. Numaralı şahıs " + comboBox10.Text + " bölümünden " +
                                                            dateTimePicker2.Value.ToString().Substring(0, 10) + " " + comboBox8.Text + ":" + comboBox9.Text +
                                                            " tarihinde randevu almıştır.";
                                                        SmtpClient istemci = new SmtpClient();
                                                        istemci.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.gönderenMail, Properties.Settings.Default.gönderenŞifre);
                                                        istemci.Port = 587;
                                                        istemci.Host = "smtp.gmail.com";
                                                        istemci.EnableSsl = true;
                                                        try
                                                        {
                                                            istemci.SendAsync(mail, (object)mail);
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Mail gönderme başarısız", "Mail Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                    MessageBox.Show("Randevu Başarıyla Alındı", "Randevu Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button9.Enabled = false;
            button10.Enabled = false;
            long tcNo;
            bool hata = false;
            try
            {
                tcNo = Convert.ToInt64(textBox4.Text);
            } catch
            {
                MessageBox.Show("Hatalı T.C. Numarası girdisi", "Karakter Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hata = true;
            }
            if (hata == false)
            {
                tcNo = Convert.ToInt64(textBox4.Text);
                YönetimDb db = new YönetimDb();
                bool bulundu = false;
                foreach (var hasta in db.Hastalar)
                {
                    if (hasta.TCNo == tcNo)
                    {
                        textBox11.Text = hasta.ID.ToString();
                        textBox12.Text = hasta.Ad;
                        textBox13.Text = hasta.Soyad;
                        textBox14.Text = hasta.Cinsiyet;
                        textBox15.Text = hasta.DoğumTarihi.ToString().Substring(0, 10);
                        textBox16.Text = hasta.TCNo.ToString();
                        textBox17.Text = hasta.RandevuTarihi.ToString().Substring(0, 10);
                        textBox18.Text = hasta.RandevuSaati;
                        textBox19.Text = hasta.Bölüm;
                        textBox20.Text = hasta.Doktor;
                        textBox21.Text = hasta.Ücret.ToString();
                        string kalan = (hasta.RandevuTarihi.Date - DateTime.Now.Date).Days.ToString();
                        if (kalan == "0")
                        {
                            textBox22.Text = "Randevu bugün";
                        } else if (kalan.StartsWith("-"))
                        {
                            textBox22.Text = "Randevu geçmiş";
                        } else
                        {
                            textBox22.Text = kalan + " gün kaldı";
                        }
                        bulundu = true;
                        button9.Enabled = true;
                        button10.Enabled = true;
                    }
                }
                if (bulundu == false)
                {
                    MessageBox.Show("Hasta kayıtlarda bulunamadı", "Hasta Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox15.Text = "";
                    textBox16.Text = "";
                    textBox17.Text = "";
                    textBox18.Text = "";
                    textBox19.Text = "";
                    textBox20.Text = "";
                    textBox21.Text = "";
                    textBox22.Text = "";
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            button9.Enabled = false;
            button10.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(textBox4.Text + " T.C. Numaralı hastayı silmek istediğinize emin misiniz?", "Silmek İstiyor Musunuz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                YönetimDb db = new YönetimDb();
                foreach (var hasta in db.Hastalar)
                {
                    if (hasta.TCNo == Convert.ToInt64(textBox4.Text))
                    {
                        db.Hastalar.Remove(hasta);
                    }
                }
                db.SaveChanges();
                MessageBox.Show("Silme işlemi başarıyla tamamlandı", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
                textBox22.Text = "";
                button10.Enabled = false;
                button9.Enabled = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            textBox30.Text = Properties.Settings.Default.tahlilYolu;
            this.Text = "Hastane Otomasyonu [Mert Balasar] - Laboratuvar Girişi";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.tahlilYolu = folderBrowserDialog1.SelectedPath;
                textBox30.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bool hataVar = false;
            try
            {
                Convert.ToInt64(textBox29.Text);
            } catch
            {
                MessageBox.Show("T.C. Numarasına yanlış karakterler girdiniz", "Hatalı Karakterler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hataVar = true;
            }

            if (hataVar == false)
            {
                YönetimDb db = new YönetimDb();
                bool hastaVar = false;
                foreach (var hasta in db.Hastalar)
                {
                    if (hasta.TCNo == Convert.ToInt64(textBox29.Text))
                    {
                        hastaVar = true;
                        break;
                    }
                }
                if (hastaVar == false)
                {
                    MessageBox.Show("Girdiğiniz T.C. Numarasında hasta bulunamadı", "Hasta Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    textBox31.Text = textBox29.Text;
                }
            }
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox32.Text == "" || textBox33.Text == "")
                {
                    MessageBox.Show("Değer veya Miktar boş bırakılamaz", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    listBox1.Items.Add(textBox32.Text + "=" + textBox33.Text);
                    textBox32.Text = "";
                    textBox33.Text = "";
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string değer = listBox1.SelectedItem.ToString().Split('=')[0];
                string miktar = listBox1.SelectedItem.ToString().Split('=')[1];
                textBox32.Text = değer;
                textBox33.Text = miktar;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox29.Text == "")
            {
                MessageBox.Show("T.C. Numarası boş bırakılamaz", "T.C. Numarası Boş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (textBox30.Text == "")
                {
                    MessageBox.Show("Dosya Yolu boş bırakılamaz", "Dosya Yolu Boş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    if (textBox31.Text == "")
                    {
                        MessageBox.Show("Dosya Adı boş bırakılamaz", "Dosya Adı Boş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        if (listBox1.Items.Count == 0)
                        {
                            MessageBox.Show("Kan Değerleri boş bırakılamaz", "Kan Değerleri Boş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } else
                        {
                            bool hataVar = false;
                            try
                            {
                                File dosya = new File();
                                dosya.Path = textBox30.Text;
                                dosya.FileName = textBox31.Text;
                                dosya.CreateFile();
                                foreach (string değer in listBox1.Items)
                                {
                                    dosya.WriteFile(değer);
                                }
                            } catch
                            {
                                hataVar = true;
                                MessageBox.Show("Kayıtta bir hata oluştu", "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (hataVar == false)
                            {
                                MessageBox.Show("Laboratuvar girişi başarıyla tamamlandı", "Başarılı Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                listBox1.Items.Clear();
                                textBox32.Text = "";
                                textBox33.Text = "";
                            }
                        }
                    }
                }
            }
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox32.Text == "" || textBox33.Text == "")
                {
                    MessageBox.Show("Değer veya Miktar boş bırakılamaz", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    listBox1.Items.Add(textBox32.Text + "=" + textBox33.Text);
                    textBox32.Text = "";
                    textBox33.Text = "";
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bool hataVar = false;
            try
            {
                Convert.ToInt64(textBox34.Text);
            }
            catch
            {
                MessageBox.Show("T.C. Numarasına yanlış karakterler girdiniz", "Hatalı Karakterler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hataVar = true;
            }

            if (hataVar == false)
            {
                YönetimDb db = new YönetimDb();
                bool hastaVar = false;
                foreach (var hasta in db.Hastalar)
                {
                    if (hasta.TCNo == Convert.ToInt64(textBox34.Text))
                    {
                        hastaVar = true;
                        break;
                    }
                }
                if (hastaVar == false)
                {
                    MessageBox.Show("Girdiğiniz T.C. Numarasında hasta bulunamadı", "Hasta Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool hataVar2 = false;
                    File dosya = new File();
                    dosya.Path = Properties.Settings.Default.tahlilYolu;
                    dosya.FileName = textBox34.Text;
                    try
                    {
                        dosya.ReadFile();
                    } catch
                    {
                        hataVar2 = true;
                        MessageBox.Show(textBox34.Text + " T.C. Numaralı hastanın tahlili bulunamadı veya Tahlil Yolu değişmiş olabilir", "Tahlil Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (hataVar2 == false)
                    {
                        foreach (string içerik in dosya.ReadFile().Split('\n'))
                        {
                            listBox2.Items.Add(içerik);
                        }
                        button17.Enabled = true;
                        button16.Enabled = true;
                    }
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            button16.Enabled = false;
            button17.Enabled = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool hataVar = false;
                File dosya = new File();
                dosya.Path = Properties.Settings.Default.tahlilYolu;
                dosya.FileName = textBox34.Text;
                try
                {
                    dosya.DeleteFile();
                } catch
                {
                    hataVar = true;
                    MessageBox.Show("Silmeyle ilgili bir sorun oluştu", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (hataVar == false)
                {
                    MessageBox.Show("Silme işlemi başarıyla gerçekleşti", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBox2.Items.Clear();
                    button16.Enabled = false;
                    button17.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Settings.Default.kullanıcıAdı + " kullanıcı adındaki hesabınızı silmek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                YönetimDb db = new YönetimDb();
                foreach (var kullanıcı in db.Kullanıcılar)
                {
                    if (kullanıcı.KullanıcıAdı == Properties.Settings.Default.kullanıcıAdı)
                    {
                        db.Kullanıcılar.Remove(kullanıcı);
                        Properties.Settings.Default.kullanıcıAdı = null;
                        Properties.Settings.Default.şifre = null;
                        Properties.Settings.Default.beniHatırla = false;
                        Properties.Settings.Default.Save();
                        break;
                    }
                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
    }
}
