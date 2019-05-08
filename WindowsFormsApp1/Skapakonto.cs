using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Skapakonto : Form
    {
        static string namn = "";
        static string lösenord = "";
        static string bekräftalösen = "";
        public Skapakonto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            namn = NametextBox.Text;
            lösenord = textBox2.Text;
            bekräftalösen = textBox3.Text;
            if (!namn.Equals(""))
            {
                if (lösenord.Equals(bekräftalösen))
                {
                    if (Checkpass(lösenord))
                    {
                        Ioread io_crypt = new Ioread("crypt.txt");
                        string c_name = SameAllTheTimeCipher.Encrypt(namn, "apa");
                        string c_pass = SameAllTheTimeCipher.Encrypt(lösenord, "apa");
                        io_crypt.Write(c_name + "," + c_pass);
                        string fil = namn + ".txt";
                        File.Create("Users\\"+fil).Close();
                    }
                    else
                    {
                        textBox2.Text = "Fel!";
                    }
                }
                else
                {
                    textBox3.Text = "Inte samma bekräftelse";
                }
            }
            else
            {
                textBox3.Text = "Inget namn";
            }
            
           // Close();
        }
        private bool Checkpass(string lösen)
        {
            bool hasDiget = false;
            bool hasLetter = false;

            if (lösen.Length < 8)
            {
                return false;
            }
            else
            {

                for (int n = 0; n < lösen.Length; n++)
                {
                    if (char.IsDigit(lösen[n]))
                    {
                        hasDiget = true;
                    }
                    if (char.IsLetter(lösen[n]))
                    {
                        hasLetter = true;
                    }
                }
            }
            if(hasLetter && hasDiget)
            {
                return true;
            }
            return false;
        }
    }
}
