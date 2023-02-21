using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using BankProject.AccountOperationLog;
using BankProject.BankAccounts;
using BankProject.Interfaces;

namespace BankProject
{
    public class ViewModel : INotifyPropertyChanged
    {
        List<Resident> residents;
        ObservableCollection<Resident> residentsObs;
        Resident selectedResident;
        BankAccount selectedAccount;
        /// <summary>
        /// Первоначальный лог для всех аккаунтов
        /// </summary>
        public static OperationLog Log = new OperationLog();

        RelayCommand openAccount;
        RelayCommand closeAccount;
        RelayCommand transferMoneyToClient;
        RelayCommand addMoney;

        public event PropertyChangedEventHandler? PropertyChanged;
        #region BindingProperty
        public OperationLog LogToView { get => Log; }
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
                        IAccountType<BankAccount> account = selectedResident.BankAccountsRepository;
                        account.GetValue.ReplenishAccount(MoneyAmmount);
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
    }
}