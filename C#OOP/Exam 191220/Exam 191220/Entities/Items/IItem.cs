using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    interface IItem
    {
        int Weight { get; }
        void AffectCharacter(Character character);
    }
}
