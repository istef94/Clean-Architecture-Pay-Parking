using Application.Common.Interfaces;
using Application.Exceptions;
using Application.Utils;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ParkingService : IParkingService
    {
        readonly IPriceCalculation _priceCalculation;
        readonly IDateTimeCalculation _dateTimeCalculation;

        public ParkingService(IPriceCalculation priceCalculation, IDateTimeCalculation dateTimeCalculation)
        {
            _priceCalculation = priceCalculation;
            _dateTimeCalculation = dateTimeCalculation;
        }

        public void EntranceInTheParking(Parking parking, Car car, int slotNumber)
        {
            if (parking.ParkingSlots[slotNumber].ParkedCar != null)
                throw new WorkParkingSlotException();

            parking.ParkingSlots[slotNumber].ParkedCar = car;
            parking.ParkingSlots[slotNumber].ParkedOn = DateTime.Now;

            Console.WriteLine($"Car {car.CarNumber} was parketd on slot {slotNumber} successfully");
        }

        public void ExitFromTheParking(Parking parking, int slotNumber)
        {
            var parkedOnSlot = parking.ParkingSlots[slotNumber];
            var currentTime = DateTime.Now;

            if (parkedOnSlot.ParkedCar == null)
                throw new ExitFromparkingException();

            int totalHours = _dateTimeCalculation.GetRoundedHoursBetweenTwoDates(parkedOnSlot.ParkedOn, currentTime);
            var toPayForParking = _priceCalculation.GetParkingPriceByTotalHours(totalHours);

            Console.WriteLine($"You have to pay {toPayForParking} Lei for car {parkedOnSlot.ParkedCar.CarNumber}");

            parking.ParkingSlots[slotNumber].ParkedCar = null;

        }
    }
}
