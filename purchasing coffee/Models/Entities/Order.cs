using System.ComponentModel.DataAnnotations.Schema;

namespace purchasing_coffee.Models.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int quantity { get; set; }
        public float total_price { get; set; }

        [ForeignKey("Coffee")]
        public int coffeeId { get; set; }   
        public Coffee? Coffee { get; set; }

        public DateTime Date = DateTime.Now;
    }
}
