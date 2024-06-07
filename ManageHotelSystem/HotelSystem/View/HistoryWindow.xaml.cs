using ManageHotel.Data;
using ManageHotel.Repository;
using ManageHotel.Service;
using NguyenHuuPhucWPF.Model;
using NguyenHuuPhucWPF.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace NguyenHuuPhucWPF.View
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private readonly BookingReservationService _bookingReservationService;
        public Customer currentCustomer;

        public HistoryWindow(Model.Customer currentCus)
        {
            InitializeComponent();

            var bookingReservationContext = new DAOContext();
            var bookingReservationRepo = new BookingReservationRepository(bookingReservationContext);
            _bookingReservationService = new BookingReservationService(bookingReservationRepo);
            BookingListView.ItemsSource = _bookingReservationService.GetBookingReservationByCustomerID(currentCus.CustomerID);
            currentCustomer = currentCus;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new();
            login.Show();
            this.Close();
        }
    }
}
