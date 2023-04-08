using FluentValidation;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using System.Security.Cryptography.X509Certificates;

namespace StockApi.ApplicationServices.API.Validators.Supplier
{
    public class AddSupplierRequestValidator : AbstractValidator<AddSupplierRequest>
    {
        public AddSupplierRequestValidator()
        {
            RuleFor(x => x.Name).Length(1,150);
            RuleFor(x => x.Address).Length(1,150);
        }
    }
}
