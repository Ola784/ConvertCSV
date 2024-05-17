using Microsoft.AspNetCore.Mvc;
using Kiosk.WebAPI.Dto;
using Kiosk.WebAPI.Models;
using Kiosk.WebAPI.Persistance;
using Kiosk.WebAPI.Db.Services;
using FluentValidation;

namespace Kiosk.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
       // private readonly IValidator<CreateProductDto> _validator;
        public ProductController(IProductService productService)//, IValidator<CreateProductDto> validator)
        {
            this._productService = productService;
           // _validator = validator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            var result = _productService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name ="GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDto> Get(int id)
        {
            var result = _productService.GetById(id);
            return Ok(result);
        }


        // return CreatedAtAction() - dynamicznie twrozony url
        /* [HttpPost]
         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public ActionResult Create([FromBody] CreateProductDto dto)
         {
             var id = _productService.Create(dto);

             var actionName = nameof(Get);
             var routeValues = new { id };


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return CreatedAtAction(actionName, routeValues, null);
         }*/

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateProductDto dto)
        {
            /*var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }*/
            var id = _productService.Create(dto);
            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id) 
        {
            _productService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateProductDto dto)
        {
            if (id != dto.Id)
            {
                throw new Exception("Id param is not valid");
            }

            _productService.Update(dto);
            return NoContent();
        }
    }
}
