using ManageHotel.Model;

namespace ManageHotel.Repository
{
    interface IBookingReservationRepository
    {
        IEnumerable<BookingReservation> GetBookingReservationByCustomerID(int CustomerID);
    }
}
