using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.UsersCommand
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(StockApiStorageContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }


    }
}
