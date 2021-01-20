using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public class DateTimeCalculation : IDateTimeCalculation
    {
        public int GetRoundedHoursBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            return Math.Abs((secondDate - firstDate).Minutes) / 60 + 
                   Math.Abs((secondDate - firstDate).Minutes) % 60 > 0 ? 1 : 0;
        }

    }
}
