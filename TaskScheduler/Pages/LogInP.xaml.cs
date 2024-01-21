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
    /// Логика взаимодействия для LogInP.xaml
    /// </summary>
    static class DataUs
    {
        public static int id { get; set; }
    }
    public partial class LogInP : Page
    {
        public LogInP()
        {
            InitializeComponent();
            loginTB.Text = "ssshurup";
            PassTB.Text = "Password1";
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterP());
        }

        private void SignInBTN_Click(object sender, RoutedEventArgs e)
        {

            var user = App.DB.users.Where(a => a.login == loginTB.Text);
            if (user.Any() == true)
            {
                foreach (users us in user)
                {
                    if (us.password == PassTB.Text)
                    {
                        DataUs.id = us.id;
                        NavigationService.Navigate(new UserP());
                    }
                    else MessageBox.Show("Неверный пароль");
                }
            }
            else MessageBox.Show("Неверное имя пользователя");

        }

        private void AdmBTN_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}