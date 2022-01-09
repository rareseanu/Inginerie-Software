using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.Helpers.Comparers
{
    public class TicketComparer : IComparer<Ticket>
    {
        public int Compare(Ticket? x, Ticket? y)
        {
            if (x.PurchasedDate < y.PurchasedDate)
            {
                return -1;
            }
            else if (x.PurchasedDate > y.PurchasedDate)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
