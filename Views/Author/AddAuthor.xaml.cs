using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library.Views.Author
{
    /// <summary>
    /// Interaction logic for AddAuthor.xaml
    /// </summary>
    public partial class AddAuthor : Window
    {
        public AddAuthor()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtAuthorName.Text;
            string Lastname = txtAuthorLastname.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Library;";
            SqlCommand cmd = new SqlCommand();  
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "INSERT INTO AUTHORS (Name, Lastname) VALUES ('" + Name + "','" + Lastname + "')";
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }
    }
}

