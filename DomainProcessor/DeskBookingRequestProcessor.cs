using DeskBooker.Core.BaseEntitiy;
using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using System;

namespace DeskBooker.Core.DomainProcessor
{
    internal class DeskBookingRequestProcessor
    {
        private readonly IDeskBookingRepository _deskBookingRepository;

        public DeskBookingRequestProcessor(IDeskBookingRepository deskBookingRepository)
        {
            _deskBookingRepository = deskBookingRepository;
        }


        internal DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _deskBookingRepository.Save(Create<DeskBooking>(request));

            return Create<DeskBookingResult>(request);
           
        }

        private static T Create<T>(DeskBookingRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                Fn = request.Fn,
                Ln = request.Ln,
                Email = request.Email,
                Date = request.Date
            };
        }
    }
}