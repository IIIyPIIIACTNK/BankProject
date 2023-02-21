using BankProject.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BankProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel(new Resident("Pavel"), new Resident("Misha"));
        EventLogWindow logWindow = new EventLogWindow();
        public MainWindow()
        {
            InitializeComponent();
            DataContext= vm;
            logWindow.Show();
            logWindow.DataContext = vm;
        }

        private void ShowTransferPanel(object sender, RoutedEventArgs e)
        {
            if (TransferPanel.DataContext != null)
            TransferPanel.Visibility = Visibility.Visible;
        }

        private void CloseTransferMenu(object sender, RoutedEventArgs e)
        {
            TransferPanel.Visibility = Visibility.Collapsed;
        }

        private void CloseAddMenu(object sender, RoutedEventArgs e)
        {
            AddMoneyPanel.Visibility = Visibility.Collapsed;
        }

        private void ShowAddPanel(object sender, RoutedEventArgs e)
        {
            AddMoneyPanel.Visibility = Visibility.Visible;
        }

        private void CloseTransferBetweenClints(object sender, RoutedEventArgs e)
        {
            TransferBetweenClients.Visibility = Visibility.Collapsed;
        }

        private void OpenTransferToClient(object sender, RoutedEventArgs e)
        {
            TransferBetweenClients.Visibility = Visibility.Visible;
        }
    }
}
