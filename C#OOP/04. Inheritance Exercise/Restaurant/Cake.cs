namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DesGrams = 250;
        private const double DesCalories = 1000;
        private const decimal CakePrice = 5M;
        public Cake(string name) : base(name, CakePrice, DesGrams, DesCalories)
        {

        }


    }
}
