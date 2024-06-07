using ManageHotel.Data;
using ManageHotel.Service;
using NguyenHuuPhucWPF.Model;
using NguyenHuuPhucWPF.Repository;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NguyenHuuPhucWPF.View.Dialog
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        public readonly RoomService _roomService;

        public AddRoom()
        {
            InitializeComponent();
            var roomContext = new DAOContext();
            var roomRepo = new RoomRepository(roomContext);
            _roomService = new RoomService(roomRepo);
        }

        private void AddRoomButton_Click(object sender, RoutedEventArgs e)
        {
            string roomNumber = RoomNumberTextBox.Text;
            IEnumerable<RoomInformation> rooms = _roomService.GetAllRooms();
            if (rooms.Any(room => room.RoomNumber == roomNumber))
            {
                MessageBox.Show("This room number already exists. Please enter a different room number.");
                return;
            }
            string roomDetailDescription = RoomDetailDescriptionTextBox.Text;
            int roomMaxCapacity = int.Parse(RoomMaxCapacityTextBox.Text);
            decimal roomPricePerDay = decimal.Parse(RoomPricePerDayTextBox.Text);
            int roomTypeID = int.Parse(RoomTypeIDTextBox.Text);

            if (RoomStatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Room Status.");
                return;
            }
            string statusText = (RoomStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            byte roomStatus = statusText == "Active" ? (byte)1 : (byte)0;

            var room = new RoomInformation
            {
                RoomNumber = roomNumber,
                RoomDetailDescription = roomDetailDescription,
                RoomMaxCapacity = roomMaxCapacity,
                RoomStatus = roomStatus,
                RoomPricePerDay = roomPricePerDay,
                RoomTypeID = roomTypeID
            };

            _roomService.AddRoom(room);

            MessageBox.Show("Room added successfully");

            this.DialogResult = true;
            this.Close();
        }
    }
}