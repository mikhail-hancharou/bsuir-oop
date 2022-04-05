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
        public object MainUser { get; set; } //Client mainUser { get; set; }
        public List<RequestField> ListRequestField { get; set; }
        public MainMenu(object mainUser)
        {
            this.MainUser = mainUser;
            this.ListRequestField = new List<RequestField>();
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (MainUser is User)
            {
                //TODO
            }
            else if (MainUser is Outsider)
            {
                //TODO
            }
            else if (MainUser is Operator)
            {
                //TODO
            }
            else if (MainUser is Manager)
            {
                MainUser = MainUser as Manager;
                Aprovement();
            }
            else if (MainUser is Admin)
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
                RequestField requestField = new RequestField(client, tableLayoutPanelRequest);
                tableLayoutPanelRequest.Controls.Add(requestField.FieldPanel);
                //tableLayoutPanelRequest.Controls.Add(requestField.FieldPanel, 0, tableLayoutPanelRequest.RowCount - 1);
                //tableLayoutPanelRequest.RowCount += 1;
                //requestField.AproveButton.Click += AproveButton_Click;
                //requestField.DeniedButton.Click += DeniedButton_Click;
                ListRequestField.Add(requestField);
            }
        }

        //private void DeniedButton_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void AproveButton_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
