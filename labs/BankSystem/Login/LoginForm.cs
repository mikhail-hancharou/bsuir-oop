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
using BankSystem.Login;
using Microsoft.EntityFrameworkCore;

namespace BankSystem
{
    public partial class LoginForm : Form
    {
        private LoginPresenter Presenter;

        public LoginForm()
        {
            InitializeComponent();
            Presenter = new LoginPresenter(this, new LoginModel());
        }

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
                Presenter.IsValid(logBox.Text.Trim(), pasBox.Text.Trim());
            }
        }

        public void Continue(Form form)
        {
            form.SetDesktopLocation(500, 200);
            form.Show();
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            Hide();
            RegForm newRegForm = new RegForm();
            newRegForm.SetDesktopLocation(500, 200);
            newRegForm.Show();
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
