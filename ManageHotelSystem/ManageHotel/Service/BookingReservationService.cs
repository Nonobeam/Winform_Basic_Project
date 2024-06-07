using ManageHotel.Model;
using ManageHotel.Repository;
using NguyenHuuPhucWPF.Model;

namespace ManageHotel.Service
{
    public class BookingReservationService(BookingReservationRepository bookingReservationRepository)
    {
        private readonly BookingReservationRepository bookingReservationRepository = bookingReservationRepository;

        public IEnumerable<BookingReservation> GetBookingReservationByCustomerID(int customerID)
        {
            return bookingReservationRepository.GetBookingReservationByCustomerID(customerID);
        }
    }
}
