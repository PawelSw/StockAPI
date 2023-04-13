using StockAPI.DataAccess.Enums;

namespace StockApi.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }

    }
}
