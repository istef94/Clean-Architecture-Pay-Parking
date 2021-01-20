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
            if (hours > 0)
                return (double)HourlyPrice.OneHour + (double)HourlyPrice.MoreThenOneHour * (hours - 1);
            else
                return 0;
        }
    }
}
