using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Services;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        private readonly IRoomBookingService _roomBookingService;

        public RoomBookingRequestProcessor(IRoomBookingService roomBookingService)
        {
            this._roomBookingService = roomBookingService;
        }

        public RoomBookingResult BookRoom(RoomBookingRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var availableRooms = _roomBookingService.GetAvailableRooms(request.Date);
            var result = CreateRoomBookingObject<RoomBookingResult>(request);

            if (availableRooms.Any())
            {
                var room = availableRooms.First();
                var roomBooking = CreateRoomBookingObject<RoomBooking>(request);
                roomBooking.RoomId = room.Id;

                _roomBookingService.Save(roomBooking);

                result.RoomBookingId = roomBooking.Id;
                result.Flag = BookingResultFlag.Success;
            }
            else
            {
                result.RoomBookingId = null;
                result.Flag = BookingResultFlag.Failure;
            }

            return result;
        }

        private static TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest request) where TRoomBooking : RoomBookingBase, new()
        {
            return new TRoomBooking
            {
                FullName = request.FullName,
                Email = request.Email,
                Date = request.Date,
            };
        }
    }
}