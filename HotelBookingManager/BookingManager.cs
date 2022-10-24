using Hotel_Booking_Manager.Booking;
using Hotel_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingManager.BookingManager
{
    public class BookingManager : IBookingManager
    {
        public IList<Booking> _bookings = new List<Booking>();
        public IEnumerable<int> _rooms = new List<int> { 101, 102, 201, 203 };

        public void AddBooking(string guest, int room, DateTime date)
        {
            if(!IsRoomAvailable(room, date))
                throw new Exception("Room is unavailable for the chosen date.");

             _bookings.Add(new Booking(guest, date, room));
        }

        public bool IsRoomAvailable(int room, DateTime date)
        {
            if (!IsValidRoom(room))
                throw new ArgumentException("Invalid Room number!");

            var bookingExists = _bookings.Where(booking => booking.Room == room && booking.Date == date).Any();
            return !bookingExists;
        }

        public IEnumerable<int> GetAvailableRooms(DateTime date)
        {
            IList<int> availableRooms= new List<int>();

            var bookingsForDate = _bookings.Where(booking => booking.Date == date);

            //If no bookings for room on this date, add to availableRooms
            foreach (var room in _rooms)
            {
                if(!bookingsForDate.Any(booking => booking.Room == room))
                    availableRooms.Add(room);
            }

            return availableRooms;
        }

        private bool IsValidRoom(int room)
        {
            return _rooms.Contains(room);
        }
    }
}
