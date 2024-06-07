using ManageHotel.Data;
using ManageHotel.Service;
using NguyenHuuPhucWPF.Model;
using NguyenHuuPhucWPF.Repository;
using NguyenHuuPhucWPF.View.Dialog;


using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace NguyenHuuPhucWPF.View
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private readonly CustomerService _customerService;
        private ObservableCollection<Customer> _customers;

        public Admin()
        {
            InitializeComponent();
            var customerContext = new DAOContext();
            var customerRepo = new CustomerRepository(customerContext);
            _customerService = new CustomerService(customerRepo);
            _customers = new ObservableCollection<Customer>(_customerService.GetAllCucstomers());
            CustomerDataGrid.ItemsSource = _customers;
        }

        private void RefreshCustomerList()
        {
            _customers.Clear();
            foreach (var customer in _customerService.GetAllCucstomers())
            {
                _customers.Add(customer);
            }
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            AddDialog addDialog = new();
            addDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bool? result = addDialog.ShowDialog();

            if (result == true)
            {
                RefreshCustomerList();
            }

        }

        private void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer selectedCustomer)
            {
                UpdateDialog updateDialog = new UpdateDialog(selectedCustomer);
                updateDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                var result = updateDialog.ShowDialog();

                int index = _customers.IndexOf(selectedCustomer);

                if (index != -1)
                {
                    _customers[index] = updateDialog.subCustomer;
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = CustomerDataGrid.SelectedItem as Customer;
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete customer {selectedCustomer.CustomerFullName}?",
                                         "Confirmation",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);

            MessageBox.Show("Delete Successfully");

            if (result == MessageBoxResult.Yes)
            {
                _customerService.DeleteCustmerByID(selectedCustomer.CustomerID);

                foreach (var child in CustomerPanel.Children)
                {
                    if (child is TextBox textBox)
                    {
                        textBox.Clear();
                    }
                    else if (child is DatePicker datePicker)
                    {
                        datePicker.SelectedDate = null;
                    }
                }

                RefreshCustomerList();
            }
        }

        private void CustomerDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer selectedCustomer)
            {
                CustomerIDTextBox.Text = selectedCustomer.CustomerID.ToString();
                FullNameTextBox.Text = selectedCustomer.CustomerFullName;
                TelephoneTextBox.Text = selectedCustomer.Telephone;
                EmailTextBox.Text = selectedCustomer.EmailAddress;
                BirthdayDatePicker.SelectedDate = selectedCustomer.CustomerBirthday;
                StatusComboBox.SelectedIndex = selectedCustomer.CustomerStatus - 1;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchTextBox.Text.Trim();
            List<Customer> results = _customers.Where(c => c.CustomerFullName.Contains(keyword)).ToList();

            // Update ListBox with search results
            CustomerDataGrid.ItemsSource = results;
        }

        private void RoomWindow_Click(object sender, RoutedEventArgs e)
        {
            RoomWindow room = new();
            room.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            room.Show();
            this.Close();
        }

        private void ReportWindow_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow window = new();
            window.Show();  
            this.Close();
        }

        private void CustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            Admin window = new();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            this.Close();

            PieChart chart = new();
            chart.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new();
            login.Show();
            this.Close();
        }
    }
}
