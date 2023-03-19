using System.ComponentModel.DataAnnotations;

namespace StockAPI.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
