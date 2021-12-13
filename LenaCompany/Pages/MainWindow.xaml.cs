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

namespace LenaCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DB.appEntities DBConnect = new DB.appEntities();
            lbContent.ItemsSource = DBConnect.Users.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pages.Window1 AddSuppliers = new Pages.Window1();
            AddSuppliers.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DB.appEntities DBConnect = new DB.appEntities();
            if (tbSearch.Text.Length > 0)
            {
                lbContent.ItemsSource = DBConnect.Users.Where(x => x.name.Contains(tbSearch.Text) || x.login.Contains(tbSearch.Text)).ToList();
            }
            else
            {
                lbContent.ItemsSource = DBConnect.Users.ToList();
            }
            
        }
    }
}
