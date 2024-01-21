using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для UserP.xaml
    /// </summary>
    public partial class UserP : Page
    {
        public UserP()
        {
            InitializeComponent();
            TaskListDG.ItemsSource = App.DB.tasks.ToList();
        }
        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTaskP());
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = TaskListDG.SelectedItem as tasks;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберрите пожалуйста хоть что-то :)");
                return;
            }
            NavigationService.Navigate(new EditP(selectedItem));
        }

        
        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CompleteBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = TaskListDG.SelectedItem as tasks;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберрите пожалуйста хоть что-то :)");
                return;
            }
            if (selectedItem.status == true)
            {
                string message = "Задание уже выполненно, хотите удалить его из списка? ";
                string caption = "Ворота";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    App.DB.tasks.Remove(selectedItem);
                    App.DB.SaveChanges();
                    TaskListDG.ItemsSource = App.DB.tasks.ToList();
                }
            }
            else
            {
                tasks contextT;
                contextT = selectedItem;
                DataContext = contextT;

                contextT.status = true;
                App.DB.SaveChanges();
                TaskListDG.ItemsSource = App.DB.tasks.ToList();
            }
               
            
        }

        private void DropTaskBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = TaskListDG.SelectedItem as tasks;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберрите пожалуйста хоть что-то :)");
                return;
            }
            else
            {
                App.DB.tasks.Remove(selectedItem);
                App.DB.SaveChanges();
                TaskListDG.ItemsSource = App.DB.tasks.ToList();
            }
           
        }
    }
}
