using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Commands.ProducersCommand;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Handlers.ProducersHandler
{
    public class AddProducerHandler : IRequestHandler<AddProducerRequest, AddProducerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public AddProducerHandler(IMapper mapper, ICommandExecutor commandExecutor) 
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        
        }
        public async Task<AddProducerResponse> Handle(AddProducerRequest request, CancellationToken cancellationToken)
        {
            var producer = this.mapper.Map<Producer>(request);
            var command = new AddProducerCommand() { Parameter = producer };
            var producerFromDB = await this.commandExecutor.Execute(command);
            return new AddProducerResponse()
            {
                Data = this.mapper.Map<Domain.Models.Producer>(producerFromDB),
            };
        }
    }
}
