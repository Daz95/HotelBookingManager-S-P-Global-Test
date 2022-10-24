using NUnit.Framework;
using HotelBookingManager.BookingManager;
using Hotel_Booking_Manager.Interfaces;

namespace UnitTests
{
    public class BookingManagerTests
    {
        private IBookingManager _bookingManager;

        [SetUp]
        public void Setup()
        {
            _bookingManager = new BookingManager();
        }

        [Test]
        public void BookingMadeAndUnavailable()
        {
            var today = DateTime.Today;
            Assert.IsTrue(_bookingManager.IsRoomAvailable(101, today));

            _bookingManager.AddBooking("Patel", 101, today);
            Assert.IsFalse(_bookingManager.IsRoomAvailable(101, today));
        }

        [Test]
        public void InvalidRoomNumberException()
        {
            var today = DateTime.Today;
            var ex = Assert.Throws<ArgumentException>(() => _bookingManager.AddBooking("Patel", 105, today));
            Assert.That(ex.Message, Is.EqualTo("Invalid Room number!"));
        }

        [Test]
        public void RoomUnavailableException()
        {
            var today = DateTime.Today;
            Assert.IsTrue(_bookingManager.IsRoomAvailable(101, today));

            _bookingManager.AddBooking("Patel", 101, today);
            Assert.IsFalse(_bookingManager.IsRoomAvailable(101, today));

            var ex = Assert.Throws<Exception>(() => _bookingManager.AddBooking("Li", 101, today));
            Assert.That(ex.Message, Is.EqualTo("Room is unavailable for the chosen date."));
        }

        [Test]
        public void GetAvailableRooms()
        {
            var today = DateTime.Today;
            _bookingManager.AddBooking("Patel", 101, today);
            _bookingManager.AddBooking("Patel", 102, today);

            var availableRooms = _bookingManager.GetAvailableRooms(today);
            Assert.That(availableRooms.Count, Is.EqualTo(2));
        }
    }
}