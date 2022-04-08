using Gym.Models.Athletes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private int stamina;
        
        private string motivation;
        private int numberOfMedals;
        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            Stamina = stamina;
            NumberOfMedals = numberOfMedals;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }
                fullName = value;
            }
        }

        public string Motivation
        {
            get
            {
                return motivation;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }
                motivation = value;
            }
        }

        public int Stamina
        {
            get
            {
                return stamina;
            }
            protected set
            {
                if (value >100)
                {
                    stamina = 100;
                    throw new ArgumentException("Stamina cannot exceed 100 points.");
                }
                stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get
            {
                return numberOfMedals;
            }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }
                numberOfMedals = value;
            }
        }

        public abstract void Exercise();
        
    }
}
