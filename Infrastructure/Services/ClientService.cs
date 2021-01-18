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
            var availableParkingSlots = new List<ParkingSlot>();
            foreach (var slot in parking.ParkingSlots)
            {
                if (slot.ParkedCar == null)
                {
                    availableParkingSlots.Add(slot);
                }
            }

            return availableParkingSlots;
        }

        public List<ParkingSlot> SeeListOfParkedCars(Parking parking)
        {
            var listOfParkedCars = new List<ParkingSlot>();
            foreach (var slot in parking.ParkingSlots)
            {
                if (slot.ParkedCar != null)
                {
                    listOfParkedCars.Add(slot);
                }
            }

            return listOfParkedCars;
        }
    }
}
