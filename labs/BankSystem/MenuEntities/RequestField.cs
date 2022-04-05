using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankSystem.MenuEntities
{
    public class RequestField
    {
        public Panel FieldPanel { get; set; }
        public Button AproveButton { get; set; }
        public Button DeniedButton { get; set; }
        public Label UserInfo { get; set; }
        public Client Client { get; set; }
        public TableLayoutPanel TablePanel {get; set;}

        public RequestField(Client client, TableLayoutPanel tablePanel) //TODO temp //Client client
        {
            TablePanel = tablePanel;
            Client = client;
            FieldPanel = new Panel();
            FieldPanel.Size = new Size(1000, 60);
            FieldPanel.Dock = DockStyle.Top;

            AproveButton = new Button();
            AproveButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            AproveButton.Size = new Size(80, 60);
            AproveButton.Dock = DockStyle.Left;
            AproveButton.Text = "Aprove";

            DeniedButton = new Button();
            DeniedButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            DeniedButton.Size = new Size(80, 60);
            DeniedButton.Dock = DockStyle.Left;
            DeniedButton.Text = "Denied";

            UserInfo = new Label();
            UserInfo.ForeColor = Color.Black;
            UserInfo.Dock = DockStyle.Fill;
            UserInfo.TextAlign = ContentAlignment.MiddleCenter;
            UserInfo.Text = $"Name: {Client.User.Name} Last Name: {Client.User.LastName} | Passport number: {Client.User.PassportNumber} | ID: {Client.User.Login}";// | Role: {client.Role}

            FieldPanel.Controls.Add(AproveButton);
            FieldPanel.Controls.Add(DeniedButton);
            FieldPanel.Controls.Add(UserInfo);

            DeniedButton.Click += DeniedButton_Click;
            AproveButton.Click += AproveButton_Click;
        }

        private void AproveButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            Client.User.Confirmed = true;
            db.Update(Client);
            db.SaveChanges();
        }

        private void DeniedButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();

            db.Users.Remove(Client.User);
            db.Clients.Remove(Client);
            db.SaveChanges();
        }
    }
}
