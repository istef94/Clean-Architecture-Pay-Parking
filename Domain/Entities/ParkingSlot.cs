using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParkingSlot
    {
        public ParkingSlot(int slotLocation)
        {
            SlotLocation = slotLocation;
        }
        public DateTime ParkedOn { get; set; }
        public Car ParkedCar { get; set; }

        public int SlotLocation { get; private set; }
    }
}
