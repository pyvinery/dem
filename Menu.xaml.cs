
using System.Linq;
using System.Windows;

namespace dem
{
    public partial class Menu : Window
    {
        demEntities db = new demEntities();

        public Menu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemsSource = db.Tovar.ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
