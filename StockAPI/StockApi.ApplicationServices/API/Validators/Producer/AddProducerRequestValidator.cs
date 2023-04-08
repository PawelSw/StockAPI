using FluentValidation;
using StockApi.ApplicationServices.API.Domain.ProducerService;

namespace StockApi.ApplicationServices.API.Validators.Producer
{
    public class AddProducerRequestValidator : AbstractValidator<AddProducerRequest>
    {
        public AddProducerRequestValidator()
        { 
            RuleFor(x=>x.Name).Length(3,150);
            
        }
    }
}
