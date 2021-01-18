using NUnit.Framework;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Utils;
using System;

namespace Domain.UnitTests
{
    public class Tests
    {
        IDateTimeCalculation _dateTimeCalculation;

        [SetUp]
        public void Setup()
        {
            _dateTimeCalculation = new DateTimeCalculation();
        }

        [Test]
        public void ParkingCapacityTest()
        {
            int parkingCapacity = 10;
            Parking parking = new Parking("Demo", parkingCapacity);

            Assert.AreEqual(parkingCapacity, parking.ParkingCapacity);
        }

        [Test]
        public void GetRoundedHoursBetweenTwoDates()
        {
            int totalHours = _dateTimeCalculation.GetRoundedHoursBetweenTwoDates(DateTime.Now.AddMinutes(-2), DateTime.Now);

            Assert.AreEqual(totalHours, 1);
        }
    }
}