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
    public partial class Welcome : Form
    {
        private string User { set; get; }
        private Form Parent { set; get; }

        public Welcome(string user, Form parent)
        {
            InitializeComponent();
            User = user;
            Parent = parent;
            setName();
            string info_file = User + ".txt";
            Ioread io = new Ioread("G:\\joels uppgift\\WindowsFormsApp1\\WindowsFormsApp1\\bin\\Debug\\Users\\" + info_file);
            try
            {
               textBox1.Text = Cipher.Decrypt(io.Read(), "apa");
            }catch(Exception e)
            {
                textBox1.Text = io.Read();
            }

            this.FormClosed += new FormClosedEventHandler(Welcome_FormClosed);
        }

        private void Welcome_FormClosed(object sender,EventArgs e)
        {
            Parent.Visible = true;
        }
        private void setName()
        {
            label1.Text = "Welcome "+User;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string info_file = User + ".txt";
            Ioread io = new Ioread("G:\\joels uppgift\\WindowsFormsApp1\\WindowsFormsApp1\\bin\\Debug\\Users\\" + info_file);
            string cipher_message = Cipher.Encrypt(textBox1.Text,"apa");
            io.WriteOver(cipher_message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangesPassword changepassword = new ChangesPassword(User);
            changepassword.ShowDialog();
        }
    }
}
