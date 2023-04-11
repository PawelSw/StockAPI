using System.ComponentModel.DataAnnotations;

namespace StockAPI.DataAccess.Entities
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(150)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Password { get; set; }

      
    }
}
