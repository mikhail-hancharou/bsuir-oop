using BankSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Reg
{
    class RegPresenter
    {
        private readonly RegModel Model;
        private readonly RegForm View;

        public RegPresenter(RegForm view, RegModel model)
        {
            Model = model;
            View = view;
        }

        public void LoginCheck(string login)
        {
            if (Model.LoginCheck(login))
            {
                View.LoginCheckFailed();
            }          
        }

        public void PasswNumberCheck(string passwNumber)
        {
            if (Model.PasswNumberCheck(passwNumber))
            {
                View.PasswNumberCheckFailed();
            }
        }

        public DateTime DateTimeCheck(string date)
        {
            DateTime Date = Model.DateTimeCheck(date);
            if (Date.Year == 0)
            {
                View.DateTimeCheckFailed();
            }
            return Date;
        }

        public Bank FindBank(string info)
        {
            return Model.FindBank(info);
        }

        public void AddUser(User user, int role, DateTime date, Bank bank)
        {
            Model.AddUser(user, role, date, bank);
            View.RequestedForm();
        }
    }
}
