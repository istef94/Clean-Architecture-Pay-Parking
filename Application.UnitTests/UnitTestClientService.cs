using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Services;
using NUnit.Framework;

namespace Application.UnitTests
{
    class UnitTestClientService
    {
        IClientService _clientService;
        IParkingService _parkingService;
        IPriceCalculation _priceCalculation;
        IDateTimeCalculation _dateTimeCalculation;

        [SetUp]
        public void Setup()
        {
            _clientService = new ClientService();
            _parkingService = new ParkingService(_priceCalculation, _dateTimeCalculation);
        }

        [Test]
        public void CheckNumberOfAvailableSlots()
        {
            Parking parking = new Parking("Demo", 5);
            _parkingService.EntranceInTheParking(parking, new Car("IS-123"), 1);

            var listOfAvailableSlots = _clientService.SeeListOfAvailableSlots(parking);

            Assert.AreEqual(listOfAvailableSlots.Count, 4);
        }
    }
}
