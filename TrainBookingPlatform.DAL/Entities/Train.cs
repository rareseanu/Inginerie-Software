using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Train : BaseEntity
    {
        public int Number { get; set; }
        public List<Wagon> Wagons { get; set; }      
        public List<Departure> Departures { get; set; }
    }
}
