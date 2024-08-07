﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railwayproject.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int Tno { get; set; }
        public string ClassOfTravel { get; set; }
        public int NoOfSeats { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
