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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Gönderen maili boş bırakılamaz", "Gönderen Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Gönderen şifresi boş bırakılamaz", "Gönderen Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("Gönderilen maili boş bırakılamaz", "Gönderilen Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        Properties.Settings.Default.gönderenMail = textBox1.Text;
                        Properties.Settings.Default.gönderenŞifre = textBox2.Text;
                        Properties.Settings.Default.gönderilenMail = textBox3.Text;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.gönderenMail;
            textBox2.Text = Properties.Settings.Default.gönderenŞifre;
            textBox3.Text = Properties.Settings.Default.gönderilenMail;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            } else
            {
                textBox2.PasswordChar = '●';
            }
        }
    }
}
