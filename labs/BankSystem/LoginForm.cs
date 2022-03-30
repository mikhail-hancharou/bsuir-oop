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
                if (db.Clients.AsEnumerable().Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Client newUser = db.Clients.ToList().Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    this.Hide();
                    MainMenu menu = new MainMenu(newUser);
                    menu.Show();
                }
                else if (db.Outsiders.AsEnumerable().Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Outsider newUser = db.Outsiders.ToList().Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    this.Hide();
                    MainMenu menu = new MainMenu(newUser);
                    menu.Show();
                }
                else if (db.Operators.AsEnumerable().Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Operator newUser = db.Operators.ToList().Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    this.Hide();
                    MainMenu menu = new MainMenu(newUser);
                    menu.Show();
                }
                else if (db.Managers.AsEnumerable().Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Manager newUser = db.Managers.ToList().Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    this.Hide();
                    MainMenu menu = new MainMenu(newUser);
                    menu.Show();
                }
                else if (db.Admins.AsEnumerable().Any(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim()))
                {
                    Admin newUser = db.Admins.ToList().Find(u => u.User.Login == logBox.Text.Trim() && u.User.PassportNumber == pasBox.Text.Trim());
                    this.Hide();
                    MainMenu menu = new MainMenu(newUser);
                    menu.Show();
                }
                else
                {
                    pasBox.BackColor = System.Drawing.Color.Red;
                    pasBox.Text = string.Empty;
                }

                //if (db.Users.AsEnumerable().Any(u => u.ID == logBox.Text.Trim() && u.PassportNumber == pasBox.Text.Trim()))
                //{
                //    Client newUser = db.Users.ToList().Find(u => u.ID == logBox.Text.Trim() && u.PassportNumber == pasBox.Text.Trim());
                //    this.Hide();
                //    MainMenu menu = new MainMenu(newUser);
                //    menu.Show();
                //}
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
            logBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }
    }
}
