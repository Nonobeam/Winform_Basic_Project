using Bussiness.Services;
using DAO.DTO;
using DAO.Entities;
using System.Windows;

namespace View.View
{
    public partial class AirConditionerManagement : Window
    {
        private AirConditionerService airConditionerService;
        private SupplierCompanyService supplierCompanyService;
        private StaffMember loggedInUser;

        public AirConditionerManagement(StaffMember user)
        {
            InitializeComponent();

            loggedInUser = user;

            airConditionerService = new AirConditionerService();
            supplierCompanyService = new SupplierCompanyService();
            LoadData();
            LoadSuppliers();
        }

        private void LoadData()
        {
            AirConditionerDataGrid.ItemsSource = airConditionerService.GetAllAirConditionersDTO();
        }

        private void LoadSuppliers()
        {
            SupplierComboBox.ItemsSource = supplierCompanyService.GetAllSupplierCompanies();
            SupplierComboBox.DisplayMemberPath = "SupplierName";
            SupplierComboBox.SelectedValuePath = "SupplierId";
        }

        private bool IsUserAuthorized()
        {
            if (loggedInUser == null || (loggedInUser.Role != 1 && loggedInUser.Role != 2))
            {
                MessageBox.Show("You have no permission to access this function!", "Authorization Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void AirConditionerDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (AirConditionerDataGrid.SelectedItem is AirConditionerDTO selectedAirConditioner)
            {
                IdTextBox.Text = selectedAirConditioner.AirConditionerId.ToString();
                NameTextBox.Text = selectedAirConditioner.AirConditionerName;
                WarrantyTextBox.Text = selectedAirConditioner.Warranty;
                SoundPressureLevelTextBox.Text = selectedAirConditioner.SoundPressureLevel;
                FeatureFunctionTextBox.Text = selectedAirConditioner.FeatureFunction;
                QuantityTextBox.Text = selectedAirConditioner.Quantity.ToString();
                DollarPriceTextBox.Text = selectedAirConditioner.DollarPrice.ToString();
                SupplierComboBox.Text = selectedAirConditioner.SupplierName;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserAuthorized() && loggedInUser.Role == 1)
            {
                // Check if any field is empty or null
                if (string.IsNullOrWhiteSpace(IdTextBox.Text) ||
                    string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(WarrantyTextBox.Text) ||
                    string.IsNullOrWhiteSpace(SoundPressureLevelTextBox.Text) ||
                    string.IsNullOrWhiteSpace(FeatureFunctionTextBox.Text) ||
                    string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                    string.IsNullOrWhiteSpace(DollarPriceTextBox.Text) ||
                    SupplierComboBox.SelectedValue == null)
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string airConditionerName = NameTextBox.Text;
                if (airConditionerName.Length >= 1 && airConditionerName.Length <= 255)
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(airConditionerName, @"^([A-Z0-9][\w]*\s)*[A-Z0-9][\w]*$"))
                    {
                        MessageBox.Show("Each word of the AirConditionerName must begin with a capital letter or digit (1-9).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("AirConditionerName must be between 1 and 255 characters long.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (double.TryParse(DollarPriceTextBox.Text, out double dollarPrice))
                {
                    if (dollarPrice > 0 && dollarPrice < 4000000)
                    {
                        if (int.TryParse(QuantityTextBox.Text, out int quantity) && quantity >= 0)
                        {
                            int id = int.Parse(IdTextBox.Text);
                            if (airConditionerService.GetAirConditionerById(id) == null)
                            {
                                string supplierId = SupplierComboBox.SelectedValue.ToString();
                                var ac = new AirConditioner
                                {
                                    AirConditionerId = id,
                                    AirConditionerName = airConditionerName,
                                    Warranty = WarrantyTextBox.Text,
                                    SoundPressureLevel = SoundPressureLevelTextBox.Text,
                                    FeatureFunction = FeatureFunctionTextBox.Text,
                                    Quantity = quantity,
                                    DollarPrice = dollarPrice,
                                    SupplierId = supplierId,
                                    Supplier = supplierCompanyService.GetSupplierCompanyById(supplierId)
                                };
                                airConditionerService.AddAirConditioner(ac);
                                LoadData();
                            } 
                            else
                            {
                                MessageBox.Show("This ID is already existed", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quantity must be a non-negative integer.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dollar Price must be greater than 0 and less than 4,000,000.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Dollar Price. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } 
            else
            {
                MessageBox.Show("You have no permission to access this function!", "Authorization Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserAuthorized() && loggedInUser.Role == 1)
            {
                // Check if any field is empty or null
                if (string.IsNullOrWhiteSpace(IdTextBox.Text) ||
                    string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(WarrantyTextBox.Text) ||
                    string.IsNullOrWhiteSpace(SoundPressureLevelTextBox.Text) ||
                    string.IsNullOrWhiteSpace(FeatureFunctionTextBox.Text) ||
                    string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                    string.IsNullOrWhiteSpace(DollarPriceTextBox.Text) ||
                    SupplierComboBox.SelectedValue == null)
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string airConditionerName = NameTextBox.Text;
                if (airConditionerName.Length >= 1 && airConditionerName.Length <= 255)
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(airConditionerName, @"^([A-Z0-9][\w]*\s)*[A-Z0-9][\w]*$"))
                    {
                        MessageBox.Show("Each word of the AirConditionerName must begin with a capital letter or digit (1-9).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("AirConditionerName must be between 1 and 255 characters long.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (double.TryParse(DollarPriceTextBox.Text, out double dollarPrice))
                {
                    if (dollarPrice > 0 && dollarPrice < 4000000)
                    {
                        if (int.TryParse(QuantityTextBox.Text, out int quantity) && quantity >= 0)
                        {
                            string supplierId = SupplierComboBox.SelectedValue.ToString();
                            var ac = new AirConditioner
                            {
                                AirConditionerId = int.Parse(IdTextBox.Text),
                                AirConditionerName = airConditionerName,
                                Warranty = WarrantyTextBox.Text,
                                SoundPressureLevel = SoundPressureLevelTextBox.Text,
                                FeatureFunction = FeatureFunctionTextBox.Text,
                                Quantity = quantity,
                                DollarPrice = dollarPrice,
                                SupplierId = supplierId,
                                Supplier = supplierCompanyService.GetSupplierCompanyById(supplierId)
                            };
                            airConditionerService.UpdateAirConditioner(ac);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Quantity must be a non-negative integer.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dollar Price must be greater than 0 and less than 4,000,000.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Dollar Price. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("You have no permission to access this function!", "Authorization Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserAuthorized() && loggedInUser.Role == 1)
            {
                if (AirConditionerDataGrid.SelectedItem is AirConditionerDTO selectedAirConditioner)
                {
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the air conditioner with ID {selectedAirConditioner.AirConditionerId}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        airConditionerService.DeleteAirConditioner(selectedAirConditioner.AirConditionerId);
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an air conditioner to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("You have no permission to access this function!", "Authorization Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserAuthorized())
            {
                string searchText = SearchTextBox.Text.ToLower();
                var filteredList = airConditionerService.GetAllAirConditionersDTO()
                                                         .Where(ac => ac.FeatureFunction.ToLower().Contains(searchText) ||
                                                                      ac.Quantity.ToString().Contains(searchText)
                                                                      )
                                                         .ToList();
                AirConditionerDataGrid.ItemsSource = filteredList;
            }
        }
    }
}
