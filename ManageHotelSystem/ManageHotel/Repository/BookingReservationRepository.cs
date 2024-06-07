using ManageHotel.Data;
using ManageHotel.Model;


namespace ManageHotel.Repository
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        private readonly DAOContext _context;

        public BookingReservationRepository(DAOContext context)
        {
            _context = context;
        }

        public IEnumerable<BookingReservation> GetBookingReservationByCustomerID(int CustomerID)
        {
            // Return many items
            return _context.BookingReservation.Where(b => b.CustomerID == CustomerID).ToList();
        }

        
    }
}
