using BankSystem.Entities;
using BankSystem.MenuEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BankSystem.Menu
{
    class MenuPresenter
    {
        private readonly MenuModel Model;
        private readonly MainMenu View;

        public MenuPresenter(MainMenu view, MenuModel model)
        {
            Model = model;
            View = view;
        }
        public List<Panel> Aprovement(string BID, TableLayoutPanel tb)
        {
            return Model.Aprovement(BID, tb);
        }

        public List<Panel> InitializeTransferRequest(Outsider outsider, TableLayoutPanel tb)
        {
            return Model.InitializeTransferRequest(outsider, tb);
        }

        public List<Panel> InitializeCreditRequest(string BID, TableLayoutPanel tb)
        {
            return Model.InitializeCreditRequest(BID, tb);
        }

        public List<Panel> InitializeInstallementRequest(string BID, TableLayoutPanel tb)
        {
            return Model.InitializeInstallementRequest(BID, tb);
        }

        public List<Panel> InitializeSPRequest(string BID, TableLayoutPanel tb)
        {
            return Model.InitializeSPRequest(BID, tb);
        }

        public List<Panel> InitializeTranzactions(string BID, TableLayoutPanel tb)
        {
            return Model.InitializeTranzactions(BID, tb);
        }

        public List<Panel> InitializeUndoOutsiders(string BID, TableLayoutPanel tb)
        {
            return Model.InitializeUndoOutsiders(BID, tb);
        }

        public List<string> BankInit()
        {
            return Model.BankInit();
        }

        public List<string> BillInit(Client client)
        {
            return Model.BillInit(client);
        }

        public Client ClientUpdate(Client client)
        {
            return Model.ClientUpdate(client);
        }

        public void CreateBill(Client client, string bank, string billNumber)
        {
            Model.CreateBill(client, bank, billNumber);
        }

        public string BankIndex(string bankNBID)
        {
            return Model.BankIndex(bankNBID);
        }

        public string BillIndex(Client client, string billNumber)
        {
            Bill bill =  Model.BillIndex(client, billNumber);
            View.MoneyNPaymentUpdate(bill);
            return Model.BankName(bill);
        }

        public double MoneyNPayment(Bill bill)
        {
            return Model.MoneyNPayment(bill);
        }
    }
}
