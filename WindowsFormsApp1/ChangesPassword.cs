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
    public partial class ChangesPassword : Form
    {
        private string User { get; set; }
        public ChangesPassword(string user)
        {
            User = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(textBox3.Text))
            {
                if (CheckPassword(textBox2.Text))
                {
                    Ioread io = new Ioread("crypt.txt");
                    string user_cipher = SameAllTheTimeCipher.Encrypt(User,"apa");
                    string old_cipher  = SameAllTheTimeCipher.Encrypt(textBox1.Text,"apa");
                    string new_cipher  = SameAllTheTimeCipher.Encrypt(textBox2.Text,"apa");
                    io.Replace(user_cipher,old_cipher,new_cipher);
                }
            }
        }
        private bool CheckPassword(string password)
        {
            bool LongEnough = false;
            bool hasDigit   = false;
            bool hasLower   = false;
            bool hasUpper   = false;
            bool hasSpecial = false;

            if(password.Length >= 8)
            {
                LongEnough = true;
            }
            foreach(char c in password)
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                if (char.IsLower(c))
                {
                    hasLower = true;
                }
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }
                if (!char.IsLetterOrDigit(c))
                {
                    hasSpecial = true;
                }
            }
            return LongEnough && hasDigit && hasLower && hasUpper && hasSpecial;
        }
    }
}
