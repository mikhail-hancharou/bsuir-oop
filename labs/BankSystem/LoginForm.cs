using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem
{
    public partial class LoginForm : Form
    {
        private void logButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            if (logBox.Text.Trim() == string.Empty)
            {
                logBox.BackColor = System.Drawing.Color.Red;
            }
            else if (pasBox.Text.Trim() == string.Empty)
            {
                pasBox.BackColor = System.Drawing.Color.Red;
                pasBox.Text = string.Empty;
            }
            else
            {
                Hide();
                MainMenu menu = new MainMenu(new User { });
                if (db.Clients
                    .Include(c => c.User)
                    .AsEnumerable()
                    .Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Client newUser = db.Clients
                        .Include(c => c.Bills)
                        .ThenInclude(b => b.Credits)
                        .Include(c => c.Bills)
                        .ThenInclude(b => b.Installements)
                        .Include(c => c.Bills)
                        .ThenInclude(b => b.Transactions)
                        .ToList()
                        .Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());                  
                    menu = new MainMenu(newUser);
                }
                else if (db.Outsiders
                    .Include(c => c.User)
                    .AsEnumerable()
                    .Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Outsider newUser = db.Outsiders
                        .ToList()
                        .Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    menu = new MainMenu(newUser);
                }
                else if (db.Operators
                    .Include(c => c.User)
                    .AsEnumerable()
                    .Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Operator newUser = db.Operators
                        .Include(o => o.myWork)
                        .ToList()
                        .Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    menu = new MainMenu(newUser);
                }
                else if (db.Managers
                    .Include(c => c.User)
                    .AsEnumerable()
                    .Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Manager newUser = db.Managers
                        .ToList()
                        .Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    menu = new MainMenu(newUser);
                }
                else if (db.Admins
                    .Include(c => c.User)
                    .AsEnumerable()
                    .Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Admin newUser = db.Admins
                        .ToList()
                        .Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    menu = new MainMenu(newUser);
                }
                else
                {
                    pasBox.BackColor = System.Drawing.Color.Red;
                    pasBox.Text = string.Empty;
                }

                if (menu.MainUser is Client && (menu.MainUser as Client).User.Confirmed)
                {
                    menu.Show();
                }
                else if (menu.MainUser is Outsider && (menu.MainUser as Outsider).User.Confirmed)
                {
                    menu.Show();
                }
                else if (menu.MainUser is Operator && (menu.MainUser as Operator).User.Confirmed)
                {
                    menu.Show();
                }
                else if (menu.MainUser is Manager && (menu.MainUser as Manager).User.Confirmed)
                {
                    menu.Show();
                }
                else if (menu.MainUser is Admin && (menu.MainUser as Admin).User.Confirmed)
                {
                    menu.Show();
                }
                else
                {
                    RequestedForm requestedForm = new RequestedForm();
                    requestedForm.Show();

                }
            }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegForm newRegForm = new RegForm();
            newRegForm.Show();
            newRegForm.SetDesktopLocation(500, 200);
        }

        private void logBox_Click(object sender, EventArgs e)
        {
            logBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }

        private void pasBox_Click(object sender, EventArgs e)
        {
            pasBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }
    }
}
