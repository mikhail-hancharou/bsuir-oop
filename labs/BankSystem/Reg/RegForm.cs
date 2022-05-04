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
using BankSystem.Reg;

namespace BankSystem
{
    public partial class RegForm : Form
    {
        private RegPresenter Presenter;
        public bool mistake = false;

        public RegForm()
        {
            InitializeComponent();
            roleBox.SelectedIndex = 0;
            dateBox.Text = "dd.mm.yy";

            Presenter = new RegPresenter(this, new RegModel());
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
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
            else
            {
                Presenter.LoginCheck(loginBox.Text.Trim());
            }

            if (passpNumbBox.Text.Trim() == string.Empty)
            {
                passpNumbBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }
            else
            {
                Presenter.PasswNumberCheck(passpNumbBox.Text.Trim());
            }

            if (numberBox.Text.Trim() == string.Empty)
            {
                nameBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }
    
            DateTime date = Presenter.DateTimeCheck(dateBox.Text.Trim());

            if (passwBox.Text.Trim() == string.Empty)
            {
                passwBox.BackColor = System.Drawing.Color.Red;
                mistake = true;
            }

            Bank bank = new Bank();
            if (roleBox.SelectedIndex > 1)
            {
                bank = Presenter.FindBank(roleBankBox.Text.Trim());          
            }

            if (!mistake)
            {
                Hide();
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

                Presenter.AddUser(User, roleBox.SelectedIndex, date, bank);
            }
            else
            {
                mistake = false;
            }
        }

        public void LoginCheckFailed()
        {
            loginBox.ForeColor = System.Drawing.Color.Red;
            loginBox.Text = "already registered";
            mistake = true;
        }

        public void PasswNumberCheckFailed()
        {
            passpNumbBox.ForeColor = System.Drawing.Color.Red;
            passpNumbBox.Text = "already registered";
            mistake = true;
        }

        public void DateTimeCheckFailed()
        {
            dateBox.ForeColor = System.Drawing.Color.Red;
            mistake = true;
        }

        public void RequestedForm()
        {
            RequestedForm requestedForm = new RequestedForm(this);
            requestedForm.Show();
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
                List<string> Banks = new List<string>();
                foreach (Bank b in db.Banks.ToList())
                {
                    Banks.Add(b.Name + "//" + b.BID);
                }
                
                roleBankBox.Items.AddRange(Banks.ToArray()); //db.Banks.ToArray().ToString()
                roleBankBox.SelectedIndex = 0;
            }
            else
            {
                roleBankBox.Visible = false;
            }
        }
    }
}
