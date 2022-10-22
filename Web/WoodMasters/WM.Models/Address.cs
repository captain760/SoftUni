namespace WM.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}