using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Booking_Manager.Interfaces;

namespace Hotel_Booking_Manager.Booking
{
    public class Booking : IBooking
    {
        public string GuestNameId { get;}
        public DateTime Date { get; }
        public int Room { get; }

        public Booking(string guestNameId, DateTime date, int room)
        {
            GuestNameId = guestNameId;
            Date = date;
            Room = room;
        }


    }
}
