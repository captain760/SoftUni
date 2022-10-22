namespace WM.Models
{
    public class WoodType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ColorId { get; set; }
        public Color Color { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

    }
}