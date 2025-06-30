using System;

namespace CosmeticsApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }
    }
}
