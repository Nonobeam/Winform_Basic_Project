using ManageHotel.Data;
using ManageHotel.Service;
using NguyenHuuPhucWPF.Model;
using NguyenHuuPhucWPF.Repository;
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

namespace NguyenHuuPhucWPF.View.Dialog
{
    /// <summary>
    /// Interaction logic for UpdateDialog.xaml
    /// </summary>
    public partial class UpdateDialog : Window
    {
        private readonly CustomerService _adminService;
        public Customer subCustomer;
        private int CustomerID = 0;

        public UpdateDialog(Model.Customer selectedCustomer)
        {
            InitializeComponent();
            var customerContext = new DAOContext();
            var customerRepo = new CustomerRepository(customerContext);
            _adminService = new CustomerService(customerRepo);

            FullNameTextBox.Text = selectedCustomer.CustomerFullName;
            TelephoneTextBox.Text = selectedCustomer.Telephone;
            EmailTextBox.Text = selectedCustomer.EmailAddress;
            BirthdayDatePicker.SelectedDate = selectedCustomer.CustomerBirthday;
            PasswordBox.Text = selectedCustomer.Password;
            StatusComboBox.SelectedIndex = selectedCustomer.CustomerStatus - 1;

            CustomerID = selectedCustomer.CustomerID;
        }

        private void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameTextBox.Text;
            string telephone = TelephoneTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Text;

            if (BirthdayDatePicker.SelectedDate == null || BirthdayDatePicker.SelectedDate.Value.Year < DateTime.Now.Year - 10)
            {
                MessageBox.Show("Please select a valid Birthday.");
                return;
            }
            DateTime birthday = BirthdayDatePicker.SelectedDate.Value;

            if (StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Status.");
                return;
            }
            string statusText = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            byte status = statusText == "Active" ? (byte)1 : (byte)0;

            var customer = new Customer
            {
                CustomerFullName = fullName,
                Telephone = telephone,
                EmailAddress = email,
                CustomerBirthday = birthday,
                CustomerStatus = status,
                Password = password
            };

            customer.CustomerID = CustomerID;

            _adminService.UpdateCustomer(customer);
            subCustomer = customer;
            

            MessageBox.Show("Update successfully");

            this.DialogResult = true;
            this.Close();
        }
    }
}
