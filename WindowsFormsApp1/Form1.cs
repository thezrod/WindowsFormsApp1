using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int tries = 0;
        System.Timers.Timer t;
        private int Max     { set; get;}
        private int Counter { set; get; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Ioread io = new Ioread("crypt.txt");
            string correct_password = "";
            string name = textBox1.Text;
            string c_name = SameAllTheTimeCipher.Encrypt(name,"apa");
            string password = textBox2.Text;
            string c_pass = SameAllTheTimeCipher.Encrypt(password, "apa");

            if (io.VerifyName(c_name) && !c_name.Equals("") && !c_name.Equals(string.Empty))
            {
                correct_password = io.FindPassword(c_name);

                if (correct_password.Equals(c_pass))
                {
                    string user = textBox1.Text;
                    textBox1.Text = textBox2.Text = "";
                    Visible = false;
                    Welcome welcome = new Welcome(user, this);
                    welcome.ShowDialog();
                }
                else
                {
                    tries++;
                    if(tries == 3)
                    {
                        tries = 0;
                        button1.Enabled 
                        = button2.Enabled 
                        = button3.Enabled = false;

                        Max = 5;
                        Counter = 0;
                        t = new System.Timers.Timer();
                        t.Interval = 1000;
                        t.Elapsed += OnTimeEvent;
                        t.Start();
                    }
                }
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Skapakonto sk = new Skapakonto();
            sk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CryptoTest ct = new CryptoTest();
            ct.ShowDialog();
        }
        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if(Counter < Max)
                {
                    Counter++;
                }
                if(Counter == Max)
                {
                    button1.Enabled 
                    = button2.Enabled 
                    = button3.Enabled = true;

                    t.Stop();
                }

            }));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Persnum p = new Persnum();
            p.ShowDialog();
        }
    }
}
