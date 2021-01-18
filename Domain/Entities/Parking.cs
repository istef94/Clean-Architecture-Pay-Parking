using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Parking
    {
        public ParkingSlot[] ParkingSlots { get; private set; }
        
        public int ParkingCapacity { get; private set; }

        public string ParkingName { get; private set; }

        public Parking(string _parkingName, int _parkingCapacity)
        {
            ParkingSlots = new ParkingSlot[_parkingCapacity];

            ParkingName = _parkingName;
            ParkingCapacity = _parkingCapacity;

            for(int i=0; i<_parkingCapacity;i++)
            {
                ParkingSlots[i] = new ParkingSlot(i);
            }
        }

    }
}
