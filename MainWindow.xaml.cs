
using System.Linq;
using System.Windows;

namespace dem
{
    public partial class MainWindow : Window
    {
        demEntities db = new demEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogBt_Click(object sender, RoutedEventArgs e)
        {
            var user = db.Users.FirstOrDefault(x =>
                x.Login == tbLogin.Text &&
                x.Password == tbPassword.Password);

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            if (user.Rol == "Администратор")
            {
                new AdminForm().Show();
            }
            else if (user.Rol == "Менеджер")
            {
                new ManagerForm().Show();
            }
            else
            {
                new Menu().Show();
            }

            Close();
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            Close();
        }
    }
}
