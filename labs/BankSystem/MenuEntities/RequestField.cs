using BankSystem.Entities;
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
        public Client User { get; set; }

        public RequestField(Manager client) //TODO temp //Client client
        {
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
            UserInfo.Text = $"Name: {client.User.Name} Last Name: {client.User.LastName} | Passport number: {client.User.PassportNumber} ID: {client.User.Login}";// | Role: {client.Role}

            FieldPanel.Controls.Add(AproveButton);
            FieldPanel.Controls.Add(DeniedButton);
            FieldPanel.Controls.Add(UserInfo);
        }
    }
}
