using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;

Plane plane = new Plane();
plane.PlaneType = PlaneType.Airbus;
plane.Capacity = 200;
plane.ManufactureDate = new DateTime(2018, 11, 10);

//Plane plane2 = new Plane(PlaneType.Boing, 300, DateTime.Now);
Plane plane3 = new Plane { PlaneType = PlaneType.Airbus, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };

Passenger p1 = new Passenger();
p1.PassengerType();

Console.WriteLine("*****************************PARTIE 2 *****************************");

ServiceFlight serviceFlight = new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;