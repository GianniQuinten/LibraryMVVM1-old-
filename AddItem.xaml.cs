﻿using Microsoft.Data.SqlClient;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Savebtn_Click_Item(object sender, RoutedEventArgs e)
        {
            string Name = txtItemName.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Library;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "INSERT INTO Items (Name) VALUES ('" + Name + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
