using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public class DateTimeCalculation: IDateTimeCalculation
    {
        public int GetRoundedHoursBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            var parketMinutes = Math.Abs((secondDate - firstDate).Minutes);
            int totalHours = parketMinutes / 60;
            if (parketMinutes % 60 > 0)
                totalHours++;

            return totalHours;
        }

    }
}
