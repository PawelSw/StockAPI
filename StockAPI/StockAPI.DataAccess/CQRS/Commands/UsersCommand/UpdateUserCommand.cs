using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.UsersCommand
{
    public class UpdateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(StockApiStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
