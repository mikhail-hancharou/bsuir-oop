using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BankSystem.Login
{
    class LoginPresenter
    {
        private readonly LoginModel Model;
        private readonly LoginForm View;

        public LoginPresenter(LoginForm view, LoginModel model)
        {
            Model = model;
            View = view;
        }

        public void IsValid(string login, string passw, Form Form)
        {
            Form form = Model.IsValid(login, passw, Form);
            View.Continue(form);
        }
    }
}
