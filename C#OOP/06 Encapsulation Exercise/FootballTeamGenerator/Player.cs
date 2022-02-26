using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private double skill;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Shooting = shooting;
            Passing = passing;
            Dribble = dribble;
            Sprint = sprint;
            Endurance = endurance;
            Name = name;
        }

        public double Skil
        {
            get 
            {
                skill = 1.0*(endurance + sprint + dribble + passing + shooting) / 5;
                return skill;
            }
            
        }

        private int Shooting
        {
            get { return shooting; }
            set 
            {
                try
                {
                    if (value<0 || value > 100)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Shooting should be between 0 and 100.");
                    
                }
                shooting = value; 
            }
        }


        private int Passing
        {
            get { return passing; }
            set 
            {
                try
                {
                    if (value < 0 || value > 100)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Passing should be between 0 and 100.");
                   
                }
                passing = value; 
            }
        }


        private int Dribble
        {
            get { return dribble; }
            set 
            {
                try
                {
                    if (value < 0 || value > 100)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Dribble should be between 0 and 100.");
                   
                }
                dribble = value; 
            }
        }


        private int Sprint
        {
            get { return sprint; }
            set 
            {
                try
                {
                    if (value < 0 || value > 100)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Sprint should be between 0 and 100.");
                    
                }
                sprint = value; 
            }
        }

        private int Endurance
        {
            get { return endurance; }
            set 
            {
                try
                {
                    if (value < 0 || value > 100)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Endurance should be between 0 and 100.");
                    
                }
                endurance = value;
            }
        }

        public string Name
        {
            get { return name; }
            set 
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("A name should not be empty.");
                    //Environment.Exit(01);
                }
                name = value;
            }
        }

    }
}
