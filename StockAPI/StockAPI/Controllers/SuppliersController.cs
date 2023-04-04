using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [Route("AllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers([FromQuery] GetSuppliersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("Name")]
        public async Task<IActionResult> GetSupplierByName([FromQuery] GetSupplierByNameRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{supplierId}")]
        public async Task<IActionResult> GetSupplierById([FromRoute] int supplierId)
        {
            var request = new GetSupplierByIdRequest()
            {
                SupplierId = supplierId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddSupplier([FromBody] AddSupplierRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpDelete]
        [Route("{supplierId}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int supplierId)
        {
            var request = new DeleteSupplierRequest()
            {
                DeleteId = supplierId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
            // return this.HandleRequest<DeleteItemRequest, DeleteItemResponse>(request);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSupplierById([FromRoute] int id, [FromBody] UpdateSupplierRequest request)
        {
            request.UpdateId = id;
            var response = await this.mediator.Send(request);
            return this.Ok(response);


            //request.UpdateId = id;
            //return this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }

    }
}
