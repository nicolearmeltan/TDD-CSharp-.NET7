using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingApp.Core.Domain;

namespace RoomBookingApp.Core.Services
{
    public interface IRoomBookingService
    {
        void Save(RoomBooking roomBooking);

        IEnumerable<Room> GetAvailableRooms(DateTime date);
    }
}
