using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.UserServices;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.Entities;
using StockAPI.DataAccess.CQRS.Commands.UsersCommand;
using StockApi.ApplicationServices.Components.PasswordHasher;
using Microsoft.AspNetCore.Identity;
using StockApi.ApplicationServices.API.ErrorHandling;
using StockAPI.DataAccess.CQRS.Querries.UsersQuerry;

namespace StockApi.ApplicationServices.API.Handlers.UsersHandler
{
    //public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    //{
    //    private readonly IMapper mapper;
    //    private readonly ICommandExecutor commandExecutor;
    //    private readonly IQuerryExecutor queryExecutor;
    //    public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IQuerryExecutor queryExecutor)
    //    {
    //        this.queryExecutor = queryExecutor;
    //        this.commandExecutor = commandExecutor;
    //        this.mapper = mapper;

    //    }
    //    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    //    {
    //        var user = this.mapper.Map<User>(request);
    //        var command = new AddUserCommand() { Parameter = user };
    //        var userFromDB = await this.commandExecutor.Execute(command);
    //        return new AddUserResponse()
    //        {
    //            Data = this.mapper.Map<Domain.Models.User>(userFromDB),
    //        };
    //    }
    //}
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQuerryExecutor queryExecutor;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<User> passwordHasher;

        public AddUserHandler(ICommandExecutor commandExecutor, IQuerryExecutor queryExecutor,
            IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByNameQuerry()
            {
                UserName = request.UserName,
            };

            var getUser = await this.queryExecutor.Execute(query);
            if (getUser != null)
            {
                if (getUser.UserName == request.UserName)
                {
                    return new AddUserResponse()
                    {
                        Error = new ErrorModel(ErrorType.ValidationError + "! The name is already taken.")
                    };
                }

                return new AddUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            request.Password = passwordHasher.HashPassword(getUser, request.Password);

            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand()
            {
                Parameter = user
            };
            var addedUser = await this.commandExecutor.Execute(command);
            var response = new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(addedUser)
            };

            return response;
        }
    }
}
