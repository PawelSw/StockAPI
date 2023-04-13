using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockApi.ApplicationServices.API.Domain.UserServices;

namespace StockAPI.Controllers
{
   //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        public UsersController(IMediator mediator, ILogger<UsersController> logger)
            : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("AllUsers")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        //[HttpGet]
        //[Route("UserName")]
        //public Task<IActionResult> GetUserByUsername([FromQuery] GetUserByNameRequest request)
        //{
        //    return this.HandleRequest<GetUserByNameRequest, GetUserByNameResponse>(request);
        //}

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [HttpGet]
        [Route("{userId}")]
        public Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };
            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{userId}")]
        public Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            _logger.LogWarning($"User with id: {userId} DELETE action invoked.");
            var request = new DeleteUserRequest()
            {
                DeleteId = userId
            };

            return this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
        }

        [HttpPut]
        [Route("{userId}")]
        public Task<IActionResult> UpdateSupplierById([FromRoute] int userId, [FromBody] UpdateUserRequest request)
        {
            request.UpdateId = userId;
            return this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }
    }
}
