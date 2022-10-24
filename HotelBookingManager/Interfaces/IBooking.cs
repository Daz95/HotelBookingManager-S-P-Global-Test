using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Booking_Manager.Interfaces
{
    public interface IBooking
    {
        string GuestNameId { get; }
        DateTime Date { get; }
        int Room { get; }
    }
}
