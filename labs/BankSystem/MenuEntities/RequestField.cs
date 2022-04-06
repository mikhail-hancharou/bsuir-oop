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

        public RequestField(Client client, TableLayoutPanel tablePanel)
        {
            TablePanel = tablePanel;
            Client = client;
            FieldPanel = new Panel();
            FieldPanel.Size = new Size(600, 50);
            FieldPanel.Dock = DockStyle.Top;

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

            UserInfo = new Label();
            UserInfo.ForeColor = Color.Black;
            UserInfo.Dock = DockStyle.Fill;
            UserInfo.TextAlign = ContentAlignment.MiddleRight;
            //UserInfo.Text = $"Name: {Client.User.Name} L.Name: {Client.User.LastName} | Passp.numb.: {Client.User.PassportNumber} | ID: {Client.User.Login}";
            UserInfo.Text = $"Name | L.Name | Passp.numb. | ID      \n" +
                $"{Client.User.Name} | {Client.User.LastName} | {Client.User.PassportNumber} | {Client.User.Login}      ";

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
