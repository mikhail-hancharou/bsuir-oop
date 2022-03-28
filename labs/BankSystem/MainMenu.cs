using BankSystem.Entities;
using BankSystem.MenuEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class MainMenu : Form
    {
        public User mainUser { get; set; }
        public MainMenu(User mainUser)
        {
            this.mainUser = mainUser;
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Aprovement();
        }

        private void Aprovement()
        {
            for (int i = 0; i < 20; i++)
            {             
                RequestField requestField = new RequestField();
                this.tableLayoutPanelRequest.Controls.Add(requestField.AproveButton, 0, i);
                this.tableLayoutPanelRequest.RowCount += 1;
                this.tableLayoutPanelRequest.Controls.Add(requestField.DeniedButton, 1, i);
            }


        }

        private void AproveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
