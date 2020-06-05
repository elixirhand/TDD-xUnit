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

            _deskBookingRepository.Save(new DeskBooking 
            {
                Fn = request.Fn,
                Ln = request.Ln,
                Email = request.Email,
                Date = request.Date
            });

            return new DeskBookingResult
            {
                Fn = request.Fn,
                Ln = request.Ln,
                Email = request.Email,
                Date = request.Date
            };
        }

    }
}