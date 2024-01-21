using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegisterP.xaml
    /// </summary>
    public partial class RegisterP : Page
    {
        public RegisterP()
        {
            InitializeComponent();
        }
        public static bool IsNameTrue(string name)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var isValidated = hasNumber.IsMatch(name) && hasUpperChar.IsMatch(name) && hasMinimum8Chars.IsMatch(name);
            return isValidated;
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            int countProblems = 0;
            if (PassTB.Text != Pass2TB.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                Pass2TB.Text = string.Empty;
                PassTB.Text = string.Empty;
                countProblems++;
            }
            else if (IsNameTrue(Pass2TB.Text) == false)
            {
                MessageBox.Show("Такой пароль делать низя");
                Pass2TB.Text = string.Empty;
                PassTB.Text = string.Empty;
                countProblems++;
            }

            var user = App.DB.users.Where(a => a.login == LogInTB.Text);
            if (user.Any() == true)
            {
                MessageBox.Show("Данное имя пользователя уже занято");
                countProblems++;
            }



            if (countProblems == 0)
            {
                users us = new users();
                us.name = NameTB.Text;
                us.login = LogInTB.Text;
                us.password = PassTB.Text;
                App.DB.users.Add(us);
                App.DB.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно");
                NavigationService.Navigate(new LogInP());
            }

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogInP());
        }
    }
}
