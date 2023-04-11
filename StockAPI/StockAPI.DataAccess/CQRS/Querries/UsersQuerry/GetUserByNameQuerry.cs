using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.UsersQuerry
{
    public class GetUserByNameQuerry : QuerryBase<User>
    {
        public string UserName { get; set; }
        public async override Task<User> Execute(StockApiStorageContext context)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserName.Contains(this.UserName));
        }
    }
}
