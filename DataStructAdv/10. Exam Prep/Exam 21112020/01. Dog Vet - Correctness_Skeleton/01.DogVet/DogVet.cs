namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        Dictionary<string, Dog> dogs = new Dictionary<string, Dog>();
        Dictionary<string, Owner> owners = new Dictionary<string, Owner>();

        public int Size => dogs.Count;
        public void AddDog(Dog dog, Owner owner)
        {
            if (dogs.ContainsKey(dog.Id))
            {
                throw new ArgumentException();
            }
            if (!owners.ContainsKey(owner.Id))
            {
                owners.Add(owner.Id, owner);
            }
            if (owner.Dogs.ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }
            dog.Owner = owner;
            owners[owner.Id].Dogs.Add(dog.Name, dog);            
            dogs.Add(dog.Id, dog);
            
        }

        public bool Contains(Dog dog)
        {
            return dogs.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }
            
            if (!owners[ownerId].Dogs.ContainsKey(name))
            {
                throw new ArgumentException();
            }
            return owners[ownerId].Dogs[name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            var currentDog = GetDog(name, ownerId);
            if (currentDog!=null)
            {
                owners[ownerId].Dogs.Remove(name);
                dogs.Remove(currentDog.Id);
                return currentDog;
            }
            else 
            { 
                throw new ArgumentException();
            }
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }
            return owners[ownerId].Dogs.Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            var dogsByBreed = dogs.Values.Where(b=>b.Breed.Equals(breed)).ToList();
            if (dogsByBreed.Count!=0)
            {
                return dogsByBreed;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Vaccinate(string name, string ownerId)
        {
            var dog = GetDog(name, ownerId);
            if (dog != null)
            {
                owners[ownerId].Dogs[name].Vaccines++;
                
            }
            else
            {
                throw new ArgumentException();
            }

        }

        public void Rename(string oldName, string newName, string ownerId)
        {            
            var dog = GetDog(oldName, ownerId);

            if (owners[ownerId].Dogs.ContainsKey(newName))
            {
                throw new ArgumentException();
            }

            owners[ownerId].Dogs.Remove(oldName);
            dog.Name = newName;
            owners[ownerId].Dogs.Add(dog.Name, dog);
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            var dogsByAge =  dogs.Values.Where(b=>b.Age == age).ToList();    
            if (dogsByAge.Count!=0) {  return dogsByAge; }
            else { throw new ArgumentException(); }
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            return dogs.Values.Where(b => b.Age >= lo && b.Age <= hi);
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return dogs.Values.OrderBy(x=>x.Age)
                              .ThenBy(n=>n.Name)
                              .ThenBy(n=>n.Owner.Name);
        }
    }
}