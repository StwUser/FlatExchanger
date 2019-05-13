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
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace FlatExchanger
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SQL CONNECT
        // SQL connection
        SqlConnection sqlCon; 
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter daCondition = new SqlDataAdapter();
        SqlDataAdapter daForSearch = new SqlDataAdapter();
        DataTable dtForSearch = new DataTable();
        DataTable dtForSearch2 = new DataTable();

        SqlDataAdapter daConditionDescription = new SqlDataAdapter();
        DataTable dtConditionDescription = new DataTable();

        SqlDataAdapter daFindVariants = new SqlDataAdapter();
        DataTable dtFindVariants = new DataTable();

        SqlDataAdapter daOffer = new SqlDataAdapter();
        DataTable dtOffer = new DataTable();

        DataSet dsCondition = new DataSet();
        DataTable dtCondition = new DataTable();
        DataTable dtCondition2 = new DataTable();
        DataTable dtCondition3 = new DataTable();

        //Filed For Logic
        byte[] data = null;
        string path;
        string label;

        string picPath;
        string picLabel;

        string sqlTableName = null;

        public static string wayTobase { get; set; }

        public MainWindow()
        {
            // Way TO DataBase
            using (FileStream fstream = new FileStream(@"db.dat", FileMode.OpenOrCreate))
            {

            }
            // чтение из файла
            using (FileStream fstream = File.OpenRead(@"db.dat"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                wayTobase = System.Text.Encoding.Default.GetString(array);

                //Initialize way To Data Base
                sqlCon = new SqlConnection(@""+wayTobase);

            }

            InitializeComponent();

            //Fill Admin Window Way Ti Base
            adminWaytoBase.Text = wayTobase;
        }

        // Add buttons Picture Block
        private void bAddPic1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                picPath = fd.FileName;
                picLabel = fd.SafeFileName;
                iPic1.Source = new BitmapImage(new Uri(picPath));
                tbWayTopic1.Text = picPath;
            }
        }
        private void bAddPic2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                picPath = fd.FileName;
                picLabel = fd.SafeFileName;
                iPic2.Source = new BitmapImage(new Uri(picPath));
                tbWayTopic2.Text = picPath;
            }
        }
        private void bAddPic3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                picPath = fd.FileName;
                picLabel = fd.SafeFileName;
                iPic3.Source = new BitmapImage(new Uri(picPath));
                tbWayTopic3.Text = picPath;
            }
        }
        private void bAddPic4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                picPath = fd.FileName;
                picLabel = fd.SafeFileName;
                iPic4.Source = new BitmapImage(new Uri(picPath));
                tbWayTopic4.Text = picPath;
            }
        }
        private void bAddPic5_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                picPath = fd.FileName;
                picLabel = fd.SafeFileName;
                iPic5.Source = new BitmapImage(new Uri(picPath));
                tbWayTopic5.Text = picPath;
            }
        }
        private void bAddPic6_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                picPath = fd.FileName;
                picLabel = fd.SafeFileName;
                iPic6.Source = new BitmapImage(new Uri(picPath));
                tbWayTopic6.Text = picPath;
            }
        }
        private void bAddPic7_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                picPath = fd.FileName;
                picLabel = fd.SafeFileName;
                iPic7.Source = new BitmapImage(new Uri(picPath));
                tbWayTopic7.Text = picPath;
            }
        }
        // Large Pictures Block
        private void iPic1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(iPic1.Source.ToString());
            imageBoard.Show();
        }
        private void iPic2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(iPic2.Source.ToString());
            imageBoard.Show();
        }
        private void iPic3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(iPic3.Source.ToString());
            imageBoard.Show();
        }
        private void iPic4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(iPic4.Source.ToString());
            imageBoard.Show();
        }
        private void iPic5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(iPic5.Source.ToString());
            imageBoard.Show();
        }
        private void iPic6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(iPic6.Source.ToString());
            imageBoard.Show();
        }
        private void iPic7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowLargeImage imageBoard = new WindowLargeImage(iPic7.Source.ToString());
            imageBoard.Show();
        }
        // HELP FUNCTIONS
        // Work with BASE
        static public string getItemName(object sender)  //return item Name
        {

                ComboBox comboBox = (ComboBox)sender;
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

                return selectedItem.Name.ToString();

        }
        // Send Picture to DataBAse
        static public void sendImageToDB(string sqlTableName, string path, int idMaster, string label,int idServant, SqlConnection sqlCon)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            byte[] data;
            data = System.IO.File.ReadAllBytes(path);

            da.InsertCommand = new SqlCommand("INSERT INTO " + sqlTableName + " VALUES(@ID_MASTER, @ID_SERVANT, @LABEL, @FLAT_IMAGE)", sqlCon);

            da.InsertCommand.Parameters.Add("@ID_MASTER", SqlDbType.Int).Value = idMaster;
            da.InsertCommand.Parameters.Add("@ID_SERVANT", SqlDbType.Int).Value = idServant;
            da.InsertCommand.Parameters.Add("@LABEL", SqlDbType.NChar).Value = label;
            da.InsertCommand.Parameters.AddWithValue("@FLAT_IMAGE", data);

            sqlCon.Open();
            da.InsertCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        // Hide All Items in Obj
        static public void hideAllItems(object sender)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            foreach (ComboBoxItem item in comboBox.Items)
            {
                item.Visibility = Visibility.Collapsed;
            }
        }

        //                      TAB ADD NEW FLAT
        // Filter Visibility for District Condition
        private void cbDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            hideAllItems(cbMicroDistrict);  // Hide All Items Micro Districts

            if(selectedItem.Content.ToString() == "Центральный")  //Make visible MicroDistricts
            {
                // Блок Центрального Район
                cbMicroC1.Visibility = Visibility.Visible;
                cbMicroC2.Visibility = Visibility.Visible;
                cbMicroC3.Visibility = Visibility.Visible;
                cbMicroC4.Visibility = Visibility.Visible;
                cbMicroC5.Visibility = Visibility.Visible;
                cbMicroC6.Visibility = Visibility.Visible;
                cbMicroC7.Visibility = Visibility.Visible;
                cbMicroC8.Visibility = Visibility.Visible;
                cbMicroC9.Visibility = Visibility.Visible;
                cbMicroC10.Visibility = Visibility.Visible;
            }
            if(selectedItem.Content.ToString() == "Первомайский")  //Make visible MicroDistricts
            {
                // Блок Центрального Район
                cbMicroP1.Visibility = Visibility.Visible;
                cbMicroP2.Visibility = Visibility.Visible;
                cbMicroP3.Visibility = Visibility.Visible;
                cbMicroP4.Visibility = Visibility.Visible;
                cbMicroP5.Visibility = Visibility.Visible;
                cbMicroP6.Visibility = Visibility.Visible;
                cbMicroP7.Visibility = Visibility.Visible;
                cbMicroP8.Visibility = Visibility.Visible;
                cbMicroP9.Visibility = Visibility.Visible;
                cbMicroP10.Visibility = Visibility.Visible;
            }
            sqlTableName = getItemName(cbDistrictAddForm);
        }
        // SHOW MicroDistricts in Conditions Part
        private void CbDistrictCondition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            hideAllItems(cbMicroDistrictCondition);  // Hide All Items Micro Districts

            if (selectedItem.Content.ToString() == "Центральный")  //Make visible MicroDistricts
            {
                // Блок Центрального Район
                conMicroC1.Visibility = Visibility.Visible;
                conMicroC2.Visibility = Visibility.Visible;
                conMicroC3.Visibility = Visibility.Visible;
                conMicroC4.Visibility = Visibility.Visible;
                conMicroC5.Visibility = Visibility.Visible;
                conMicroC6.Visibility = Visibility.Visible;
                conMicroC7.Visibility = Visibility.Visible;
                conMicroC8.Visibility = Visibility.Visible;
                conMicroC9.Visibility = Visibility.Visible;
                conMicroC10.Visibility = Visibility.Visible;
            }
            if (selectedItem.Content.ToString() == "Первомайский")  //Make visible MicroDistricts
            {
                // Блок Центрального Район
                conMicroP1.Visibility = Visibility.Visible;
                conMicroP2.Visibility = Visibility.Visible;
                conMicroP3.Visibility = Visibility.Visible;
                conMicroP4.Visibility = Visibility.Visible;
                conMicroP5.Visibility = Visibility.Visible;
                conMicroP6.Visibility = Visibility.Visible;
                conMicroP7.Visibility = Visibility.Visible;
                conMicroP8.Visibility = Visibility.Visible;
                conMicroP9.Visibility = Visibility.Visible;
                conMicroP10.Visibility = Visibility.Visible;
            }
        }
        //Enable to Send to Base Button
        private void CbMicroDistrict_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            btnAdd.IsEnabled = true;
        }
        //WORK WITH BASE
        //ADD Main Flats To Base
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {   

            if (sqlCon.State.ToString()!="Closed")
            {
                sqlCon.Close();
                MessageBox.Show("Подключение было закрыто.");
            }

            try
            {

               // sqlTableName = getItemName(cbDistrictAddForm);  ///not NEED!!!

                da.InsertCommand = new SqlCommand("INSERT INTO " + sqlTableName + " VALUES(@DISTRICT, @MICRODISTRICT, @STREET, @HOUSE_NUMBER, @HOUSE_CORP, @PHONE_NUMBER1, @PHONE_NUMBER2, @CONTACT_PERSON,  @AGENCY, @ROOMS_TOTAL, @ROOMS_SEPARATE, @FLOOR, @FLOOR_TOTAL, @AREA_COMMON, @AREA_LIVING, @AREA_KITCHEN, @CONSTRUCTION_YEAR, @PRICE, @ADD_INFO, @FILL_DATE)", sqlCon);

                da.InsertCommand.Parameters.Add("@DISTRICT", SqlDbType.NVarChar).Value = cbDistrictAddForm.Text;

                da.InsertCommand.Parameters.Add("@MICRODISTRICT", SqlDbType.NVarChar).Value = cbMicroDistrict.Text;

                da.InsertCommand.Parameters.Add("@STREET", SqlDbType.NVarChar).Value = tbAddStreet.Text;

                da.InsertCommand.Parameters.Add("@HOUSE_NUMBER", SqlDbType.NVarChar).Value = tbAddHouseNumber.Text;

                da.InsertCommand.Parameters.Add("@HOUSE_CORP", SqlDbType.NVarChar).Value = tbAddHouseCorp.Text;

                da.InsertCommand.Parameters.Add("@PHONE_NUMBER1", SqlDbType.NVarChar).Value = tbAddPhoneNumber1.Text;

                da.InsertCommand.Parameters.Add("@PHONE_NUMBER2", SqlDbType.NVarChar).Value = tbAddPhoneNumber2.Text;

                da.InsertCommand.Parameters.Add("@CONTACT_PERSON", SqlDbType.NVarChar).Value = tbAddContactPerson.Text;

                da.InsertCommand.Parameters.Add("@AGENCY", SqlDbType.NVarChar).Value = tbAddAgency.Text;

                da.InsertCommand.Parameters.Add("@ROOMS_TOTAL", SqlDbType.NVarChar).Value = tbAddRoomsTotal.Text;

                da.InsertCommand.Parameters.Add("@ROOMS_SEPARATE", SqlDbType.NVarChar).Value = tbAddRoomsSeparate.Text;

                da.InsertCommand.Parameters.Add("@FLOOR", SqlDbType.NVarChar).Value = tbAddFloor.Text;

                da.InsertCommand.Parameters.Add("@FLOOR_TOTAL", SqlDbType.NVarChar).Value = tbAddFloorTotal.Text;

                da.InsertCommand.Parameters.Add("@AREA_COMMON", SqlDbType.NVarChar).Value = tbAddAreaCommon.Text;

                da.InsertCommand.Parameters.Add("@AREA_LIVING", SqlDbType.NVarChar).Value = tbAddAreaLiving.Text;

                da.InsertCommand.Parameters.Add("@AREA_KITCHEN", SqlDbType.NVarChar).Value = tbAAddreaKitchen.Text;

                da.InsertCommand.Parameters.Add("@CONSTRUCTION_YEAR", SqlDbType.NVarChar).Value = tbAddConstructionYear.Text;

                da.InsertCommand.Parameters.Add("@PRICE", SqlDbType.NVarChar).Value = tbAddPrice.Text;

                da.InsertCommand.Parameters.Add("@ADD_INFO", SqlDbType.NVarChar).Value = tbAddAddInfo.Text;

                String strCurrentDate = null;
                strCurrentDate = DateTime.Now.ToString("dd/MM/yyyy");

                da.InsertCommand.Parameters.Add("@FILL_DATE", SqlDbType.NVarChar).Value = strCurrentDate;

                sqlCon.Open();

                da.InsertCommand.ExecuteNonQuery();
                sqlCon.Close();

                // Get from base Last Add Flat info
                da.SelectCommand = new SqlCommand("SELECT ID AS[ID], DISTRICT[Район], MICRODISTRICT[Микрорайон], STREET[Улица], HOUSE_NUMBER[Номер дома], FLOOR_TOTAL[Всего комнат], PRICE[Цена], FILL_DATE[Дата] FROM " + sqlTableName + " WHERE ID = (SELECT max(id) FROM " + sqlTableName + ")", sqlCon);
                sqlCon.Open();
                da.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();
                dt.Clear();

                da.Fill(dt);

                dgCurrentAddFlatAdminTab.ItemsSource = dt.DefaultView;

                Object idCellValue = dt.Rows[0][0];
                int idMaster = Convert.ToInt32(idCellValue);

                //Send Pictures To DataBase
                string sqlImageTable = sqlTableName + "_IMAGES";

                if (tbWayTopic1.Text != "Фото 1")
                    sendImageToDB(sqlImageTable, tbWayTopic1.Text, idMaster, iPic1.Name, 1, sqlCon);
                else
                    sendImageToDB(sqlImageTable, "Pictures/no_photo.jpg", idMaster, iPic1.Name, 1, sqlCon);
                if (tbWayTopic2.Text != "Фото 2")
                    sendImageToDB(sqlImageTable, tbWayTopic2.Text, idMaster, iPic2.Name, 2, sqlCon);
                else
                    sendImageToDB(sqlImageTable, "Pictures/no_photo.jpg", idMaster, iPic2.Name, 2, sqlCon);
                if (tbWayTopic3.Text != "Фото 3")
                    sendImageToDB(sqlImageTable, tbWayTopic3.Text, idMaster, iPic3.Name, 3, sqlCon);
                else
                    sendImageToDB(sqlImageTable, "Pictures/no_photo.jpg", idMaster, iPic3.Name, 3, sqlCon);
                if (tbWayTopic4.Text != "Фото 4")
                    sendImageToDB(sqlImageTable, tbWayTopic4.Text, idMaster, iPic4.Name, 4, sqlCon);
                else
                    sendImageToDB(sqlImageTable, "Pictures/no_photo.jpg", idMaster, iPic4.Name, 4, sqlCon);
                if (tbWayTopic5.Text != "Фото 5")
                    sendImageToDB(sqlImageTable, tbWayTopic5.Text, idMaster, iPic5.Name, 5, sqlCon);
                else
                    sendImageToDB(sqlImageTable, "Pictures/no_photo.jpg", idMaster, iPic5.Name, 5, sqlCon);
                if (tbWayTopic6.Text != "Фото 6")
                    sendImageToDB(sqlImageTable, tbWayTopic6.Text, idMaster, iPic6.Name, 6, sqlCon);
                else
                    sendImageToDB(sqlImageTable, "Pictures/no_photo.jpg", idMaster, iPic6.Name, 6, sqlCon);
                if (tbWayTopic7.Text != "Фото 7")
                    sendImageToDB(sqlImageTable, tbWayTopic7.Text, idMaster, iPic7.Name, 7, sqlCon);
                else
                    sendImageToDB(sqlImageTable, "Pictures/no_photo.jpg", idMaster, iPic7.Name, 7, sqlCon);

                // TO ENABLED REMAINING Buttons
                AddCodition.IsEnabled = true;
                MessageBox.Show("Квартира добавлена в базу.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не указали район.");
                MessageBox.Show(ex.Message);
            }
        }
        // ADD CONDITION FOR SEARCH SECTION
        private void AddCodition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Object idCellValue = dt.Rows[0][0];
                string idMaster = idCellValue.ToString();

                Object districtCellValue = dt.Rows[0][1];


                if (districtCellValue.ToString() == "Первомайский")
                {
                    sqlTableName = "PERVOMAYSKIY_CONDITION";
                }
                else if (districtCellValue.ToString() == "Центральный")
                {
                    sqlTableName = "TSENTRALNYY_CONDITION";
                }
                else
                {
                    sqlTableName = null;
                }

                da.InsertCommand = new SqlCommand("INSERT INTO " + sqlTableName + " VALUES(@ID_MASTER, @DISTRICT_CONDITION, @MICRODISTRICT_CONDITION, @STREET_CONDITION, @ROOMS_TOTAL_CONDITION,  @AREA_COMMON_CONDITION,  @PRICECONDITION )", sqlCon);

                da.InsertCommand.Parameters.Add("@ID_MASTER", SqlDbType.Int).Value = idMaster;

                da.InsertCommand.Parameters.Add("@DISTRICT_CONDITION", SqlDbType.NVarChar).Value = cbDistrictCondition.Text;

                da.InsertCommand.Parameters.Add("@MICRODISTRICT_CONDITION", SqlDbType.NVarChar).Value = cbMicroDistrictCondition.Text;

                da.InsertCommand.Parameters.Add("@STREET_CONDITION", SqlDbType.NVarChar).Value = cbStreetCondition.Text;

                da.InsertCommand.Parameters.Add("@ROOMS_TOTAL_CONDITION", SqlDbType.NVarChar).Value = tbRoomsCondition.Text;

                da.InsertCommand.Parameters.Add("@AREA_COMMON_CONDITION", SqlDbType.NVarChar).Value = tbAreaCommonCondition.Text;

                da.InsertCommand.Parameters.Add("@PRICECONDITION", SqlDbType.NVarChar).Value = tbPriceCondition.Text;

                sqlCon.Open();
                da.InsertCommand.ExecuteNonQuery();
                sqlCon.Close();

                //daCondition.SelectCommand = new SqlCommand("SELECT ID_MASTER AS[ID M], ID_SERVANT[ID S], DISTRICT_CONDITION[Район], MICRODISTRICT_CONDITION[Микро Район], STREET_CONDITION[Улица], ROOMS_TOTAL_CONDITION[Комнат], AREA_COMMON_CONDITION[Площадь], PRICECONDITION[Цена] FROM "+ sqlTableName, sqlCon);

                daCondition.SelectCommand = new SqlCommand("SELECT ID_MASTER AS[ID M], ID_SERVANT[ID S], DISTRICT_CONDITION[Район], MICRODISTRICT_CONDITION[Микро Район], STREET_CONDITION[Улица], ROOMS_TOTAL_CONDITION[Комнат], AREA_COMMON_CONDITION[Площадь], PRICECONDITION[Цена] FROM " + sqlTableName + " WHERE ID_MASTER= " + idMaster, sqlCon);

                sqlCon.Open();
                daCondition.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtCondition.Clear();

                daCondition.Fill(dtCondition);

                dgCurrentAddFlatCondition.ItemsSource = dtCondition.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //  CONDITION DELETE DEMAND 
        private void BntAddFlatFormDeleteCondition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show(dgCurrentAddFlatCondition.SelectedIndex.ToString());
                int rowIndex = Convert.ToInt32(dgCurrentAddFlatCondition.SelectedIndex.ToString());
                Object idServant = dtCondition.Rows[rowIndex][1];
                //MessageBox.Show(idServant.ToString());

                MessageBoxResult dr;
                dr = MessageBox.Show("Вы действительно хотите удалить?\n", "Confirm", MessageBoxButton.YesNo);

                sqlTableName = getItemName(cbDistrictAddForm);
                Object idCellValue = dt.Rows[0][0];
                string idMaster = idCellValue.ToString();

                if (dr == MessageBoxResult.Yes)
                {
                    da.DeleteCommand = new SqlCommand("DELETE " + sqlTableName + "_CONDITION WHERE ID_SERVANT =" + idServant.ToString(), sqlCon);
                    sqlCon.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show("Объект успешно удален");
                }
                else
                {
                    MessageBox.Show("Удаление отменено");
                }

                //UPDATE Grid of Conditions
                idCellValue = dt.Rows[0][0];
                idMaster = idCellValue.ToString();

                Object districtCellValue = dt.Rows[0][1];
        

                if (districtCellValue.ToString() == "Первомайский")
                {
                    sqlTableName = "PERVOMAYSKIY_CONDITION";
                }
                else if (districtCellValue.ToString() == "Центральный")
                {
                    sqlTableName = "TSENTRALNYY_CONDITION";
                }
                else
                {
                    sqlTableName = null;
                }

                daCondition.SelectCommand = new SqlCommand("SELECT ID_MASTER AS[ID M], ID_SERVANT[ID S], DISTRICT_CONDITION[Район], MICRODISTRICT_CONDITION[Микро Район], STREET_CONDITION[Улица], ROOMS_TOTAL_CONDITION[Комнат], AREA_COMMON_CONDITION[Площадь], PRICECONDITION[Цена] FROM " + sqlTableName + " WHERE ID_MASTER= " + idMaster, sqlCon);

                sqlCon.Open();
                daCondition.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtCondition.Clear();

                daCondition.Fill(dtCondition);

                dgCurrentAddFlatCondition.ItemsSource = dtCondition.DefaultView;

                districtCellValue = null;
                idCellValue = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ADMIN TAB
        private void AdminSetWayToBase_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fstream = new FileStream(@"db.dat", FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(adminWaytoBase.Text);
                MessageBox.Show(adminWaytoBase.Text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                MessageBox.Show("Путь к базе данных изменен на "+ adminWaytoBase.Text);
            }
        }

        private void AdminSetNewUserLogin_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fstream = new FileStream(@"ul.dat", FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(adminUserLogin.Text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                MessageBox.Show("Логин пользователя изменен на "+ adminUserLogin.Text);
            }
        }

        private void AdminSetNewUserPas_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fstream = new FileStream(@"up.dat", FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(adminUserPas.Text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                MessageBox.Show("Пароль пользователя изменен на "+ adminUserPas.Text);
            }
        }

        private void AdminSetAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fstream = new FileStream(@"al.dat", FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(adminAdminLogin.Text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                MessageBox.Show("Логин администратора изменен на " + adminAdminLogin.Text);
            }
        }

        private void AdminSetAdminPas_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fstream = new FileStream(@"ap.dat", FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(adminAdmibPas.Text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                MessageBox.Show("Пароль администратора изменен на " + adminAdmibPas.Text);
            }
        }
        //                      TAB SEARCH FLAT
        //  Change ComboBox in Search TAB
        private void CbSearchTabDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            hideAllItems(cbSearchTabMicroDistrictX);  // Hide All Items Micro Districts

            if (selectedItem.Content.ToString() == "Центральный")  //Make visible MicroDistricts
            {
                // Блок Центрального Район
                cbSearchTabMicroC0.Visibility = Visibility.Visible;
                cbSearchTabMicroC1.Visibility = Visibility.Visible;
                cbSearchTabMicroC2.Visibility = Visibility.Visible;
                cbSearchTabMicroC3.Visibility = Visibility.Visible;
                cbSearchTabMicroC4.Visibility = Visibility.Visible;
                cbSearchTabMicroC5.Visibility = Visibility.Visible;
                cbSearchTabMicroC6.Visibility = Visibility.Visible;
                cbSearchTabMicroC7.Visibility = Visibility.Visible;
                cbSearchTabMicroC8.Visibility = Visibility.Visible;
                cbSearchTabMicroC9.Visibility = Visibility.Visible;
                cbSearchTabMicroC10.Visibility = Visibility.Visible;
            }
            if (selectedItem.Content.ToString() == "Первомайский")  //Make visible MicroDistricts
            {
                // Блок Центрального Район
                cbSearchTabMicroC0.Visibility = Visibility.Visible;
                cbSearchTabMicroP1.Visibility = Visibility.Visible;
                cbSearchTabMicroP2.Visibility = Visibility.Visible;
                cbSearchTabMicroP3.Visibility = Visibility.Visible;
                cbSearchTabMicroP4.Visibility = Visibility.Visible;
                cbSearchTabMicroP5.Visibility = Visibility.Visible;
                cbSearchTabMicroP6.Visibility = Visibility.Visible;
                cbSearchTabMicroP7.Visibility = Visibility.Visible;
                cbSearchTabMicroP8.Visibility = Visibility.Visible;
                cbSearchTabMicroP9.Visibility = Visibility.Visible;
                cbSearchTabMicroP10.Visibility = Visibility.Visible;
            }

        }
        // Search TAb Search Button
        private void BtnSearchFornFind_Click(object sender, RoutedEventArgs e)
        {
            //Test for Closed connection
            if (sqlCon.State.ToString() != "Closed")
            {
                sqlCon.Close();
                MessageBox.Show("Подключение было закрыто.");
            }
            try
            {

                if (cbSearchTabDistrict.Text == "Первомайский")
                {
                    sqlTableName = "PERVOMAYSKIY";
                }
                else if (cbSearchTabDistrict.Text == "Центральный")
                {
                    sqlTableName = "TSENTRALNYY";
                }
                else
                {
                    sqlTableName = null;
                }

                string microDistrictSearch = null;
                string streetSearchCondition = null;
                string roomsSearchCondition = null;
                string priceSearchCondition = null;
                string areaCommonCondition = null;

                if (cbSearchTabMicroDistrictX.Text != "Не указан")
                {
                    microDistrictSearch = " AND MICRODISTRICT =  N'" + cbSearchTabMicroDistrictX.Text + "'";
                }
                if (cbSearchTabStreet.Text != null)
                {
                    //MessageBox.Show(cbSearchTabStreet.Text);
                    streetSearchCondition = " AND STREET LIKE N'%" + cbSearchTabStreet.Text + "%'";
                }
                if (cbRoomsSearchCondition.Text != "Не указано")
                {
                    //MessageBox.Show(cbRoomsSearchCondition.Text);
                    roomsSearchCondition = " AND ROOMS_TOTAL = '" + cbRoomsSearchCondition.Text + "'";
                }
                if (searchTabPrice2.Text != "")
                {
                    priceSearchCondition = " AND PRICE " + searchTabPrice1.Text + searchTabPrice2.Text;
                    //MessageBox.Show(roomsSearchCondition);
                }
                if (searchTabArea2.Text != "")
                {
                    areaCommonCondition = " AND AREA_COMMON " + searchTabArea1.Text + searchTabArea2.Text;
                    //MessageBox.Show(roomsSearchCondition);
                }

                //Name="searchTabArea1"
                // MessageBox.Show(microDistrictSearch);

                daForSearch.SelectCommand = new SqlCommand("SELECT ID AS[ID], DISTRICT[Район], MICRODISTRICT[Микро Район], STREET[Улица], HOUSE_NUMBER[Номер дома], HOUSE_CORP[Корпус], ROOMS_TOTAL[Комнат], AREA_COMMON[Площадь], PRICE[Цена], FILL_DATE[Дата подачи объявления] FROM " + sqlTableName + " WHERE ID > 0 " + microDistrictSearch + streetSearchCondition + roomsSearchCondition + priceSearchCondition + areaCommonCondition, sqlCon);

                sqlCon.Open();
                daForSearch.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtForSearch.Clear();

                daForSearch.Fill(dtForSearch);

                dgSearchForm.ItemsSource = dtForSearch.DefaultView;

                microDistrictSearch = null;
                streetSearchCondition = null;
                roomsSearchCondition = null;
                priceSearchCondition = null;
                areaCommonCondition = null;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgSearchForm_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {

                if (cbSearchTabDistrict.Text == "Первомайский")
                {
                    sqlTableName = "PERVOMAYSKIY";
                }
                else if (cbSearchTabDistrict.Text == "Центральный")
                {
                    sqlTableName = "TSENTRALNYY";
                }
                else
                {
                    sqlTableName = null;
                }

                int rowIndex = Convert.ToInt32(dgSearchForm.SelectedIndex.ToString());
                Object idMain = dtForSearch.Rows[rowIndex][0];

                
                daForSearch.SelectCommand = new SqlCommand("SELECT ID AS[ID], DISTRICT[Район], MICRODISTRICT[Микро Район], STREET[Улица], HOUSE_NUMBER[Номер дома], HOUSE_CORP[Корпус], ROOMS_TOTAL[Комнат], FLOOR[Этаж], CONSTRUCTION_YEAR[Год постройки], AREA_COMMON[Площадь], PRICE[Цена], FILL_DATE[Дата подачи объявления] FROM " + sqlTableName + " WHERE ID = "+ idMain , sqlCon);

                sqlCon.Open();
                daForSearch.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtForSearch2.Clear();

                daForSearch.Fill(dtForSearch2);

                dgCurrentAddFlat.ItemsSource = dtForSearch2.DefaultView;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
        // Delete Flat From Base from Search Tab
        private void BtnDeleteFlatInSearchForm_Click(object sender, RoutedEventArgs e)
        {
            if (cbSearchTabDistrict.Text == "Первомайский")
            {
                sqlTableName = "PERVOMAYSKIY";
            }
            else if (cbSearchTabDistrict.Text == "Центральный")
            {
                sqlTableName = "TSENTRALNYY";
            }
            else
            {
                sqlTableName = null;
            }

            int rowIndex = Convert.ToInt32(dgSearchForm.SelectedIndex.ToString());
            Object idMain = dtForSearch.Rows[rowIndex][0];

            MessageBoxResult dr;
            dr = MessageBox.Show("Вы действительно хотите удалить?\n", "Confirm", MessageBoxButton.YesNo);

            if (cbSearchTabDistrict.Text == "Первомайский")
            {
                sqlTableName = "PERVOMAYSKIY";
            }
            else if (cbSearchTabDistrict.Text == "Центральный")
            {
                sqlTableName = "TSENTRALNYY";
            }
            else
            {
                sqlTableName = null;
            }

            if (dr == MessageBoxResult.Yes)
            {
                da.DeleteCommand = new SqlCommand("DELETE " + sqlTableName + " WHERE ID =" + idMain.ToString(), sqlCon);
                sqlCon.Open();
                da.DeleteCommand.ExecuteNonQuery();
                sqlCon.Close();

                da.DeleteCommand = new SqlCommand("DELETE " + sqlTableName + "_CONDITION WHERE ID_MASTER =" + idMain.ToString(), sqlCon);
                sqlCon.Open();
                da.DeleteCommand.ExecuteNonQuery();
                sqlCon.Close();

                da.DeleteCommand = new SqlCommand("DELETE " + sqlTableName + "_IMAGES WHERE ID_MASTER =" + idMain.ToString(), sqlCon);
                sqlCon.Open();
                da.DeleteCommand.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Объект успешно удален");
            }
            else
            {
                MessageBox.Show("Удаление отменено");
            }

            // Push Find Button to update Form of Search
            BtnSearchFornFind_Click(sender, e);
        }

        //Open Window With DETAILS
        private void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DetailWindow detailWindow = new DetailWindow();
                detailWindow.Show();


                if (cbSearchTabDistrict.Text == "Первомайский")
                {
                    sqlTableName = "PERVOMAYSKIY";
                }
                else if (cbSearchTabDistrict.Text == "Центральный")
                {
                    sqlTableName = "TSENTRALNYY";
                }
                else
                {
                    sqlTableName = null;
                }

                int rowIndex = Convert.ToInt32(dgSearchForm.SelectedIndex.ToString());
                Object idMain = dtForSearch.Rows[rowIndex][0];

                daForSearch.SelectCommand = new SqlCommand("SELECT * FROM " + sqlTableName + " WHERE ID = " + idMain.ToString(), sqlCon);

                sqlCon.Open();
                daForSearch.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtCondition3.Clear();

                daForSearch.Fill(dtCondition3);

                // Fill the fields of Description Form
                detailWindow.descriptionFilldate.Text = dtCondition3.Rows[0][20].ToString();
                detailWindow.descriptionDistrict.Text = dtCondition3.Rows[0][1].ToString();
                detailWindow.descriptionStreet.Text = dtCondition3.Rows[0][3].ToString();
                detailWindow.descriptionHouseNumber.Text = dtCondition3.Rows[0][4].ToString();
                detailWindow.descriptionHouseCorp.Text = dtCondition3.Rows[0][5].ToString();
                detailWindow.descriptionContactName.Text = dtCondition3.Rows[0][8].ToString();
                detailWindow.descriptionAgency.Text = dtCondition3.Rows[0][9].ToString();
                detailWindow.descriptionPrice.Text = dtCondition3.Rows[0][18].ToString();
                detailWindow.descriptionPhone1.Text = dtCondition3.Rows[0][6].ToString();
                detailWindow.descriptionPhone2.Text = dtCondition3.Rows[0][7].ToString();
                detailWindow.descriptionRoomsTotal.Text = dtCondition3.Rows[0][10].ToString();
                detailWindow.descriptionRoomsSeparate.Text = dtCondition3.Rows[0][11].ToString();
                detailWindow.descriptionAreaTotal.Text = dtCondition3.Rows[0][14].ToString();
                detailWindow.descriptionAreaLiving.Text = dtCondition3.Rows[0][15].ToString();
                detailWindow.descriptionAreaKitchen.Text = dtCondition3.Rows[0][16].ToString();
                detailWindow.descriptionConstructionEyar.Text = dtCondition3.Rows[0][17].ToString();
                detailWindow.descriptionFloor.Text = dtCondition3.Rows[0][12].ToString();
                detailWindow.descriptionFloorTotal.Text = dtCondition3.Rows[0][13].ToString();
                detailWindow.descriptionAddConditions.Text = dtCondition3.Rows[0][19].ToString();

                LoadImageFromBase(detailWindow.descriptionImage1, "1");
                LoadImageFromBase(detailWindow.descriptionImage2, "2");
                LoadImageFromBase(detailWindow.descriptionImage3, "3");
                LoadImageFromBase(detailWindow.descriptionImage4, "4");
                LoadImageFromBase(detailWindow.descriptionImage5, "5");
                LoadImageFromBase(detailWindow.descriptionImage6, "6");
                LoadImageFromBase(detailWindow.descriptionImage7, "7");
                //Load Image From Base
                void LoadImageFromBase(Image imageToFill, string photoNumber)
                {
                    try
                    {
                        da.SelectCommand = new SqlCommand("SELECT FLAT_IMAGE FROM " + sqlTableName + "_IMAGES WHERE  ID_MASTER = " + idMain + " AND ID_SERVANT = " + photoNumber, sqlCon);
                        //MessageBox.Show("SELECT FLAT_IMAGE FROM " + sqlTableName + "_IMAGES WHERE  ID_MASTER = " + idMain + " AND ID_SERVANT = " + photoNumber);
                        sqlCon.Open();
                        SqlDataReader rd = da.SelectCommand.ExecuteReader();
                        // byte[] data;

                        while (rd.Read())
                        {
                            //int id = rd.GetInt32(0);
                            //string filename = rd.GetString(1);
                            //string title = rd.GetString(2);
                            data = (byte[])rd.GetValue(0);
                        }

                        BitmapImage img = new BitmapImage();
                        img = LoadImage(data);
                        imageToFill.Source = img;


                        sqlCon.Close();
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                // To Fill Detail Window                            SELECT ID AS[ID], DISTRICT[Район]
                daConditionDescription.SelectCommand = new SqlCommand("SELECT DISTRICT_CONDITION AS[Район], MICRODISTRICT_CONDITION[Микрорайон], STREET_CONDITION[Улица], ROOMS_TOTAL_CONDITION[Комнат], AREA_COMMON_CONDITION[Площадь], PRICECONDITION[Цена] FROM " + sqlTableName+"_CONDITION" + " WHERE ID_MASTER = " + idMain.ToString(), sqlCon);

                sqlCon.Open();
                daConditionDescription.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtConditionDescription.Clear();

                daConditionDescription.Fill(dtConditionDescription);

                detailWindow.dgDetailWindowCondition.ItemsSource = dtConditionDescription.DefaultView;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
        
        // Bytes to Image
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }


        // Search of Offer Flats TAB
        private void BtnSearchCounterForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgOurFlaitInOffer
                dgOurFlaitInOffer.ItemsSource = dtForSearch2.DefaultView;
                tabSearchOfCounterOption.IsSelected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //For Offer Variants strings
        string offerForDistrict = null;
        string offerForMicroDistrict = null;
        string offerForStreet = null;
        string offerForRooms = null;
        string offerForArea = null;
        string offerForPrice = null;

        private void BtnFindVariants_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string sqlOfferTableName = null;
                if (cbOffer.Text == "Первомайский")
                {
                    sqlOfferTableName = "PERVOMAYSKIY_CONDITION";
                }
                else if (cbOffer.Text == "Центральный")
                {
                    sqlOfferTableName = "TSENTRALNYY_CONDITION";
                }
                else
                {
                    sqlOfferTableName = null;
                }

                daFindVariants.SelectCommand = new SqlCommand("SELECT ID_MASTER FROM " + sqlOfferTableName + " WHERE ID_MASTER > 0" + offerForDistrict + offerForMicroDistrict + offerForStreet + offerForRooms + offerForArea + offerForPrice, sqlCon);
                //MessageBox.Show("SELECT ID_MASTER FROM " + sqlOfferTableName + " WHERE ID_MASTER > 0 " + offerForDistrict + offerForMicroDistrict + offerForStreet + offerForRooms + offerForArea + offerForPrice);

                sqlCon.Open();
                daFindVariants.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtFindVariants.Clear();

                daFindVariants.Fill(dtFindVariants);

                int numbPerv = dtFindVariants.Rows.Count;
                int[] collectionOfIdsPerv = new int[numbPerv];
                for (int i = 0; i < numbPerv; ++i)
                {
                    collectionOfIdsPerv[i] = Convert.ToChar(dtFindVariants.Rows[i][0]);
                }
                List<int> myCollectIdPerv = new List<int>();
                Array.Sort(collectionOfIdsPerv);
                myCollectIdPerv.Add(collectionOfIdsPerv[0]);
                for (int b = 0; b < collectionOfIdsPerv.Length - 1; b++)
                {
                    if (collectionOfIdsPerv[b] != collectionOfIdsPerv[b + 1])
                    {
                        myCollectIdPerv.Add(collectionOfIdsPerv[b+1]);
                    }
                }

                //Clean DA for Offers
                dtOffer.Clear();

                foreach(int i in myCollectIdPerv)
                {
                    Fill_DA(i);
                    //MessageBox.Show(i.ToString());
                }

                dgForVariants.ItemsSource = dtOffer.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Укажите район");
                MessageBox.Show(ex.Message);
                if (sqlCon.State.ToString() != "Closed")
                {
                    sqlCon.Close();
                    MessageBox.Show("Подключение было закрыто.");
                }
            }
        }
        // For Offer Fild DA
        public void Fill_DA(int idOffers)
        {
            string sqlOfferTable = null;
            if (cbOffer.Text == "Первомайский")
            {
                sqlOfferTable = "PERVOMAYSKIY";
            }
            else if (cbOffer.Text == "Центральный")
            {
                sqlOfferTable = "TSENTRALNYY";
            }
            else
            {
                sqlOfferTable = null;
            }

            daOffer.SelectCommand = new SqlCommand("SELECT ID AS[ID], DISTRICT[Район], MICRODISTRICT[Микро Район], STREET[Улица], HOUSE_NUMBER[Номер дома], HOUSE_CORP[Корпус], ROOMS_TOTAL[Комнат], AREA_COMMON[Площадь], PRICE[Цена], FILL_DATE[Дата подачи объявления] FROM " + sqlOfferTable + " WHERE ID = " + idOffers, sqlCon);

            sqlCon.Open();
            daOffer.SelectCommand.ExecuteNonQuery();
            sqlCon.Close();


            daOffer.Fill(dtOffer);

        }
        // CheckBoxes
        // District CB
        private void CbWhoSearchOurDistrict_Checked(object sender, RoutedEventArgs e)
        {
            offerForDistrict = "AND DISTRICT_CONDITION = "+ "N'" + dtForSearch2.Rows[0][1].ToString()+"'";
        }

        private void CbWhoSearchOurDistrict_Unchecked(object sender, RoutedEventArgs e)
        {
            offerForDistrict = null;
        }
        // MicroDistrict CB
        private void CbWhoSearchOurMicroDistrict_Checked(object sender, RoutedEventArgs e)
        {
            offerForMicroDistrict = "AND MICRODISTRICT_CONDITION = " + "N'" + dtForSearch2.Rows[0][2].ToString() + "'";
        }

        private void CbWhoSearchOurMicroDistrict_Unchecked(object sender, RoutedEventArgs e)
        {
            offerForMicroDistrict = null;
        }
        // Street CB
        private void CbWhoSearchOurStreet_Checked(object sender, RoutedEventArgs e)
        {
            offerForStreet = " AND STREET_CONDITION LIKE N'%" + dtForSearch2.Rows[0][3].ToString() + "%'";
             
            //MessageBox.Show(dtForSearch2.Rows[0][3].ToString());
        }

        private void CbWhoSearchOurStreet_Unchecked(object sender, RoutedEventArgs e)
        {
            offerForStreet = null;
        }
        // Rooms CB
        private void CbWhoSearchOurRoomsQuantity_Checked(object sender, RoutedEventArgs e)
        {
            offerForRooms = "AND ROOMS_TOTAL_CONDITION = " + "'" + dtForSearch2.Rows[0][6].ToString() + "'";
            //MessageBox.Show(dtForSearch2.Rows[0][6].ToString());
        }

        private void CbWhoSearchOurRoomsQuantity_Unchecked(object sender, RoutedEventArgs e)
        {
            offerForRooms = null;
        }
        // Area Total CB
        private void CbWhoSearchOurTotalArea_Checked(object sender, RoutedEventArgs e)
        {
            offerForArea = "AND AREA_COMMON_CONDITION <= " + dtForSearch2.Rows[0][9].ToString();
        }

        private void CbWhoSearchOurTotalArea_Unchecked(object sender, RoutedEventArgs e)
        {
            offerForArea = null;
        }

        private void CbWhoSearchOurPrice_Checked(object sender, RoutedEventArgs e)
        {
            offerForPrice = "AND PRICECONDITION >= " + dtForSearch2.Rows[0][10].ToString();
        }

        private void CbWhoSearchOurPrice_Unchecked(object sender, RoutedEventArgs e)
        {
            offerForPrice = null;
        }
        // Show Detail to Offers
        private void BtnShoeOffers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DetailWindow detailWindow = new DetailWindow();
                detailWindow.Show();


                if (cbOffer.Text == "Первомайский")
                {
                    sqlTableName = "PERVOMAYSKIY";
                }
                else if (cbSearchTabDistrict.Text == "Центральный")
                {
                    sqlTableName = "TSENTRALNYY";
                }
                else
                {
                    sqlTableName = null;
                }

                int rowIndex = Convert.ToInt32(dgForVariants.SelectedIndex.ToString());
                Object idMain = dtOffer.Rows[rowIndex][0];

                daForSearch.SelectCommand = new SqlCommand("SELECT * FROM " + sqlTableName + " WHERE ID = " + idMain.ToString(), sqlCon);

                sqlCon.Open();
                daForSearch.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtCondition3.Clear();

                daForSearch.Fill(dtCondition3);

                // Fill the fields of Description Form
                detailWindow.descriptionFilldate.Text = dtCondition3.Rows[0][20].ToString();
                detailWindow.descriptionDistrict.Text = dtCondition3.Rows[0][1].ToString();
                detailWindow.descriptionStreet.Text = dtCondition3.Rows[0][3].ToString();
                detailWindow.descriptionHouseNumber.Text = dtCondition3.Rows[0][4].ToString();
                detailWindow.descriptionHouseCorp.Text = dtCondition3.Rows[0][5].ToString();
                detailWindow.descriptionContactName.Text = dtCondition3.Rows[0][8].ToString();
                detailWindow.descriptionAgency.Text = dtCondition3.Rows[0][9].ToString();
                detailWindow.descriptionPrice.Text = dtCondition3.Rows[0][18].ToString();
                detailWindow.descriptionPhone1.Text = dtCondition3.Rows[0][6].ToString();
                detailWindow.descriptionPhone2.Text = dtCondition3.Rows[0][7].ToString();
                detailWindow.descriptionRoomsTotal.Text = dtCondition3.Rows[0][10].ToString();
                detailWindow.descriptionRoomsSeparate.Text = dtCondition3.Rows[0][11].ToString();
                detailWindow.descriptionAreaTotal.Text = dtCondition3.Rows[0][14].ToString();
                detailWindow.descriptionAreaLiving.Text = dtCondition3.Rows[0][15].ToString();
                detailWindow.descriptionAreaKitchen.Text = dtCondition3.Rows[0][16].ToString();
                detailWindow.descriptionConstructionEyar.Text = dtCondition3.Rows[0][17].ToString();
                detailWindow.descriptionFloor.Text = dtCondition3.Rows[0][12].ToString();
                detailWindow.descriptionFloorTotal.Text = dtCondition3.Rows[0][13].ToString();
                detailWindow.descriptionAddConditions.Text = dtCondition3.Rows[0][19].ToString();

                LoadImageFromBase(detailWindow.descriptionImage1, "1");
                LoadImageFromBase(detailWindow.descriptionImage2, "2");
                LoadImageFromBase(detailWindow.descriptionImage3, "3");
                LoadImageFromBase(detailWindow.descriptionImage4, "4");
                LoadImageFromBase(detailWindow.descriptionImage5, "5");
                LoadImageFromBase(detailWindow.descriptionImage6, "6");
                LoadImageFromBase(detailWindow.descriptionImage7, "7");
                //Load Image From Base
                void LoadImageFromBase(Image imageToFill, string photoNumber)
                {
                    try
                    {
                        da.SelectCommand = new SqlCommand("SELECT FLAT_IMAGE FROM " + sqlTableName + "_IMAGES WHERE  ID_MASTER = " + idMain + " AND ID_SERVANT = " + photoNumber, sqlCon);
                        //MessageBox.Show("SELECT FLAT_IMAGE FROM " + sqlTableName + "_IMAGES WHERE  ID_MASTER = " + idMain + " AND ID_SERVANT = " + photoNumber);
                        sqlCon.Open();
                        SqlDataReader rd = da.SelectCommand.ExecuteReader();
                        // byte[] data;

                        while (rd.Read())
                        {
                            //int id = rd.GetInt32(0);
                            //string filename = rd.GetString(1);
                            //string title = rd.GetString(2);
                            data = (byte[])rd.GetValue(0);
                        }

                        BitmapImage img = new BitmapImage();
                        img = LoadImage(data);
                        imageToFill.Source = img;


                        sqlCon.Close();
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                // To Fill Detail Window                            SELECT ID AS[ID], DISTRICT[Район]
                daConditionDescription.SelectCommand = new SqlCommand("SELECT DISTRICT_CONDITION AS[Район], MICRODISTRICT_CONDITION[Микрорайон], STREET_CONDITION[Улица], ROOMS_TOTAL_CONDITION[Комнат], AREA_COMMON_CONDITION[Площадь], PRICECONDITION[Цена] FROM " + sqlTableName + "_CONDITION" + " WHERE ID_MASTER = " + idMain.ToString(), sqlCon);

                sqlCon.Open();
                daConditionDescription.SelectCommand.ExecuteNonQuery();
                sqlCon.Close();

                dtConditionDescription.Clear();

                daConditionDescription.Fill(dtConditionDescription);

                detailWindow.dgDetailWindowCondition.ItemsSource = dtConditionDescription.DefaultView;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        // Open Search Html Page
        private void HelpBtn_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сейчас откроется интернет страничка с полным описанием функций программы.");
            System.Diagnostics.Process.Start("help.html");
        }
    }
}
