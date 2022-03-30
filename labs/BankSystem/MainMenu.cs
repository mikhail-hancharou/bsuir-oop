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

            //switch (mainUser.GetType())
            //{
            //    case typeof(Manager):
            //        Aprovement();
            //        break;
            //    default:
            //        break;        
            //}
        }

        private void Aprovement()
        {
            ApplicationContext db = new ApplicationContext();
            for (int i = 0; i < 20; i++)
            {
                RequestField requestField = new RequestField(mainUser as Manager);
                this.tableLayoutPanelRequest.Controls.Add(requestField.FieldPanel, 0, i);
                this.tableLayoutPanelRequest.RowCount += 1;
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
