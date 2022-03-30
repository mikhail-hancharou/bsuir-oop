using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BankSystem.Comparer;
using BankSystem.Entities;

namespace BankSystem
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();

            roleBox.SelectedIndex = 0;
            dateBox.Text = "dd.mm.yy";
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            bool mistake = false;
            using AppContext db = new AppContext();
            if (nameBox.Text.Trim() == string.Empty)
            {
                nameBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }         

            if (lNameBox.Text.Trim() == string.Empty)
            {
                lNameBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }

            if (loginBox.Text.Trim() == string.Empty)
            {
                loginBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }
            else if (db.Users.AsEnumerable().Any(u => u.Login == loginBox.Text.Trim()))
            {
                loginBox.ForeColor = System.Drawing.Color.Red;
                loginBox.Text = "already registered";
                mistake = true;
            }

            if (passpNumbBox.Text.Trim() == string.Empty)
            {
                passpNumbBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }
            else if (db.Users.AsEnumerable().Any(u => u.PassportNumber == passpNumbBox.Text.Trim()))
            {
                passpNumbBox.ForeColor = System.Drawing.Color.Red;
                passpNumbBox.Text = "already registered";
                mistake = true;
            }

            if (numberBox.Text.Trim() == string.Empty)
            {
                nameBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }

            DateTime date = new DateTime();
            if (Regex.IsMatch(dateBox.Text.Trim(), @"\d{2}.\d{2}.\d{2}"))
            {
                int day = Convert.ToInt32(Regex.Match(dateBox.Text.Trim(), @"^\d{2}\.").Value[..^1]);
                int month = Convert.ToInt32(Regex.Match(dateBox.Text.Trim(), @"\.\d{2}\.").Value[1..^1]);
                int year = Convert.ToInt32(Regex.Match(dateBox.Text.Trim(), @"\.\d{2}$").Value[1..]);

                if (day > 31 || month > 12 || year < 22 || (day < DateTime.Now.Day && month < DateTime.Now.Month))
                {
                    dateBox.ForeColor = System.Drawing.Color.Red;
                    mistake = true;
                }
                else
                {
                    date = new DateTime(2000 + year, month, day);
                }
            }
            else
            {
                dateBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }

            if (passwBox.Text.Trim() == string.Empty)
            {
                passwBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }

            if (!mistake)
            {
                User User = new User
                {
                    Login = loginBox.Text,
                    PassportNumber = passpNumbBox.Text,
                    Name = nameBox.Text,
                    LastName = loginBox.Text,
                    Password = passwBox.Text,
                    TNumber = numberBox.Text,
                    Confirmed = false,
                };

                db.Users.Add(User);

                switch (roleBox.SelectedIndex)
                {
                    case 0:
                        db.Clients.Add(new Client
                        {
                            User = User,
                            PassportNumber = passpNumbBox.Text,
                            ExpiryDate = date,
                            Bills = new HashSet<Bill>(new BillComparer()),
                        });
                        break;
                    case 1:
                        db.Outsiders.Add(new Outsider { User = User });                     
                        break;
                    case 2:
                        db.Managers.Add(new Manager { User = User });
                        break;
                    case 3:
                        db.Operators.Add(new Operator { User = User });
                        break;
                    case 4:
                        db.Admins.Add(new Admin { User = User });
                        break;
                    default:
                        break;
                }

                db.SaveChanges();
                this.Hide();
            }
        }

        private void nameBox_Click(object sender, EventArgs e)
        {
            nameBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }

        private void lNameBox_Click(object sender, EventArgs e)
        {
            lNameBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }

        private void loginBox_Click(object sender, EventArgs e)
        {
            loginBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            loginBox.ForeColor = System.Drawing.Color.Black;
            if (loginBox.Text == "already registered")
            {
                loginBox.Text = "";
            }
        }

        private void passpNumbBox_Click(object sender, EventArgs e)
        {
            passpNumbBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            passpNumbBox.ForeColor = System.Drawing.Color.Black;
            if (passpNumbBox.Text == "already registered")
            {
                passpNumbBox.Text = "";
            }
        }

        private void dateBox_Click(object sender, EventArgs e)
        {
            if (dateBox.Text == "dd.mm.yy")
            {
                dateBox.Text = "";
            }

            dateBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }

        private void passwBox_Click(object sender, EventArgs e)
        {
            passwBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm newLogForm = new LoginForm();
            newLogForm.Show();
            newLogForm.SetDesktopLocation(500, 200);
        }

        private void dateBox_Leave(object sender, EventArgs e)
        {
            if (dateBox.Text == "")
            {
                dateBox.Text = "dd.mm.yy";
            }
            dateBox.ForeColor = System.Drawing.Color.Black;
        }

        private void numberBox_Click(object sender, EventArgs e)
        {
            numberBox.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }

        private void roleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roleBox.SelectedIndex > 1)
            {
                using AppContext db = new AppContext();
                roleBankBox.Visible = true;
                roleBankBox.Items.AddRange(db.Banks.ToArray());
            }
            else
            {
                roleBankBox.Visible = false;
            }
        }
    }
}
