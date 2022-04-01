using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private float health;
        private float baseHealth;
        private float baseArmor;
        private float armor;



        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = (float)health;
            Health = (float)health;
            Armor = (float)armor;
            AbilityPoints = (float)abilityPoints;
            Bag = bag;
            IsAlive = true;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public float BaseHealth
        {
            get { return baseHealth; }
            protected set
            {
                baseHealth = value;
            }

        }
        public float Armor
        {
            get { return armor; }
            private set
            {
                if (value >= 0)
                {
                    armor = value;
                }
                else
                {
                    armor = 0;
                }

            }
        }
        public float BaseArmor
        {
            get { return baseArmor; }
            protected set
            {

                baseArmor = value;
            }
        }
        public float Health
        {
            get { return health; }
            set
            {
                if (value >= 0 && value <= BaseHealth)
                {
                    health = value;
                }
                else if (value <= 0)
                {
                    this.IsAlive = false;
                    health = 0;
                }

            }
        }
        public float AbilityPoints { get; private set; }
        public bool IsAlive { get; set; }
        public Bag Bag { get; private set; }
        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (hitPoints <= this.Armor)
                {
                    this.Armor -= (float)hitPoints;
                }
                else
                {
                    float diff = (float)(hitPoints - this.Armor);
                    this.Armor = 0;
                    this.Health -= diff;
                    if (this.Health <= 0)
                    {
                        this.IsAlive = false;
                        this.Health = 0;
                    }
                }
            }
            //else
            //{
            //    throw new ArgumentException(ExceptionMessages.AffectedCharacterDead);
            //}
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}