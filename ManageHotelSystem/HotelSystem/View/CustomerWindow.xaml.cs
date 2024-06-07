using ManageHotel.Data;
using ManageHotel.Service;
using NguyenHuuPhucWPF.Model;
using NguyenHuuPhucWPF.Repository;
using System.Windows;
using System.Windows.Controls;

namespace NguyenHuuPhucWPF.View
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly CustomerService _customerService;
        public Customer currentCus;

        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            var customerContext = new DAOContext();
            var customerRepo = new CustomerRepository(customerContext);
            _customerService = new CustomerService(customerRepo);

            FullNameTextBox.Text = customer.CustomerFullName;
            TelephoneTextBox.Text = customer.Telephone;
            EmailAddressTextBox.Text = customer.EmailAddress;
            BirthdayDatePicker.SelectedDate = customer.CustomerBirthday;
            PasswordBox.Text = customer.Password;

            currentCus = customer;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameTextBox.Text;
            string telephone = TelephoneTextBox.Text;
            string email = EmailAddressTextBox.Text;
            string password = PasswordBox.Text;

            if (BirthdayDatePicker.SelectedDate == null || BirthdayDatePicker.SelectedDate.Value.Year < DateTime.Now.Year - 10)
            {
                MessageBox.Show("Please select a valid Birthday.");
                return;
            }
            DateTime birthday = BirthdayDatePicker.SelectedDate.Value;

            var customer = new Customer
            {
                CustomerFullName = fullName,
                Telephone = telephone,
                EmailAddress = email,
                CustomerBirthday = birthday,
                CustomerStatus = currentCus.CustomerStatus,
                Password = password
            };

            customer.CustomerID = currentCus.CustomerID;

            _customerService.UpdateCustomer(customer);
            currentCus = customer;


            MessageBox.Show("Update successfully");
        }

        private void ProfileWindow_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow window = new(currentCus);
            window.Show();
            this.Close();
        }

        private void HistoryWindow_Click(object sender, RoutedEventArgs e)
        {
            HistoryWindow window = new(currentCus);
            window.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login window = new();
            window.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new();
            login.Show();
            this.Close();
        }
    }
}
