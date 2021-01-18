using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car
    {
        public Car(string carNumber)
        {
            CarNumber = carNumber;
        }
        public string CarNumber { get; private set; }
    }
}
