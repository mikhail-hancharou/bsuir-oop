﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
            else if (db.Users.AsEnumerable().Any(u => u.Id == loginBox.Text.Trim()))
            {
                loginBox.ForeColor = System.Drawing.Color.Red;
                loginBox.Text = "already registered";
                mistake = true;
            }
            else
            {
                foreach (User u in db.Users.ToList())
                {
                    Console.WriteLine(u.Name);
                }
            }

            if (passpNumbBox.Text.Trim() == string.Empty)
            {
                passpNumbBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }
            else if (db.Users.AsEnumerable().Any(u => u.Id == passpNumbBox.Text.Trim()))
            {
                passpNumbBox.ForeColor = System.Drawing.Color.Red;
                passpNumbBox.Text = "already registered";
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
                Roles role = (roleBox.SelectedIndex) switch
                {
                    0 => Roles.User,
                    1 => Roles.Operator,
                    2 => Roles.Manager,
                    3 => Roles.Outsider,
                    4 => Roles.Admin,
                    _ => Roles.User
                };
                User newUser = new User(nameBox.Text, lNameBox.Text, loginBox.Text, passpNumbBox.Text, date, passwBox.Text, role);
                db.Users.Add(newUser);
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
    }
}
