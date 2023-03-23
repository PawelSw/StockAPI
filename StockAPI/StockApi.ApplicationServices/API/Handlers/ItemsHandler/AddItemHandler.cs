using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Commands.ItemsCommand;
using StockAPI.DataAccess.CQRS.Commands.ProducersCommand;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Handlers.ItemsHandler
{
    public class AddItemHandler : IRequestHandler<AddItemRequest, AddItemResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public AddItemHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddItemResponse> Handle(AddItemRequest request, CancellationToken cancellationToken)
        {
            var item = this.mapper.Map<Item>(request);
            var command = new AddItemCommand() { Parameter = item };
            var itemFromDB = await this.commandExecutor.Execute(command);
            return new AddItemResponse()
            {
                Data = this.mapper.Map<Domain.Models.Item>(itemFromDB),
            };
        }
    }
}
