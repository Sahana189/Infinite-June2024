using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railwayproject.Models
{
    public class Cancellation
    {
        public int CancellationId { get; set; }
        public int BookingId { get; set; }
        public int NoOfSeatsCancelled { get; set; }
        public DateTime CancellationDate { get; set; }
    }
}

