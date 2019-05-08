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
    public partial class Persnum : Form
    {
        public Persnum()
        {
            InitializeComponent();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int yearNum    = -1;
            int monthNum   = -1;
            int dayNum = -1;
            int specialNum = -1;
            int genderDeterminer = -1;

            if (textBox1.Text.Length == 12)
            {
                textBox2.Text = "";

                yearNum       = Int32.Parse(textBox1.Text.Substring(0, 4));
                textBox2.Text = "Year: " + textBox1.Text.Substring(0, 4) +"\r\n";

                monthNum      = Int32.Parse(textBox1.Text.Substring(4, 2));
                Months m = (Months) monthNum-1;
                textBox2.Text = textBox2.Text +"Month: " + textBox1.Text.Substring(4, 2) +"("+m+")" + "\r\n";

                dayNum        = Int32.Parse(textBox1.Text.Substring(6, 2));
                textBox2.Text = textBox2.Text + "Day: " + textBox1.Text.Substring(6, 2) + "\r\n";

                specialNum    = Int32.Parse(textBox1.Text.Substring(8, 4));
                textBox2.Text = textBox2.Text + "Special: " + textBox1.Text.Substring(8, 4) + "\r\n";

                genderDeterminer = Int32.Parse(textBox1.Text.Substring(10, 1));

                textBox2.Text = textBox2.Text + "You are: " + CalculateAge(yearNum,monthNum,dayNum) + " years old" +"\r\n";

                textBox2.Text = textBox2.Text + "You are a " + CalculateGender(genderDeterminer) + "\r\n";
            }
            else if(textBox1.Text.Length == 10)
            {
                 textBox2.Text = "";
                yearNum       = Int32.Parse(textBox1.Text.Substring(0, 2));
                textBox2.Text = "Year: " + textBox1.Text.Substring(0, 2) + "\r\n";

                monthNum      = Int32.Parse(textBox1.Text.Substring(2, 2));
                Months m = (Months)monthNum-1;
                textBox2.Text = textBox2.Text + "Month: " + textBox1.Text.Substring(2, 2) + "(" + m + ")" + "\r\n";

                dayNum        = Int32.Parse(textBox1.Text.Substring(4, 2));
                textBox2.Text = textBox2.Text + "Day: " + textBox1.Text.Substring(4, 2) + "\r\n";

                specialNum    = Int32.Parse(textBox1.Text.Substring(6, 4));
                textBox2.Text = textBox2.Text + "Special: " + textBox1.Text.Substring(6, 4) + "\r\n";

                genderDeterminer = Int32.Parse(textBox1.Text.Substring(8, 1));

                textBox2.Text = textBox2.Text + "You are: " + CalculateAge(yearNum,monthNum,dayNum) + " years old" + "\r\n";

                textBox2.Text = textBox2.Text + "You are a " + CalculateGender(genderDeterminer) + "\r\n";
            }
            else
            {
                textBox2.Text = "Error! not a valid ID";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (!char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('\b') || (textBox1.Text.Length >= 12) && !e.KeyChar.Equals('\b'))
            {
                e.Handled = true;
            }
        }
        private int GetYear()
        {
            return DateTime.Now.Year;
        }
        private int GetMonth()
        {
            return DateTime.Now.Month;
        }
        private int GetDay()
        {
            return DateTime.Now.Day;
        }
        private int CalculateAge(int year, int month,int day)
        {
            if(year.ToString().Length == 4)
            {
                if (GetMonth() - month < 0 || (GetMonth() - month == 0 && GetDay() - day < 0))
                {
                    return (GetYear() - year) - 1;
                }
                return GetYear() - year;
            }
            else
            {
                int TwoYearDigits = Int32.Parse(GetYear().ToString().Substring(2, 2));
                if (TwoYearDigits < year)
                {
                    year = Int32.Parse("19" + year);
                }
                else
                {
                    year = Int32.Parse("20" + year);
                }
                if (GetMonth() - month < 0 || (GetMonth() - month == 0 && GetDay() - day < 0))
                {
                    return (GetYear() - year) - 1;
                }
                return GetYear() - year;
            }
        }
        private string CalculateGender(int i)
        {
            string gender = "";
            if (i % 2 == 0)
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }
            return gender;
        }
        private enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
    }
}
