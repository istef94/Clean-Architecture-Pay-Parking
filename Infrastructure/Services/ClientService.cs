using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ClientService : IClientService
    {
        public List<ParkingSlot> SeeListOfAvailableSlots(Parking parking)
        {
            return parking.ParkingSlots.Where(x => x.ParkedCar == null).ToList();
        }

        public List<ParkingSlot> SeeListOfParkedCars(Parking parking)
        {
            return parking.ParkingSlots.Where(x => x.ParkedCar != null).ToList();
        }
    }
}
