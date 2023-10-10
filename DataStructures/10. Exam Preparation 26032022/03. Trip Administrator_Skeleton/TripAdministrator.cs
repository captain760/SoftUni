using System;
using System.Collections.Generic;
using System.Linq;

namespace TripAdministrations
{
    public class TripAdministrator : ITripAdministrator
    {
        private HashSet<Trip> trips = new HashSet<Trip>();
        private HashSet<Company> companies = new HashSet<Company>();

        public void AddCompany(Company c)
        {
            if (companies.Contains(c))
            {
                throw new ArgumentException();
            }
            companies.Add(c);
        }

        public void AddTrip(Company c, Trip t)
        {
            if (!companies.Contains(c) || (trips.Contains(t)))
            {
                throw new ArgumentException();
            }
            
                trips.Add(t);
           
            if (!companies.FirstOrDefault(x => x.Name == c.Name).Trips.Contains(t) && companies.FirstOrDefault(x => x.Name == c.Name).Trips.Count<c.TripOrganizationLimit)
            {
                companies.FirstOrDefault(x => x.Name == c.Name).Trips.Add(t);
            }
        }

        public bool Exist(Company c)
        {
            return companies.Contains(c);
        }

        public bool Exist(Trip t)
        {
            return trips.Contains(t);
        }

        public void RemoveCompany(Company c)
        {
            if (!Exist(c))
            {
                throw new ArgumentException();
            }
            var tripsToRemove = new List<Trip>();
            foreach (var t in companies.FirstOrDefault(x => x.Name == c.Name).Trips)
            {
                tripsToRemove.Add(t);
            }
            foreach (var t in tripsToRemove)
            {
                trips.Remove(t);
            }
            companies.Remove(c);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return companies;
        }

        public IEnumerable<Trip> GetTrips()
        {
            return trips;
        }

        public void ExecuteTrip(Company c, Trip t)
        {
            if(!Exist(c) || !Exist(t))
            {
                throw new ArgumentException();
            }
            if (!companies.FirstOrDefault(x => x.Name == c.Name).Trips.Contains(t))
            {
                throw new ArgumentException();
            }
            companies.FirstOrDefault(x => x.Name == c.Name).Trips.Remove(t);
            trips.Remove(t);
        }

        public IEnumerable<Company> GetCompaniesWithMoreThatNTrips(int n)
        {
            return companies.Where(t=>t.Trips.Count > n);
        }

        public IEnumerable<Trip> GetTripsWithTransportationType(Transportation t)
        {
            
            return trips.Where(x=>x.Transportation == t);
        }

        public IEnumerable<Trip> GetAllTripsInPriceRange(int lo, int hi)
        {
            return trips.Where(t=>t.Price>=lo && t.Price<=hi);
        }
    }
}
