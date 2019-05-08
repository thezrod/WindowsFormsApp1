using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Validator
    {
        private Ioread io = new Ioread();
        bool correctName = false;
        bool correctPass = false;

      /*  public bool Verify(string name, string password)
        {
                Ioread io = new Ioread();

                if (GetName(io.Read()).Equals(name))
                {
                    correctName = true;
                }
                if (GetPassword(io.Read()).Equals(password))
                {
                    correctPass = true;
                }
                return correctName && correctPass;
        } */
        public bool Verify(string name, string password)
        {
                Ioread io = new Ioread();
            if (GetName(io.Read()).Equals(name) && GetPassword(io.Read()).Equals(password))
                return true;
            else
                return false;
        }

        private string GetName(string all)
        {
            string name = "";
            for(int n=0; n < all.Length; n++)
            {
                if (all[n].Equals(','))
                {
                    name = all.Substring(0,n);
                }
            }
            return name;
        }
        private string GetPassword(string all)
        {
            string name = "";
            for (int n = 0; n < all.Length; n++)
            {
                if (all[n].Equals(','))
                {
                    name = all.Substring(n+1);
                }
            }
            return name;
        }

        //Constuctor
        public Validator()
        {
        }
    }
}
