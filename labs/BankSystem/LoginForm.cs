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
                if (db.Users.AsEnumerable().Any(u => u.Id == logBox.Text.Trim() && u.PassportNumber == pasBox.Text.Trim()))
                {
                    User newUser = db.Users.ToList().Find(u => u.Id == logBox.Text.Trim() && u.PassportNumber == pasBox.Text.Trim());
                    this.Hide();
                    MainMenu menu = new MainMenu(newUser);
                    menu.Show();
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
            logBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }
    }
}
