using ManageHotel.Data;
using ManageHotel.Model;


namespace ManageHotel.Repository
{
    public class BookingDetailRepository
    {
        private readonly DAOContext _context;

        public BookingDetailRepository(DAOContext context)
        {
            _context = context;
        }

        public IEnumerable<BookingDetail> GetBookingDetailByRoomID(int RoomID)
        {
            return _context.BookingDetail.Where(b => b.RoomID == RoomID).ToList();
        }

        public IEnumerable<BookingDetail> GetBookingDetailByBookingReservationID(int BookingReservationID)
        {
            return _context.BookingDetail.Where(b => b.BookingReservationID == BookingReservationID).ToList();
        }

        public IEnumerable<BookingDetail> GetAlls()
        {
            return _context.BookingDetail.ToList();
        }
    }
}
