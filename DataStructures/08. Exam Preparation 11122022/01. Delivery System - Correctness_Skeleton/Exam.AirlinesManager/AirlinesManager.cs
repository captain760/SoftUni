using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();   
        private Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
        public void AddAirline(Airline airline)
        {
            airlines.Add(airline.Id, airline);
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }
            airlines[airline.Id].Flights.Add(flight);
            flights[flight.Id] = flight;
        }

        public bool Contains(Airline airline)
        {
            return airlines.ContainsKey(airline.Id);
        }

        public bool Contains(Flight flight)
        {
            return flights.ContainsKey(flight.Id);
        }

        public void DeleteAirline(Airline airline)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }
            foreach (var flight in airlines[airline.Id].Flights)
            {
                flights.Remove(flight.Id);
            }
            airlines.Remove(airline.Id);
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        {
            return airlines.Values.OrderByDescending(x => x.Rating).ThenByDescending(x=>x.Flights.Count).ThenBy(x=>x.Name);
        }

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            return airlines.Values.Where(x => x.Flights.Any(x => !x.IsCompleted && x.Destination == destination && x.Origin == origin)).OrderByDescending(x => x.Flights.Count).ThenBy(x => x.Name);           
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return flights.Values;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            return flights.Values.Where(x => x.IsCompleted);
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            return flights.Values.OrderBy(x => x.IsCompleted).ThenBy(x=>x.Number);
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!flights.ContainsKey(flight.Id) || !airlines.ContainsKey(airline.Id)) 
            {
                throw new ArgumentException();
            }
            flights[flight.Id].IsCompleted = true;
            
            return flights[flight.Id];
        }
    }
}
