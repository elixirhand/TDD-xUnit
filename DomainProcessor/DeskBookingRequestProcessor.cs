using DeskBooker.Core.BaseEntitiy;
using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using System;
using System.Linq;

namespace DeskBooker.Core.DomainProcessor
{
    internal class DeskBookingRequestProcessor
    {
        private readonly IDeskBookingRepository _deskBookingRepository;
        private IDeskRepository _deskRepository;

        public DeskBookingRequestProcessor(IDeskBookingRepository deskBookingRepository,
            IDeskRepository deskRepository)
        {
            _deskBookingRepository = deskBookingRepository;
            _deskRepository = deskRepository;
        }

       internal DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var availableDesks = _deskRepository.GetAvailableDesks(request.Date);
            if(availableDesks.Count() > 0)
            {
                _deskBookingRepository.Save(Create<DeskBooking>(request));
            }

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