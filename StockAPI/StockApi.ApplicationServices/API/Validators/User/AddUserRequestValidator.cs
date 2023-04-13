using FluentValidation;
using StockApi.ApplicationServices.API.Domain.UserServices;

namespace StockApi.ApplicationServices.API.Validators.User
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            this.RuleFor(x => (int)x.Role).InclusiveBetween(0, 1).NotEmpty().WithMessage("CHOOSE_0_-_1");
        }
    }
}
