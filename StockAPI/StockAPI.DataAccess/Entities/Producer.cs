using System.ComponentModel.DataAnnotations;

namespace StockAPI.DataAccess.Entities
{
    public class Producer : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public List <Item> Items { get; set; }
    }
}
