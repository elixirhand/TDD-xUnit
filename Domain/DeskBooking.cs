using DeskBooker.Core.BaseEntitiy;
using System;
using System.Collections.Generic;

namespace DeskBooker.Core.Domain
{
    public class DeskBooking : DeskBookingBase
    {
        public int DeskId { get; internal set; }
    }
}