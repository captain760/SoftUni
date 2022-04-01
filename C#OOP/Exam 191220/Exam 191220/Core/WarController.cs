using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<ICharacter> party;
        private List<IItem> pool;
        public WarController()
        {
            party = new List<ICharacter>();
            pool = new List<IItem>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            ICharacter character = null;
            if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            party.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            IItem item = null;
            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
            pool.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (!party.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            else if (pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            else
            {
                ICharacter character = party.Where(x => x.Name == characterName).FirstOrDefault();
                var item = pool[pool.Count - 1];
                character.Bag.AddItem((Item)item);
                pool.Remove(item);
                return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
            }
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (!party.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            ICharacter character = party.Where(x => x.Name == characterName).FirstOrDefault();
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            var sortedCharacters = party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health).ToList();
            var sb = new StringBuilder();
            foreach (var character in sortedCharacters)
            {
                string vitalStatus = "Alive";
                if (!character.IsAlive)
                {
                    vitalStatus = "Dead";
                }
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{ character.BaseHealth}, AP: { character.Armor}/{ character.BaseArmor}, Status: { vitalStatus}");

            }
            sb.AppendLine();
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            if (!party.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (!party.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            var attacker = party.Where(x => x.Name == attackerName).FirstOrDefault();
            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
            Warrior sureAttacker = (Warrior)attacker;
            var receiver = party.Where(x => x.Name == receiverName).FirstOrDefault();
            sureAttacker.Attack((Character)receiver);
            var sb = new StringBuilder();
            sb.AppendLine($"{ attackerName} attacks { receiverName} for { attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (receiver.IsAlive == false)
            {
                sb.AppendLine($"{ receiver.Name} is dead!");
            }
            return sb.ToString();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            if (!party.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (!party.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }
            var healer = party.Where(x => x.Name == healerName).FirstOrDefault();
            var healingReceiver = party.Where(x => x.Name == healingReceiverName).FirstOrDefault();
            if (!healer.IsAlive || !healingReceiver.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest sureHealer = (Priest)healer;
            sureHealer.Heal((Character)healingReceiver);
            return $"{healerName} heals {healingReceiverName} for {healer.AbilityPoints}! {healingReceiverName} has {healingReceiver.Health} health now!";
        }
    }
}
