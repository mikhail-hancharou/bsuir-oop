using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class RequestedForm : Form
    {
        private readonly Form Parent;
        public RequestedForm(Form parent)
        {
            InitializeComponent();
            Parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Parent.Show();
            //Application.Exit();
        }

        public void ChangeInfo()
        {
            label1.Text = "No such users";
        }
    }
}
