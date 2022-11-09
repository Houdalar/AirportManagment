using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

//Plane plane = new Plane();
//plane.PlaneType = PlaneType.Airbus;
//plane.Capacity = 200;
//plane.ManufactureDate = new DateTime(2018, 11, 10);

////Plane plane2 = new Plane(PlaneType.Boing, 300, DateTime.Now);
//Plane plane3 = new Plane { PlaneType = PlaneType.Airbus, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };

//Passenger p1 = new Passenger();
//p1.PassengerType();

//Console.WriteLine("*****************************PARTIE 2 *****************************");

//ServiceFlight serviceFlight = new ServiceFlight();
//serviceFlight.Flights = TestData.listFlights;

//initialisation via prop
Plane plane = new Plane();
plane.Capacity = 20;
plane.PlaneId = 1;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boing;
Console.WriteLine("Plane 1 = " + plane.ToString());
// initialisation via constructeur
Plane plane2 = new Plane(20, 1, DateTime.Now, PlaneType.Boing);
Console.WriteLine("Plane 2 = " + plane2.ToString());
//initialiseur d'objet
Plane plane3 = new Plane { PlaneId = 12, PlaneType = PlaneType.Airbus, Capacity = 150 , Flights = TestData.listFlights};
Console.WriteLine("Plane 3 =" + plane3.ToString());


Console.WriteLine("                            ");
Console.WriteLine("---------------------------- GetMyType ----------------------------");
Console.WriteLine("                            ");

Passenger passenger = new Passenger()
{
    BirthDate = new DateTime(1989, 12, 05),
    EmailAddress = "arima.kosei@esprit.tn",
    fullName = new FullName { FirstName = "arima", LastName = "kosei" },
    TelNumber = 20153458,
    PassportNumber = "123456789",
};
Traveller traveller = new Traveller()
{
    BirthDate = new DateTime(2003, 08, 22),
    EmailAddress = "ichigo.kurosaki@esprit.tn",
    fullName = new FullName { FirstName = "ichigo", LastName = "kurosaki" },
    TelNumber = 98122256,
    PassportNumber = "0124884rf5f",
    Nationality = "japanese",
    HealthInformation = "ok"
};
Staff staff = new Staff()
{
    BirthDate = new DateTime(1995, 10, 24),
    EmailAddress = "okabe.rintaro@esprit.tn",
    fullName = new FullName { FirstName = "okabe", LastName = "rintarou" },
    TelNumber = 50143256,
    PassportNumber = "0124954rf5f",
    Salary = 10000,
    Function = "Captain",
    EmployementDate = new DateTime(2022, 08, 01)
};


Console.WriteLine(passenger.PassengerType());
Console.WriteLine(staff.PassengerType());
Console.WriteLine(traveller.PassengerType());
Console.WriteLine("                            ");



Console.WriteLine("---------------------------- PARTIE Services ---------------------------- ");

ServiceFlight serviceFlight = new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;
Console.WriteLine("                            ");
Console.WriteLine("------ Get Flights : destination -> Paris ------");
Console.WriteLine( "                            ");
serviceFlight.GetFlights("Destination", "Paris");


Console.WriteLine("                            ");
Console.WriteLine("------ Destination Grouped Flights ------");
Console.WriteLine("                            ");
serviceFlight.DestinationGroupedFlights();


Console.WriteLine("                            ");
Console.WriteLine("------ Show Flight Detailss ------");
Console.WriteLine("                            ");
serviceFlight.ShowFlightDetails(plane3);


Console.WriteLine("                            ");
Console.WriteLine("------ Duration Average  Destination \"Paris\" ------");
Console.WriteLine("                            ");
Console.WriteLine(serviceFlight.DurationAverage("Paris"));


Console.WriteLine("                            ");
Console.WriteLine("------ OrderedDurationFlights ------");
Console.WriteLine("                            ");
serviceFlight.OrderedDurationFlights().ForEach(Console.WriteLine);


Console.WriteLine("                            ");
Console.WriteLine("------ Senior Travellers ------");
Console.WriteLine("                            ");
serviceFlight.SeniorTravellers(TestData.listFlights[0]).ForEach(Console.WriteLine);


Console.WriteLine("                            ");
Console.WriteLine("---------------------------- Lazy loading ----------------------------");

Flight filght = new Flight()
{
    //FlightId = 1,
    FlightDate = new DateTime(2022, 10, 10),
    Departure = "Tunis",
    Destination = "Paris",
    EffectiveArrival = new DateTime(2022, 10, 11),
    EstimatedDuration = 2,
    AirlineLogo = "plane.pnj",
    plane = new Plane
    {
        Capacity = 150,
        ManufactureDate = new DateTime(2020, 12, 12),
        PlaneType = PlaneType.Airbus
    }
};

AMContext mycontext = new AMContext();
mycontext.Flights.Add(filght); // ajout du flight dans dbset
mycontext.SaveChanges(); // synchronisation

foreach (Flight f in mycontext.Flights)
{
    Console.WriteLine("Flight = " + filght.ToString() +"Plane = " + filght.plane.ToString());
}


Console.WriteLine("                            ");
Console.WriteLine("---------------------------- Fin ----------------------------");
Console.ReadKey();