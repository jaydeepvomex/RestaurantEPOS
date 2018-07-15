using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantEPOS.UI.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLoginClicked(object sender, RoutedEventArgs e)
        {
            //string username = inputUsername.Text;
            //string password = inputPassword.Password;

            //if (password == "0")
            //{
            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.Show();
            //    CloseWindow(typeof(LoginWindow));
            //}
            //else
            //{
            //    MessageBox.Show("Incorrect password.");
            //}
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            CloseWindow(typeof(LoginWindow));
        }

        void CloseWindow(System.Type type)
        {
            var window = App.Current.Windows.OfType<Window>().FirstOrDefault(w => w.GetType() == type);
            if (window != null)
                window.Close();
        }
    }
}
