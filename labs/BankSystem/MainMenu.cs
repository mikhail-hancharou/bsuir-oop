using BankSystem.Entities;
using BankSystem.MenuEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class MainMenu : Form
    {
        public Object mainUser { get; set; } //Client mainUser { get; set; }
        public MainMenu(Object mainUser)
        {
            this.mainUser = mainUser;
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (mainUser is User)
            {
                //TODO
            }
            else if (mainUser is Outsider)
            {
                //TODO
            }
            else if (mainUser is Operator)
            {
                //TODO
            }
            else if (mainUser is Manager)
            {
                mainUser = mainUser as Manager;
                Aprovement();
            }
            else if (mainUser is Admin)
            {
                //TODO
            }
        }

        private void Aprovement()
        {
            using AppContext db = new AppContext();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Where(c => !c.User.Confirmed))
            {
                RequestField requestField = new RequestField(client);
                tableLayoutPanelRequest.Controls.Add(requestField.FieldPanel, 0, tableLayoutPanelRequest.RowCount - 1);
                tableLayoutPanelRequest.RowCount += 1;
                requestField.AproveButton.Click += AproveButton_Click;
                requestField.DeniedButton.Click += DeniedButton_Click;
            }
        }

        private void DeniedButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AproveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
