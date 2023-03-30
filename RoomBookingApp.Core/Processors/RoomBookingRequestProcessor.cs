using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        public RoomBookingRequestProcessor()
        {
        }

        public RoomBookingResult BookRoom(RoomBookingRequest request)
        {
            return new RoomBookingResult
            {
                FullName = request.FullName,
                Email = request.Email,
                Date = request.Date,
            };
        }
    }
}