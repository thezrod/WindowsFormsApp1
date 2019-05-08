using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    class Ioread
    {
        private string The_File { set; get; }
        public string Read()
        {
            string str = "";
            using (StreamReader sr = new StreamReader(The_File))
            {
                try
                {
                    str = sr.ReadToEnd();
                }
                finally
                {
                    sr.Dispose();
                }
            }
            return str;
        }
        public string ReadLine()
        {
            string str = "";
            using (StreamReader sr = new StreamReader(The_File))
            {
                try
                {
                    str = sr.ReadLine();
                }
                finally
                {
                    sr.Dispose();
                }
                return str;
            }
        }
        private string GetName()
        {
            string str = ReadLine();
            for (int i = 0; i <str.Length; i++)
            {
                if (str.ElementAt(i).Equals(','))
                {
                    str = str.Substring(0, i);
                    break;
                }
            }
            return str;
        }
        private string GetName(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str.ElementAt(i).Equals(','))
                {
                    str = str.Substring(0, i);
                    break;
                }
            }
            return str;
        }
        private string GetPassword(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str.ElementAt(i).Equals(','))
                {
                    str = str.Substring(i+1);
                    break;
                }
            }
            return str;
        }
        private List<string> GetAllNames()
        {
            List<string> allNames = new List<string>();
            string[] allLines = GetLines();
            foreach(string s in allLines)
            {
               allNames.Add(GetName(s));
            }
            return allNames;
        }
        public bool VerifyName(string name)
        {
            List<string> users = GetAllNames();
            return users.Contains(name);
        }
        private string[] GetLines()
        {
            string[] str = File.ReadAllLines(The_File);
            return str;
        }
        public string FindPassword(string name)
        {
            string[] all   = GetLines();
            foreach (string s in all)
            {
                if (GetName(s).Equals(name))
                {
                    return GetPassword(s);
                }
            }
            return "";
        }
        public void Write(string str)
        {
            string old = Read();
            using (StreamWriter sw = new StreamWriter(The_File))
            {
                try
                {
                    sw.WriteLine(old + str);
                }
                finally
                {
                    sw.Dispose();
                }
            }
        }
        public void WriteOver(string str)
        {
            using (StreamWriter sw = new StreamWriter(The_File))
            {
                try
                {
                    sw.WriteLine(str);
                }
                finally
                {
                    sw.Dispose();
                }
            }
        }
        public void Replace(string name,string Old, string New)
        {
            string ans = "";
            if (FindPassword(name).Equals(Old))
            {
                string[] all = GetLines();
                for(int n=0; n < all.Count(); n++)
                {
                    if (all[n].Contains(Old))
                    {
                        string newUser = all[n].Replace(Old, New);//REplace does not work for this
                        all[n] = newUser;
                    }
                    ans = ans + all[n] + "\n";
                }          
                WriteOver(ans);
            }
        }

        public Ioread(string file)
        {
            The_File = file;
        }
    }
}
