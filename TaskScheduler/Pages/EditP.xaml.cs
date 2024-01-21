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

namespace TaskScheduler.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditP.xaml
    /// </summary>
    public partial class EditP : Page
    {
        tasks contextT;
        public EditP(tasks task)
        {
            InitializeComponent();
            contextT = task;
            DataContext = contextT;
            ImportanceCB.ItemsSource = App.DB.importance.ToList();
            DateDP.SelectedDate = contextT.DeadLine;
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            App.DB.SaveChanges();
            MessageBox.Show("Succes!");
            NavigationService.Navigate(new UserP());

        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }
    }
}
