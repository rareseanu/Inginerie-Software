using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBookingPlatform.TL.DTOs
{
    public class SeatDTO
    {
        public int Number { get; set; }
        public int WagonId { get; set; }
        public WagonDTO Wagon { get; set; }
    }
}
