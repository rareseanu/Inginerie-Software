using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Wagon : BaseEntity
    {
        public int Number { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
    }
}
