
using System.Linq;
using System.Windows;

namespace dem
{
    public partial class ManagerForm : Window
    {
        demEntities db = new demEntities();

        public ManagerForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgProducts.ItemsSource = db.Tovar.ToList();
            dgOrders.ItemsSource = db.Zakaz.ToList();
        }

        private void ShowProducts_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.Visibility = Visibility.Visible;
            dgOrders.Visibility = Visibility.Collapsed;
        }

        private void ShowOrders_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.Visibility = Visibility.Collapsed;
            dgOrders.Visibility = Visibility.Visible;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
