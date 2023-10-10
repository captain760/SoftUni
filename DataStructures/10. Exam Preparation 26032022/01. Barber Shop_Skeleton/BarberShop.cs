using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberShop
{
    public class BarberShop : IBarberShop
    {
        private HashSet<Barber> barbers= new HashSet<Barber>();
        private HashSet<Client> clients= new HashSet<Client>();
        public void AddBarber(Barber b)
        {
            if (this.barbers.Contains(b))
            {
                throw new ArgumentException();
            }
            this.barbers.Add(b);
        }

        public void AddClient(Client c)
        {
            if (this.clients.Contains(c))
            {
                throw new ArgumentException();
            }
            this.clients.Add(c);
        }
    

        public bool Exist(Barber b)
        {
            return this.barbers.Contains(b);
        }
    

        public bool Exist(Client c)
        {
            return this.clients.Contains(c);
        }

        public IEnumerable<Barber> GetBarbers()
        {
            return barbers;
        }

        public IEnumerable<Client> GetClients()
        {
            return clients;
        }

        public void AssignClient(Barber b, Client c)
        {
            if (!Exist(b) || !Exist(c))
            {
                throw new ArgumentException();
            }
            barbers.FirstOrDefault(x=>x.Name==b.Name).Clients.Add(c);
            clients.FirstOrDefault(x=>x.Name==c.Name).Barber = b;
        }

        public void DeleteAllClientsFrom(Barber b)
        {
            if (!Exist(b))
            {
                throw new ArgumentException();
            }
            List<Client> clientsToBeDeleted = new List<Client>();
            foreach (Client c in barbers.FirstOrDefault(x => x.Name == b.Name).Clients)
            {
                clientsToBeDeleted.Add(c);
            }
            foreach (Client c in clientsToBeDeleted)
            {
                clients.Remove(c);
            }
            barbers.FirstOrDefault(x=>x.Name==b.Name).Clients.Clear();  

        }

        public IEnumerable<Client> GetClientsWithNoBarber()
        {
            return clients.Where(x => x.Barber == null);
        }

        public IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc()
        {
           return barbers.OrderByDescending(x=>x.Clients.Count());
        }

        public IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc()
        {
            return barbers.OrderByDescending(x => x.Stars).ThenBy(x => x.HaircutPrice);
        }

        public IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc()
        {
            return clients.Where(x=>x.Barber != null).OrderByDescending(x=>x.Age).ThenByDescending(x=>x.Barber.Stars);
        }
    }
}
