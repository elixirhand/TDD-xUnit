using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using DeskBooker.Core.DomainProcessor;
using Moq;
using System;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        #region Fields
        private readonly DeskBookingRequest _request;
        private readonly Mock<IDeskBookingRepository> _deskBookingRepositoryMock;
        private readonly DeskBookingRequestProcessor _processor;
        #endregion

        #region Constructor
        public DeskBookingRequestProcessorTests()
        {
            _request = new DeskBookingRequest
            {
                Fn = "Murshad",
                Ln = "Pak",
                Email = "MP@gmail.com",
                Date = new DateTime(2020, 06, 03)
            };

            _deskBookingRepositoryMock = new Mock<IDeskBookingRepository>();

            _processor = new DeskBookingRequestProcessor(_deskBookingRepositoryMock
                .Object);

        }
        #endregion

        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            // Act
            DeskBookingResult result = _processor.BookDesk(_request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_request.Fn, result.Fn);
            Assert.Equal(_request.Ln, result.Ln);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);

        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShoudSaveDeskBooking()
        {
            DeskBooking savedDeskBooking = null;

            _deskBookingRepositoryMock.Setup(x => x.Save(It.IsAny<DeskBooking>()))
                .Callback<DeskBooking>(deskBooking =>
               {
                   savedDeskBooking = deskBooking;
               });

            _processor.BookDesk(_request); //Now verify the object is saved
            _deskBookingRepositoryMock.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Once);
            Assert.NotNull(savedDeskBooking);

            Assert.Equal(_request.Fn, savedDeskBooking.Fn);
            Assert.Equal(_request.Ln, savedDeskBooking.Ln);
            Assert.Equal(_request.Email, savedDeskBooking.Email);
            Assert.Equal(_request.Date, savedDeskBooking.Date);
        } 
    }
}
