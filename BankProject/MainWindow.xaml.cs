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
        public MainWindow()
        {
            InitializeComponent();
            DataContext= vm;
        }

        private void aaa(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{vm.SelectedAccount.Id}");
        }
    }
}
