using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IParkingService
    {
        void EntranceInTheParking(Parking parking, Car car, int slotNumber);
        void ExitFromTheParking(Parking parking, int slotNumber);
    }
}
