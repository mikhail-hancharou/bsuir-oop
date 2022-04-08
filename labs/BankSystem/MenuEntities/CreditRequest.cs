using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BankSystem.MenuEntities
{
    class CreditRequest
    {
        public Panel FieldPanel { get; set; }
        public Button AproveButton { get; set; }
        public Button DeniedButton { get; set; }
        public Label CreditRequestInfo { get; set; }
        public Credit Credit { get; set; }
        public Installement Installement { get; set; }
        public Client Client { get; set; }
        public TableLayoutPanel TablePanel { get; set; }

        public CreditRequest(Client client, Credit credit, TableLayoutPanel tablePanel)
        {
            TablePanel = tablePanel;
            Credit = credit;
            Client = client;
            FieldPanel = CreatePanel();
            DeniedButton.Click += DeniedCreditButton_Click;
            AproveButton.Click += AproveCreditButton_Click;
            CreditRequestInfo.Text = $"Name: {Client.User.Name} | L.Name: {Client.User.LastName} | Passp.numb.: {Client.User.PassportNumber} | ID: {Client.User.Login}\n" +
                $"Amount: {credit.Money} | Period: {credit.Months} months | Alr. have: {client.Bills.Sum(b => b.Credits.Count(c => c.Confirmed))} credits";
            //FieldPanel = new Panel();
            //FieldPanel.Size = new Size(600, 50);
            //FieldPanel.Dock = DockStyle.Top;
            //FieldPanel.BorderStyle = BorderStyle.Fixed3D;
            //FieldPanel.Margin = new Padding(3, 3, 3, 0);
            //
            //AproveButton = new Button();
            //AproveButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            //AproveButton.Size = new Size(80, 50);
            //AproveButton.TextAlign = ContentAlignment.MiddleCenter;
            //AproveButton.Dock = DockStyle.Left;
            //AproveButton.Text = "Aprove";
            //
            //DeniedButton = new Button();
            //DeniedButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            //DeniedButton.Size = new Size(80, 50);
            //DeniedButton.TextAlign = ContentAlignment.MiddleCenter;
            //DeniedButton.Dock = DockStyle.Left;
            //DeniedButton.Text = "Denied";
            //
            //CreditRequestInfo = new Label();
            //CreditRequestInfo.ForeColor = Color.Black;
            //CreditRequestInfo.Dock = DockStyle.Fill;
            //CreditRequestInfo.TextAlign = ContentAlignment.MiddleCenter;
            //CreditRequestInfo.Text = $"Name: {Client.User.Name} | L.Name: {Client.User.LastName} | Passp.numb.: {Client.User.PassportNumber} | ID: {Client.User.Login}\n" +
            //    $"Amount: {credit.Money} | Period: {credit.Months} months | Alr. have: {client.Bills.Sum(b => b.Credits.Count(c => c.Confirmed))} credits";/* & {client.Bills.Sum(b => b.Installements.Count(c => c.Confirmed))} Inst."*/
            //
            //FieldPanel.Controls.Add(AproveButton);
            //FieldPanel.Controls.Add(DeniedButton);
            //FieldPanel.Controls.Add(CreditRequestInfo);
        }

        public CreditRequest(Client client, Installement installement, TableLayoutPanel tablePanel)
        {
            TablePanel = tablePanel;
            Installement = installement;
            Client = client;
            FieldPanel = CreatePanel();
            CreditRequestInfo.Text = $"Name: {Client.User.Name} | L.Name: {Client.User.LastName} | Passp.numb.: {Client.User.PassportNumber} | ID: {Client.User.Login}\n" +
                $"Amount: {installement.Money} | Period: {installement.Months} months | Alr. have: {client.Bills.Sum(b => b.Installements.Count(c => c.Confirmed))} inst.";
            DeniedButton.Click += DeniedInstButton_Click;
            AproveButton.Click += AproveInstButton_Click;
        }

        private Panel CreatePanel()
        {
            FieldPanel = new Panel();
            FieldPanel.Size = new Size(600, 50);
            FieldPanel.Dock = DockStyle.Top;
            FieldPanel.BorderStyle = BorderStyle.Fixed3D;
            FieldPanel.Margin = new Padding(3, 3, 3, 0);

            AproveButton = new Button();
            AproveButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            AproveButton.Size = new Size(80, 50);
            AproveButton.TextAlign = ContentAlignment.MiddleCenter;
            AproveButton.Dock = DockStyle.Left;
            AproveButton.Text = "Aprove";

            DeniedButton = new Button();
            DeniedButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            DeniedButton.Size = new Size(80, 50);
            DeniedButton.TextAlign = ContentAlignment.MiddleCenter;
            DeniedButton.Dock = DockStyle.Left;
            DeniedButton.Text = "Denied";

            CreditRequestInfo = new Label();
            CreditRequestInfo.ForeColor = Color.Black;
            CreditRequestInfo.Dock = DockStyle.Fill;
            CreditRequestInfo.TextAlign = ContentAlignment.MiddleCenter;

            FieldPanel.Controls.Add(AproveButton);
            FieldPanel.Controls.Add(DeniedButton);
            FieldPanel.Controls.Add(CreditRequestInfo);

            return FieldPanel;
        }

        private void AproveCreditButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            Credit.Confirmed = true;
            Credit.ConfirmedTime = DateTime.UtcNow;
            db.Credits.Update(Credit);
            db.SaveChanges();
        }

        private void DeniedCreditButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();

            db.Credits.Remove(Credit);
            //db.Clients.Update(Client);
            db.SaveChanges();
        }

        private void AproveInstButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            Installement.Confirmed = true;
            Installement.ConfirmedTime = DateTime.UtcNow;
            db.Installements.Update(Installement);
            db.SaveChanges();
        }

        private void DeniedInstButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            db.Installements.Remove(Installement);
            db.SaveChanges();
        }
    }
}
