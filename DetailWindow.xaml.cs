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
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Drawing;

namespace FlatExchanger
{
    /// <summary>
    /// Логика взаимодействия для DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        //Stuff for work with Base
        SqlConnection sqlCon = new SqlConnection(@"user id=userLogin;pwd=pwd;data source=adress os source;persist security info=False;initial catalog=Catalog");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public DetailWindow()
        {
            InitializeComponent();


            
        }


        // Show all message from add condition block
        private void DescriptionAddConditions_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(descriptionAddConditions.Text);
        }
        // Large Image In Description Part
        private void DescriptionImage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(descriptionImage1);
            imageBoard.Show();
        }

        private void DescriptionImage2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(descriptionImage2);
            imageBoard.Show();
        }

        private void DescriptionImage3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(descriptionImage3);
            imageBoard.Show();
        }

        private void DescriptionImage4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(descriptionImage4);
            imageBoard.Show();
        }

        private void DescriptionImage5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(descriptionImage5);
            imageBoard.Show();
        }

        private void DescriptionImage6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(descriptionImage6);
            imageBoard.Show();
        }

        private void DescriptionImage7_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(descriptionImage7);
            imageBoard.Show();
        }
    }
}
