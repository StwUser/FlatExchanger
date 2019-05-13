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
using System.Windows.Shapes;
using System.IO;


namespace FlatExchanger
{

    /// <summary>
    /// Логика взаимодействия для LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public string userLogin { get; set; }
        public string userPas { get; set; }
        public string adminLogin{ get; set; }
        public string adminPas { get; set; }

        public LoginScreen()
        {
            InitializeComponent();
            // Login from data File
            // User Aut
            // запись в файл
            using (FileStream fstream = new FileStream(@"ul.dat", FileMode.OpenOrCreate))
            {
                
            }
            // чтение из файла
            using (FileStream fstream = File.OpenRead(@"ul.dat"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                userLogin = System.Text.Encoding.Default.GetString(array);
            }
            using (FileStream fstream = new FileStream(@"up.dat", FileMode.OpenOrCreate))
            {

            }
            // чтение из файла
            using (FileStream fstream = File.OpenRead(@"up.dat"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                userPas = System.Text.Encoding.Default.GetString(array);
            }
            // Admin Aut
            // запись в файл
            using (FileStream fstream = new FileStream(@"al.dat", FileMode.OpenOrCreate))
            {

            }
            // чтение из файла
            using (FileStream fstream = File.OpenRead(@"al.dat"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                adminLogin = System.Text.Encoding.Default.GetString(array);
            }
            using (FileStream fstream = new FileStream(@"ap.dat", FileMode.OpenOrCreate))
            {

            }
            // чтение из файла
            using (FileStream fstream = File.OpenRead(@"ap.dat"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                adminPas = System.Text.Encoding.Default.GetString(array);
            }
        }

        //Input like guest
        private void InputBtn2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            //access to dashboard.adminTab.IsEnabled = false;
            this.Close();
        }

        // Login check
        private void InputBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tbLoginEmploye.Text == userLogin && tbPasswordFiled.Password == userPas)
            {
                MainWindow dashboard = new MainWindow();
                dashboard.Show();


                //access to dashboard. Tabs
                dashboard.tabSearchOfCounterOption.IsEnabled = true;
                dashboard.tabAddFlat.IsEnabled = true;
                //dashboard.tabAdministrator.IsEnabled = true;
                dashboard.btnDeleteFlatInSearchForm.IsEnabled = true;
                dashboard.btnSearchCounterForm.IsEnabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы неправильно ввели пароль или логин.\nПопробуйте еще раз.");    
            }
        }

        private void AdminInputBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tbAdminLogin.Text == adminLogin && pasBoxAdminPasswordFiled.Password == adminPas)
            {
                MainWindow dashboard = new MainWindow();
                dashboard.Show();

                //Fill logins and passwords in Admin window 
                dashboard.adminUserLogin.Text = userLogin;
                dashboard.adminUserPas.Text = userPas;
                dashboard.adminAdminLogin.Text = adminLogin;
                dashboard.adminAdmibPas.Text = adminPas;
                //access to dashboard. Tabs
                dashboard.tabSearchOfCounterOption.IsEnabled = true;
                dashboard.tabAddFlat.IsEnabled = true;
                dashboard.tabAdministrator.IsEnabled = true;
                dashboard.btnDeleteFlatInSearchForm.IsEnabled = true;
                dashboard.btnSearchCounterForm.IsEnabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы неправильно ввели пароль или логин.\nПопробуйте еще раз.");
            }
        }
    }
}
