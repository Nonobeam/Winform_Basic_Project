using Bussiness.Services;
using DAO;
using DAO.Entities;
using System.Windows;
using View.View;
namespace View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private StaffMemberService staffMemberService;

        public StaffMember LoggedInUser { get; set; }

        public Login()
        {
            InitializeComponent();
            staffMemberService = new StaffMemberService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;


            LoggedInUser = staffMemberService.Authenticate(email, password);


            if (LoggedInUser != null)
            {
                if ((LoggedInUser.Role == 1 || LoggedInUser.Role == 2))
                {
                    AirConditionerManagement window = new AirConditionerManagement(LoggedInUser);
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You have no permission to access this function", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Wrong email or wrong password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
