using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using BankProject.BankAccounts;

namespace BankProject
{
    public class ViewModel : INotifyPropertyChanged
    {
        List<Resident> residents;
        ObservableCollection<Resident> residentsObs;
        Resident selectedResident;
        BankAccount selectedAccount;

        RelayCommand openAccount;
        RelayCommand closeAccount;
        RelayCommand transferMoney;
        RelayCommand transferMoneyToClient;
        RelayCommand addMoney;

        public event PropertyChangedEventHandler? PropertyChanged;
        #region BindingProperty
        public ObservableCollection<Resident> ResidetnsObs
        {
            get => residentsObs;
            set => residentsObs = value;
        }
        public Resident SelectedResident
        {
            get => selectedResident;
            set { selectedResident = value; OnPropertyChanged(); }
        }
        public BankAccount SelectedAccount
        {
            get => selectedAccount;
            set
            {
                selectedAccount = value; OnPropertyChanged();
                SelectedResident.BankAccountsRepository.SelectedBankAccount = selectedAccount;
            }
        }
        /// <summary>
        /// Привязка к TextBox "сумма перевода"
        /// </summary>
        public int MoneyAmmount { get; set; }

        #endregion
        //Команды

        public RelayCommand OpenAccount
        {
            get
            {
                return openAccount ??
                    (openAccount = new RelayCommand(o =>
                    {
                        if (selectedResident != null)
                            selectedResident.BankAccountsRepository.AddBankAccount();
                    }));
            }
        }
        public RelayCommand CloseAccount
        {
            get
            {
                return closeAccount ??
                    (closeAccount = new RelayCommand(o =>
                    {
                        BankAccount bankAccount = o as BankAccount;
                        if (o != null)
                        {
                            selectedResident.BankAccountsRepository.DeleteBankAccount(bankAccount);
                        }
                    }));
            }
        }
        public RelayCommand TransferMoney
        {
            get
            {
                return transferMoney ??
                    (transferMoney = new RelayCommand(o =>
                    {
                        IAccountType<BankAccount> account = selectedResident.BankAccountsRepository;
                        account.GetValue.ReplenishAccount(MoneyAmmount);
                    }));
            }
        }

        public RelayCommand TransferMoneyToClient
        {
            get
            {
                return transferMoneyToClient ?? (
                    transferMoneyToClient = new RelayCommand(o =>
                    {
                        ITargetContr<BankAccount> getTargetContr = selectedResident.BankAccountsRepository.SelectedBankAccount;
                        getTargetContr.TransferToClient(o as BankAccount, MoneyAmmount);
                    }));
            }
        }
        public RelayCommand AddMoney
        {
            get
            {
                return addMoney ?? (
                    addMoney = new RelayCommand(o =>
                    {
                    }));
            }
        }
        #region Конструктор
        public ViewModel(params Resident[] residents)
        {
            this.residents = new List<Resident>();
            foreach (var res in residents)
            {
                this.residents.Add(res);
            }
            residentsObs = new ObservableCollection<Resident>(this.residents);
        }

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //private BankAccount BankAccountType(BankAccount ba)
        //{
        //    if (ba is NonDepositBankAccount)
        //        return ba as NonDepositBankAccount;
        //    else 
        //        return ba as DepositBankAccount;
        //}
    }
}