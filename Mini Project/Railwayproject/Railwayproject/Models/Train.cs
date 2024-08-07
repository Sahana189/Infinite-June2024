using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railwayproject.Models
{
    public class Train
    {
        public int Tno { get; set; }
        public string Tname { get; set; }
        public string From { get; set; }
        public string Dest { get; set; }
        public decimal Price { get; set; }
        public string ClassOfTravel { get; set; }
        public string TrainStatus { get; set; }
        public int SeatsAvailable { get; set; }
    }
}
