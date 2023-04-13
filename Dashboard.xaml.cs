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

namespace Library
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

        private void MenuItem_Authors(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddAuthor(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Categories(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Genres(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Items(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Publishers(object sender, RoutedEventArgs e)
        {

        }
    }
}
