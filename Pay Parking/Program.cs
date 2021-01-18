using Application.Common.Interfaces;
using Application.Utils;
using Application.ValueObjects;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Utils;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our Dependen
            var serviceProvider = new ServiceCollection()
                .AddTransient<IDateTimeCalculation, DateTimeCalculation>()
                .AddTransient<IPriceCalculation, PriceCalculation>()
                .AddTransient<IClientService, ClientService>()
                .AddTransient<IParkingService, ParkingService>()
                .BuildServiceProvider();

            var clientService = serviceProvider.GetService<IClientService>();
            var parkingService = serviceProvider.GetService<IParkingService>();

            var parking = new Parking("Demo", Constants.ParkingCapacity);

            string inputCommand = string.Empty;
            do
            {
                MenuShow();
                inputCommand = Console.ReadLine();

                switch (inputCommand)
                {
                    case "1":
                        ParkACar(clientService, parkingService, parking);
                        break;

                    case "2":
                        ExitCar(clientService, parkingService, parking);
                        break;
                }
            }
            while (!inputCommand.ToLower().Equals("exit"));
        }

        static void MenuShow()
        {
            Console.WriteLine("");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Park a car on a specific slot");
            Console.WriteLine("2. Car exit from the parking");
        }

        static void ParkACar(IClientService clientService, IParkingService parkingService, Parking parking)
        {
            Console.WriteLine("Which is car number: ");
            string carNumber = Console.ReadLine();

            var listOfAvailableSlots = clientService.SeeListOfAvailableSlots(parking);
            if (listOfAvailableSlots.Count == 0)
            {
                Console.WriteLine("There is no available slots");
            }
            else
            {
                Console.WriteLine("Available slots are:");
                foreach (var slot in listOfAvailableSlots)
                {
                    Console.WriteLine($"Slot location {slot.SlotLocation}");
                }

                Console.WriteLine("On which want to park?");
                int slotNumber = int.Parse(Console.ReadLine());
                parkingService.EntranceInTheParking(parking, new Car(carNumber), slotNumber);
            }
        }

        static void ExitCar(IClientService clientService, IParkingService parkingService, Parking parking)
        {
            var listOfParkedCars = clientService.SeeListOfParkedCars(parking);
            if (listOfParkedCars.Count == 0)
            {
                Console.WriteLine("There is no parked cards");
            }
            else
            {
                Console.WriteLine("Parked cars are:");
                foreach (var slot in listOfParkedCars)
                {
                    Console.WriteLine($"Car number {slot.ParkedCar.CarNumber} on slot location {slot.SlotLocation}");
                }

                Console.WriteLine("From witch slot car will go out? Enter slot number: ");
                int slotNumber = int.Parse(Console.ReadLine());
                parkingService.ExitFromTheParking(parking, slotNumber);
            }
        }
    }
}
