using Library.Views.Author;
using Microsoft.SqlServer.Server;
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

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            var addAuthor = new AddAuthor();

            addAuthor.Show();
        }

        private void btnEditAuthor_Click(object sender, RoutedEventArgs e)
        {
            var editAuthor = new EditAuthor();

            editAuthor.Show();
        }

        private void btnViewAuthor_Click(object sender, RoutedEventArgs e)
        {
            var viewAuthor = new ViewAuthor();

            viewAuthor.Show();
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            var addCategory = new AddCategory();

            addCategory.Show();
        }

        private void btnAddGenre_Click(object sender, RoutedEventArgs e)
        {
            var addGenre = new AddGenre();

            addGenre.Show();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            var addItem = new AddItem();

            addItem.Show();
        }

        private void btnAddPublisher_Click(object sender, RoutedEventArgs e)
        {
            var addPublisher = new AddPublisher();

            addPublisher.Show();
        }
    }
}
