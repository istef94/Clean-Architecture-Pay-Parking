using Application.Common.Interfaces;
using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public class PriceCalculation : IPriceCalculation
    {
        public double GetParkingPriceByTotalHours(int hours)
        {
            double totalPrice = 0;

            if (hours > 0)
            {
                totalPrice += (double)HourlyPrice.OneHour;
                totalPrice += (double)HourlyPrice.MoreThenOneHour * (hours - 1);
            }

            return totalPrice;
        }
    }
}
