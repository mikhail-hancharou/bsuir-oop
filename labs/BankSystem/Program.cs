using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankSystem.Entities;

namespace BankSystem
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            /*new MainMenu(
                new Client
                {
                    Id = 1,
                    Bills = new HashSet<Bill>(),
                    User = new User
                    {
                        Name = "aaa",
                        LastName = "bbb",
                        Login = "login",
                        PassportNumber = "numer"
                    }
                })); */

            /*new MainMenu(
                new Manager
                {
                    Id = 1,
                    myWork = new Bank(),
                    User = new User
                    {
                        Name = "aaa",
                        LastName = "bbb",
                        Login = "login",
                        PassportNumber = "numer"
                    }
                }));*/ // new RegForm());
        }
        /* new MainMenu(
                new Manager
                {
                    Id = 1,
                    myWork = new Bank(),
                    User = new User
                    {
                        Name = "aaa",
                        LastName = "bbb",
                        Login = "login",
                        PassportNumber = "numer"
                    }
                }));*/
    }
}
