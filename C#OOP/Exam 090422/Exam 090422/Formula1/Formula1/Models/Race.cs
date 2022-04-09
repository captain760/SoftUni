using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = tookPlace = false;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get
            {
                return raceName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: { raceName }.");
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return numberOfLaps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: { numberOfLaps }.");
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace 
        { 
            get
            {
                return tookPlace;
            }
            set
            {
                tookPlace = value;
            }
        }

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The { raceName } race has:");
            sb.AppendLine($"Participants: { pilots.Count }");
            sb.AppendLine($"Number of laps: { NumberOfLaps }");
            string val = "No";
            if (TookPlace)
            {
                val = "Yes";
            }
            sb.AppendLine($"Took place: {val}");
            return sb.ToString().TrimEnd();
        }
    }
}
