using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess;
using StockAPI.DataAccess.Entities;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator mediator;
        public SuppliersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSuppliers([FromQuery] GetSuppliersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
