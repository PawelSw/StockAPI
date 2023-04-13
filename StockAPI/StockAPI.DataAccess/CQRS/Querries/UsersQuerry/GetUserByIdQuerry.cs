using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.UsersQuerry
{
    public class GetUserByIdQuerry : QuerryBase<User>
    {
        public int Id { get; set; }

        public async override Task<User> Execute(StockApiStorageContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
            return user;
        }
    }
}
