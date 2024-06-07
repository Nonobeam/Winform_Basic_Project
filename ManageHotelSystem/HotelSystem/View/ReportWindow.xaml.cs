using ManageHotel.Data;
using ManageHotel.Model;
using ManageHotel.Repository;
using ManageHotel.Service;
using NguyenHuuPhucWPF.View.Dialog;
using System.Windows;

namespace NguyenHuuPhucWPF.View
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private BookingDetailService _bookingDetailService;
        PieChart chart;

        public ReportWindow()
        {
            InitializeComponent();
            var bookingDetailContext = new DAOContext();
            var bookingDetailRepo = new BookingDetailRepository(bookingDetailContext);
            _bookingDetailService = new BookingDetailService(bookingDetailRepo);

            DataGrid.ItemsSource = _bookingDetailService.GetAlls();

            chart = new PieChart();
            chart.Show();
        }

        private void RoomWindow_Click(object sender, RoutedEventArgs e)
        {
            RoomWindow room = new();
            room.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            room.Show();
            chart.Close();
            this.Close();
        }

        private void CustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            Admin window = new();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            chart.Close();
            this.Close();
        }

        private void ReportWindow_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Show();
            chart.Close();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
