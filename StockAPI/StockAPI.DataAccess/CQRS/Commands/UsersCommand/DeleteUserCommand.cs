using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.UsersCommand
{
    public class DeleteUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(StockApiStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
