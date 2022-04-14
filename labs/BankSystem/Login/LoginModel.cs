using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankSystem.Login
{
    class LoginModel
    {
        public Form Form;
        private bool Confirmed = true;

        public LoginModel() { }

        public Form IsValid(string login, string passw)
        {
            using AppContext db = new AppContext();

            if (db.Clients
                .Include(c => c.User)
                .AsEnumerable()
                .Any(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim()))
            {
                Client newUser = db.Clients
                    .Include(c => c.Bills)
                    .ThenInclude(b => b.Credits)
                    .Include(c => c.Bills)
                    .ThenInclude(b => b.Installements)
                    .Include(c => c.Bills)
                    .ThenInclude(b => b.Transactions)
                    .ToList()
                    .Find(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim());
                Confirmed = newUser.User.Confirmed;
                Form = new MainMenu(newUser);
            }
            else if (db.Outsiders
                .Include(c => c.User)
                .AsEnumerable()
                .Any(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim()))
            {
                Outsider newUser = db.Outsiders
                    .ToList()
                    .Find(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim());
                Confirmed = newUser.User.Confirmed;
                Form = new MainMenu(newUser);
            }
            else if (db.Operators
                .Include(c => c.User)
                .AsEnumerable()
                .Any(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim()))
            {
                Operator newUser = db.Operators
                    .Include(o => o.myWork)
                    .ToList()
                    .Find(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim());
                Confirmed = newUser.User.Confirmed;
                Form = new MainMenu(newUser);
            }
            else if (db.Managers
                .Include(c => c.User)
                .AsEnumerable()
                .Any(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim()))
            {
                Manager newUser = db.Managers
                    .ToList()
                    .Find(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim());
                Confirmed = newUser.User.Confirmed;
                Form = new MainMenu(newUser);
            }
            else if (db.Admins
                .Include(c => c.User)
                .AsEnumerable()
                .Any(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim()))
            {
                Admin newUser = db.Admins
                    .ToList()
                    .Find(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim());
                Confirmed = newUser.User.Confirmed;
                Form = new MainMenu(newUser);
            }
            else
            {
                RequestedForm requestedForm = new RequestedForm();

                if (!Confirmed)
                {
                    Form = requestedForm;
                }
                else
                {
                    requestedForm.ChangeInfo();
                    Form = requestedForm;
                }
            }

            return Form;
        }
    }
}
