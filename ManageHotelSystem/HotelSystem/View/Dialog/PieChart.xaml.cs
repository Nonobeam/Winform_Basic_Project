using System.Windows;
using ManageHotel.Data;
using ManageHotel.Model;
using ManageHotel.Repository;
using ManageHotel.Service;
using OxyPlot;
using OxyPlot.Series;

namespace NguyenHuuPhucWPF.View.Dialog
{
    /// <summary>
    /// Interaction logic for PieChart.xaml
    /// </summary>
    public partial class PieChart : Window
    {
        private BookingDetailService _bookingDetailService;

        public PieChart()
        {
            InitializeComponent();
            var bookingDetailContext = new DAOContext();
            var bookingDetailRepo = new BookingDetailRepository(bookingDetailContext);
            _bookingDetailService = new BookingDetailService(bookingDetailRepo);

            GetPlotView();
        }

        private void GetPlotView()
        {
            string title = "Booking Details";
            IEnumerable<BookingDetail> bookingDetails = _bookingDetailService.GetAlls();
            Dictionary<int, decimal> rooms = new Dictionary<int, decimal>();

            foreach (var booking in bookingDetails)
            {
                if (rooms.ContainsKey(booking.RoomID))
                {
                    rooms[booking.RoomID] += booking.ActualPrice;
                }
                else
                {
                    rooms[booking.RoomID] = booking.RoomID;
                }
            }


            PlotModel plotModel = new PlotModel { Title = title };


            var series = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.5,
                AngleSpan = 360,
                StartAngle = 0,
                FontSize = 15,
                OutsideLabelFormat = "{2:0} %",
                TickHorizontalLength = 5,
                TickRadialLength = 5,
                TickDistance = 1,
                TickLabelDistance = 1,
        };


            foreach (var bookingDetail in rooms)
            {
                series.Slices.Add(new PieSlice(bookingDetail.Key.ToString(), (Double)bookingDetail.Value) { IsExploded = true });
            }

            plotModel.Series.Add(series);

            plot.Model = plotModel;
        }
    }
}
