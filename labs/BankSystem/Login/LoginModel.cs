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

        public Form IsValid(string login, string passw, Form form)
        {
            using AppContext db = new AppContext();
            RequestedForm requestedForm = new RequestedForm(form);

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
                db.Logs.Add(new Log("", $"{DateTime.UtcNow.ToString()} Client login - {Confirmed} - {newUser.User.Login}"));
            }
            else if (db.Outsiders
                .Include(c => c.User)
                .AsEnumerable()
                .Any(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim()))
            {
                Outsider newUser = db.Outsiders
                    .ToList()
                    .Find(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim());
                Form = new MainMenu(newUser);
                db.Logs.Add(new Log("", $"{DateTime.UtcNow.ToString()} Outsiders login - {newUser.User.Login}"));
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
                db.Logs.Add(new Log($"{newUser.myWork.BID}", $"{DateTime.UtcNow.ToString()} Operator login - {newUser.User.Login}"));
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
                db.Logs.Add(new Log($"{newUser.BID}", $"{DateTime.UtcNow.ToString()} Manager login - {newUser.User.Login}"));
                Form = new MainMenu(newUser);
            }
            else if (db.Admins
                .Include(c => c.User)
                .AsEnumerable()
                .Any(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim()))
            {
                Admin newUser = db.Admins
                    .Include(a => a.myWork)
                    .ToList()
                    .Find(u => u.User.Login == login.Trim() && u.User.PassportNumber == passw.Trim());
                db.Logs.Add(new Log($"", $"{DateTime.UtcNow.ToString()} Admin login - {newUser.User.Login}"));
                Form = new MainMenu(newUser);
            }
            else
            {
                requestedForm.ChangeInfo();
                return requestedForm;
            }

            if (!Confirmed)
            {
                Form = requestedForm;
            }

            db.SaveChanges();
            return Form;
        }
    }
}
