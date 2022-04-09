using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel,IBattleship
    {
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            sonarMode = false;
        }

        public bool SonarMode => sonarMode;

        public override void RepairVessel()
        {
            if (this.ArmorThickness<300)
            {
                this.ArmorThickness = 300;
            }
        }

        public void ToggleSonarMode()
        {
            if (sonarMode == false)
            {
                sonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                sonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public override string ToString()
        {
            string switched = "OFF";
            if (sonarMode)
            {
                switched = "ON";
            }
            
            return base.ToString()+Environment.NewLine+ $" *Sonar mode: {switched}";
        }
    }
}
