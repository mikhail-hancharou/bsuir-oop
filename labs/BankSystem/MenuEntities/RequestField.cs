using BankSystem.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankSystem.MenuEntities
{
    public class RequestField
    {
        public Button AproveButton { get; set; }
        public Button DeniedButton { get; set; }
        public TextBox UserInfo { get; set; }
        public User User { get; set; }

        public RequestField()
        {
            AproveButton = new Button();
            AproveButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            AproveButton.ForeColor = Color.Black;
            AproveButton.Size = new Size(80, 60);
            AproveButton.Text = "Aprove";

            DeniedButton = new Button();
            DeniedButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            DeniedButton.ForeColor = Color.Black;
            DeniedButton.Size = new Size(70, 30);
            DeniedButton.Text = "Denied";
        }
    }
}
