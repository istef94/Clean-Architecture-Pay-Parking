using NUnit.Framework;
using Application.Common.Interfaces;
using Application.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Services;
using System;

namespace Application.UnitTests
{
    public class UnitTestParkingService
    {
        IParkingService _parkingService;
        IPriceCalculation _priceCalculation;
        IDateTimeCalculation _dateTimeCalculation;

        [SetUp]
        public void Setup()
        {
            _parkingService = new ParkingService(_priceCalculation, _dateTimeCalculation);
        }

        [Test]
        public void TryToParkTwoCarsOnSameSlot()
        {
            Parking parking = new Parking("Demo", 5);
            try
            {
                _parkingService.EntranceInTheParking(parking, new Car("IS-123"), 1);
                _parkingService.EntranceInTheParking(parking, new Car("IS-321"), 1);

                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e is WorkParkingSlotException)
                    Assert.Pass();
                else
                    Assert.Fail();
            }
        }

        [Test]
        public void TryToExitFromTheParkingFromEmptySlot()
        {
            Parking parking = new Parking("Demo", 5);
            try
            {
                _parkingService.ExitFromTheParking(parking, 1);
                Assert.Fail();

            }
            catch (Exception e)
            {
                if (e is ExitFromparkingException)
                    Assert.Pass();
                else
                    Assert.Fail();
            }
        }
    }
}