using Application.Products;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator Mediator;
        public ProductsController(IMediator mediator)
        {
            Mediator = mediator;
        }
        /// <summary>
        /// Get products from DB. You can filter them by expiration date using "From" and "To" as Query Params
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> Get([FromQuery] DateTime From,[FromQuery] DateTime To)
        {
            //If "To" query param is not send at http get, higher date will be implemented
            if (To == new DateTime(1, 1, 1)) To=new DateTime(3000, 1, 1);
            var products = await Mediator.Send(new List.Query { From = From, To = To });
            var response = new ResponseDTO() { Products = products,Total=products.Count };
            return response;
        }
        /// <summary>
        /// Create a new product
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Products
        ///     {
        ///           "barcode": "7612547896",
        ///           "name": "COCA COLA",
        ///           "yearProduction": 2020,
        ///           "category":"Soda",
        ///           "expirationDate": "2022-03-24",
        ///           "review": "A great soda"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Create.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}
