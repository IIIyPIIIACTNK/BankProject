using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Resident> ResidetnsObs 
        {
            get => residentsObs;
            set => residentsObs = value;
        }
        public Resident SelectedResident { get => selectedResident; 
            set { selectedResident = value; OnPropertyChanged(); } }
        public BankAccount SelectedAccount { get => selectedAccount; 
            set { selectedAccount = value; OnPropertyChanged(); } }

        //Команды

        public RelayCommand OpenAccount
        {
            get {
                return openAccount ??
                    (openAccount = new RelayCommand(o =>
                    {
                        if(selectedResident!= null)
                            selectedResident.BankAccountsRepository.AddBankAccount();
                    }));
            }
        }
        public RelayCommand CloseAccount
        {
            get {
                return closeAccount ??
                    (closeAccount = new RelayCommand(o =>
                    {
                        //MessageBox.Show($"{SelectedAccount.Id}");
                        BankAccount bankAccount = o as BankAccount;
                        if(o != null)
                        {
                            selectedResident.BankAccountsRepository.DeleteBankAccount(bankAccount);
                        }
                    }));
            }
        }

        #region Конструктор
        
        public ViewModel(params Resident[] residents) 
        { 
            this.residents = new List<Resident>();
            foreach(var res in residents) 
            {
                res.BankAccountsRepository.AddBankAccount();
                this.residents.Add(res);
            }
            residentsObs= new ObservableCollection<Resident>(this.residents);
        }

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
