using DeskBooker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DeskBooker.Core.DataInterface
{
    public interface IDeskBookingRepository
    {
       void Save(DeskBooking deskBooking);
    }
}
