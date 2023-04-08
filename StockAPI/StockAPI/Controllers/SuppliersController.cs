using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.ApplicationServices.API.Domain.Models;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess;
using StockAPI.DataAccess.Entities;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ApiControllerBase
    {
        private readonly ILogger<SuppliersController> _logger;
        public SuppliersController(IMediator mediator, ILogger<SuppliersController> logger) : base (mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("AllSuppliers")]
        public Task<IActionResult> GetAllSuppliers([FromQuery] GetSuppliersRequest request)
        {
            return this.HandleRequest<GetSuppliersRequest, GetSuppliersResponse>(request);
        }

        [HttpGet]
        [Route("Name")]
        public Task<IActionResult> GetSupplierByName([FromQuery] GetSupplierByNameRequest request)
        {
            return this.HandleRequest<GetSupplierByNameRequest, GetSupplierByNameResponse>(request);
        }

        [HttpGet]
        [Route("{supplierId}")]
        public Task<IActionResult> GetSupplierById([FromRoute] int supplierId)
        {
            var request = new GetSupplierByIdRequest()
            {
                SupplierId = supplierId
            };
            return this.HandleRequest<GetSupplierByIdRequest, GetSupplierByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddSupplier([FromBody] AddSupplierRequest request)
        {
            return this.HandleRequest<AddSupplierRequest, AddSupplierResponse>(request);
        }
        [HttpDelete]
        [Route("{supplierId}")]
        public Task<IActionResult> DeleteSupplier([FromRoute] int supplierId)
        {
            _logger.LogWarning($"Supplier with id: {supplierId} DELETE action invoked.");
            var request = new DeleteSupplierRequest()
            {
                DeleteId = supplierId
            };

            return this.HandleRequest<DeleteSupplierRequest, DeleteSupplierResponse>(request);
        }
        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> UpdateSupplierById([FromRoute] int id, [FromBody] UpdateSupplierRequest request)
        {
            request.UpdateId = id;
            return this.HandleRequest<UpdateSupplierRequest, UpdateSupplierResponse>(request);
        }

    }
}
