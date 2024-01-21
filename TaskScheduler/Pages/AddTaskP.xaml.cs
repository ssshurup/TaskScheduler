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
    /// Логика взаимодействия для AddTaskP.xaml
    /// </summary>
    public partial class AddTaskP : Page
    {
        public AddTaskP()
        {
            InitializeComponent();
            ImportanceCB.ItemsSource = App.DB.importance.ToList();
        }
        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tasks t = new tasks();
                t.description = DescriprionTB.Text;
                t.idImportance = ImportanceCB.SelectedIndex + 1;
                t.DeadLine = DateDP.SelectedDate;
                t.idUser = DataUs.id;
                t.status = false;
                App.DB.tasks.Add(t);
                App.DB.SaveChanges();
                MessageBox.Show("Succes!");
                NavigationService.Navigate(new UserP());
            }
            catch
            {
                MessageBox.Show("error!");
            }
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());

        }

        
    }
}
