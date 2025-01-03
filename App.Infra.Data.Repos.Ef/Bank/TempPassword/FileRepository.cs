using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft;
using System.IO;

namespace App.Infra.Data.Repos.Ef.Bank.TempPassword
{
    public class FileRepository
    {
        private static System.Timers.Timer timer;
        private static Random random = new Random();
        private const string FilePath = "C:\\Users\\BiG\\OneDrive\\Desktop\\aaaa.txt";
        public void Password()
        {
            timer = new System.Timers.Timer(20000);
            timer.Elapsed += WriteRandomPasswordToFile;
            timer.AutoReset = true;
            timer.Enabled = true;
            WriteRandomPasswordToFile(null, null);

        }
        private static void WriteRandomPasswordToFile(object sender, ElapsedEventArgs e)
        {
            int randomPassword = random.Next(10000, 100000);

            File.WriteAllText(FilePath, randomPassword.ToString());

        }
        public string GetPasswordFromFile()
        {
            string CurrentPassword = File.ReadAllText(FilePath);
            return CurrentPassword;
        }
    }
}
