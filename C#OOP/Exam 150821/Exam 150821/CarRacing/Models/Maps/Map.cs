using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
          
            double multiplier1 = 1.2;
            if (racerOne.RacingBehavior=="aggressive")
            {
                multiplier1 = 1.1;
            }
            double multiplier2 = 1.2;
            if (racerTwo.RacingBehavior == "aggressive")
            {
                multiplier2 = 1.1;
            }
            double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * multiplier1;
            double chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * multiplier2;
            racerOne.Race();
            racerTwo.Race();
            if (chanceOfWinningOne>chanceOfWinningTwo)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            else
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }
            
        }
    }
}
