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

namespace Library.Views.Author
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

        public void cleardata() 
        {
            FirstName_txt.Clear();
            LastName_txt.Clear();
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
        // because of time contraint not finished
        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Library;";
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "UPDATE FROM AUTHORS WHERE Id = " + Id_txt + " ";
        }

        //there is a error that i was not able to fix
        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Library;";
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "Delete FROM AUTHORS WHERE Id = "+Id_txt+" ";
            try 
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                conn.Close();
                cleardata();
                LoadGrid();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not deleted" +ex.Message);
            }
            finally 
            {
                conn.Close(); 
            }
        }
    }
}
