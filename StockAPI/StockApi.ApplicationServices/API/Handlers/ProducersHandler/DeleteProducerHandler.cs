using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS.Commands.ItemsCommand;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;
using StockAPI.DataAccess.CQRS.Commands.ProducersCommand;
using StockApi.ApplicationServices.API.ErrorHandling;

namespace StockApi.ApplicationServices.API.Handlers.ProducersHandler
{
    public class DeleteProducerHandler : IRequestHandler<DeleteProducerRequest, DeleteProducerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQuerryExecutor _querryExecutor;

        public DeleteProducerHandler(IMapper mapper,
            ICommandExecutor commandExecutor,
            IQuerryExecutor querryExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
            _querryExecutor = querryExecutor;
        }
        public async Task<DeleteProducerResponse> Handle(DeleteProducerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProducerByIdQuerry()
            {
                Id = request.DeleteId
            };
            var producer = await _querryExecutor.Execute(query);

            if (producer is null)
            {
                return new DeleteProducerResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedProducer = _mapper.Map<StockAPI.DataAccess.Entities.Producer>(request);
            var command = new DeleteProducerCommand()
            {
                Parameter = mappedProducer
            };
            var deleteProducer = await _commandExecutor.Execute(command);
            var response = new DeleteProducerResponse()
            {
                Data = _mapper.Map<Domain.Models.Producer>(deleteProducer)
            };
            return response;
        }
    }
}
