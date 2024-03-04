using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace purchasing_coffee.Models.Entities
{
    public class Coffee
    {
        public int CoffeeId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float price { get; set; }
        public string? ImageUrl { get; set; }

        public Order? order { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
