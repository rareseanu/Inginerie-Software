using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Seat : BaseEntity
    {
        public int Number { get; set; }
        public int? WagonId { get; set; }
        public Wagon? Wagon { get; set; }
    }
}
