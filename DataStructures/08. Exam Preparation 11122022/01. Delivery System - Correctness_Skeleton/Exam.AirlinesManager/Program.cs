using System;
using System.Linq;

namespace Exam.DeliveriesManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirlinesManager am = new AirlinesManager();
            var al1 = new Airline("1", "El-Al", 12);
            var al2 = new Airline("2", "Bulgaria Air", 18);
            var al3 = new Airline("3", "Lufthansa", 13);
            var al4 = new Airline("4", "United", 15);

            var fl1 = new Flight("1", "EA1234", "Varna", "Tel Aviv", false);
            var fl2 = new Flight("2", "BA1234", "Sofia", "Tel Aviv", false);
            var fl3 = new Flight("3", "LH1234", "Varna", "Tel Aviv", false);
            var fl5 = new Flight("5", "LH1235", "Berlin", "Varna", false);
            var fl4 = new Flight("4", "UA1234", "New York", "Tel Aviv", false);

            am.AddAirline(al1);
            am.AddAirline(al2);
            am.AddAirline(al3);
            am.AddAirline(al4);

            am.AddFlight(al1, fl1);
            am.AddFlight(al2, fl2);
            am.AddFlight(al2, fl3);
            am.AddFlight(al3, fl5);
            am.AddFlight(al4, fl4);

            Console.WriteLine(String.Join(", ", am.GetAllFlights().Select(n => n.Number)));
            Console.WriteLine(String.Join(", ", am.GetCompletedFlights().Select(n => n.Id)));
            Console.WriteLine(String.Join(", ", am.GetFlightsOrderedByCompletionThenByNumber().Select(n => n.Id)));
            Console.WriteLine(String.Join(", ", am.GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName().Select(n => n.Id)));
            Console.WriteLine(String.Join(", ", am.GetAirlinesWithFlightsFromOriginToDestination("Varna", "Tel Aviv") .Select(n => n.Name)));
        }
    }
}
