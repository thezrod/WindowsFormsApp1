using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApp1
{
    class My_Timer
    {
        public System.Windows.Forms.Timer timer;
        public bool Enabled { get; set; }
        private int Counter { get; set; }

        public void Start(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();

            timer.Interval = 1000;
            timer.Start();
        }

        private void timer_Tick(object sender, EventHandler e)
        {
            if (Counter == 0)
            {
                timer.Stop();
            }
           
        }
        My_Timer(int counter)
        {
            Counter = counter;
        }
       
    }
}
