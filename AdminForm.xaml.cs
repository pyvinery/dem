
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace dem
{
    public partial class AdminForm : Window
    {
        demEntities db = new demEntities();

        public AdminForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgData.ItemsSource = db.Tovar.ToList();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Выбранный товар хранится в dgData.SelectedItem
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Redact window = new Redact();
            if (window.ShowDialog() == true)
                LoadData();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!(dgData.SelectedItem is Tovar t))
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            Redact window = new Redact(t.Articul);

            if (window.ShowDialog() == true)
                LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!(dgData.SelectedItem is Tovar t))
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            if (MessageBox.Show("Удалить выбранный товар?",
                "Подтверждение",
                MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            db.Tovar.Remove(t);
            db.SaveChanges();
            LoadData();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
