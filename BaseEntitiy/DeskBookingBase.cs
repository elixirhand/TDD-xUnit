using System;
using System.Collections.Generic;
using System.Text;

namespace DeskBooker.Core.BaseEntitiy
{
    public class DeskBookingBase
    {
        public string Fn { get; set; }
        public string Ln { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
