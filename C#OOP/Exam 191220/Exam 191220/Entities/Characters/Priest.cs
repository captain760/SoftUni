using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer, ICharacter
    {
        public Priest(string name) : base(name, 50, 25, 40, new Backpack())
        {
            BaseHealth = 50;
            BaseArmor = 25;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this == character)
                {
                    throw new InvalidOperationException(ExceptionMessages.HealerCannotHeal);
                }
                character.Health += this.AbilityPoints;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
