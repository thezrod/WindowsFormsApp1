using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CryptoTest : Form
    {
        public CryptoTest()
        {
            InitializeComponent();
        }
        private bool Encrypting = true;
        private void encryptionButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text  = "Plain Text";
            label3.Text  = "Cipher Text";
            button1.Text = "Encrypt";
            Encrypting   = true;
        }

        private void decryptionButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text  = "Plain Text";
            label1.Text  = "Cipher Text";
            button1.Text = "Decrypt";
            Encrypting   = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (Encrypting)
                {
                    //textBox2.Text = c.Encrypt(textBox1.Text, textBox3.Text);
                    string cipher = SameAllTheTimeCipher.Encrypt(textBox1.Text, textBox2.Text);
                    textBox3.Text = cipher;
                }
                else
                {
                    // textBox2.Text = c.Decrypt(textBox1.Text, textBox3.Text);
                    string plainText = SameAllTheTimeCipher.Decrypt(textBox1.Text, textBox2.Text);
                    textBox3.Text = plainText;
                }
            }
            else
            {
                if (Encrypting)
                {
                    //textBox2.Text = c.Encrypt(textBox1.Text, textBox3.Text);
                    string cipher = Cipher.Encrypt(textBox1.Text, textBox2.Text);
                    textBox3.Text = cipher;
                }
                else
                {
                    // textBox2.Text = c.Decrypt(textBox1.Text, textBox3.Text);
                    string plainText = Cipher.Decrypt(textBox1.Text, textBox2.Text);
                    textBox3.Text = plainText;
                }
            }
        }

    }
}
