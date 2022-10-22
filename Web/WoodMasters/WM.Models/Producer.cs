using WM.Models.Enums;

namespace WM.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public Experience Experience { get; set; }
    }
}