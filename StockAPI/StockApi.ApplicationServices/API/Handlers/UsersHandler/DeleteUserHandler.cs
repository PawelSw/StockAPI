using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.UserServices;
using StockApi.ApplicationServices.API.ErrorHandling;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.UsersQuerry;
using StockAPI.DataAccess.CQRS.Commands.UsersCommand;

namespace StockApi.ApplicationServices.API.Handlers.UsersHandler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQuerryExecutor _querryExecutor;

        public DeleteUserHandler(IMapper mapper,
            ICommandExecutor commandExecutor,
            IQuerryExecutor querryExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
            _querryExecutor = querryExecutor;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuerry()
            {
                Id = request.DeleteId
            };
            var user = await _querryExecutor.Execute(query);

            if (user is null)
            {
                return new DeleteUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedUser = _mapper.Map<StockAPI.DataAccess.Entities.User>(request);
            var command = new DeleteUserCommand()
            {
                Parameter = mappedUser
            };
            var deleteUser = await _commandExecutor.Execute(command);
            var response = new DeleteUserResponse()
            {
                Data = _mapper.Map<Domain.Models.User>(deleteUser)
            };
            return response;
        }
    }
}
