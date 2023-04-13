using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess.CQRS.Commands.SuppliersCommand;
using StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry;
using StockAPI.DataAccess.CQRS;
using StockApi.ApplicationServices.API.Domain.UserServices;
using StockAPI.DataAccess.CQRS.Querries.UsersQuerry;
using StockAPI.DataAccess.CQRS.Commands.UsersCommand;
using StockApi.ApplicationServices.API.ErrorHandling;

namespace StockApi.ApplicationServices.API.Handlers.UsersHandler
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuerryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateUserHandler(
            IMapper mapper,
            IQuerryExecutor queryExecutor,
            ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuerry()
            {
                Id = request.UpdateId
            };
            var user = await _queryExecutor.Execute(query);

            if (user is null)
            {
                return new UpdateUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedSupplier = _mapper.Map<StockAPI.DataAccess.Entities.User>(request);

            var command = new UpdateUserCommand()
            {
                Parameter = mappedSupplier,
            };

            var updatedSupplier = await _commandExecutor.Execute(command);

            var response = new UpdateUserResponse()
            {
                Data = _mapper.Map<Domain.Models.User>(updatedSupplier)
            };

            return response;
        }
    }
}
