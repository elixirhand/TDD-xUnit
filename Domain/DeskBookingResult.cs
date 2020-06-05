using DeskBooker.Core.BaseEntitiy;
using System;
using System.Collections.Generic;

namespace DeskBooker.Core.Domain
{
    internal class DeskBookingResult : DeskBookingBase
    {
        public DeskBookingResultCode Code { get; set; }
        public int? DeskBookingId { get; set; }
    }
}