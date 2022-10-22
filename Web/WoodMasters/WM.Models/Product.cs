namespace WM.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Thickness { get; set; }
        public int WoodTypeId { get; set; }
        public virtual WoodType WoodType { get; set; }
        public decimal Price { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
} 