using Library.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Library
{
    /// <summary>
    /// Interaction logic for ViewAuthor.xaml
    /// </summary>
    public partial class ViewAuthor : Window
    {
        public ViewAuthor()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void LoadGrid()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Library;";
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "SELECT * FROM AUTHORS";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();
            DataGrid.ItemsSource = dt.DefaultView;
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
