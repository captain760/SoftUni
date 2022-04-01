using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker, ICharacter
    {
        public Warrior(string name) : base(name, 100, 50, 40, new Satchel())
        {
            BaseHealth = 100;
            BaseArmor = 50;
        }

        public void Attack(Character character)
        {
            if (this == character)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            if (this.IsAlive && character.IsAlive)
            {
                character.TakeDamage(this.AbilityPoints);                
            }     
        }
    }
}
