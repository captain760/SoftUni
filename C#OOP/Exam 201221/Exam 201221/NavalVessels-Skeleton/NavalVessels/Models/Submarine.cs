using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {
            submergeMode = false;
        }

        public bool SubmergeMode => submergeMode;

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = 200;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (submergeMode == false)
            {
                submergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                submergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }
        public override string ToString()
        {
            string switched = "OFF";
            if (submergeMode)
            {
                switched = "ON";
            }

            return base.ToString() + Environment.NewLine + $" *Submerge mode: {switched}";
        }
    }
}
