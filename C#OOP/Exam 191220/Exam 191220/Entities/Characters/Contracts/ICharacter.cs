using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public interface ICharacter
    {
        string Name { get; }
        float Armor { get; }
        float BaseArmor { get; }
        float Health { get; set; }
        float BaseHealth { get; }
        float AbilityPoints { get; }
        Bag Bag { get; }
        bool IsAlive { get; set; }
        void TakeDamage(double hitPoints);
        void UseItem(Item Item);


    }
}
