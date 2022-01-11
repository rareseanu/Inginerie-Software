using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.Helpers.Comparers
{
    public class TicketComparer : IComparer<TicketDTO>
    {
        public int Compare(TicketDTO? x, TicketDTO? y)
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
