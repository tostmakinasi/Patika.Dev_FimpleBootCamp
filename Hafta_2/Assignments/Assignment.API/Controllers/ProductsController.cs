using Assignment.API.Models;
using AssignmentHafta2.API.Extensions;
using AssignmentHafta2.API.QueryParameters;
using AssignmentHafta2.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] string search, string orderby, Ordering order)
        {
            var products = _productService.GetAll();

            if(string.IsNullOrEmpty(search))
                products = products.Where(x => x.Name == search).ToList();


            products.SortWithParametersExtension(new SortParameters(orderby,order));

            return Ok(products);//200 Kodu döndürür
        }

        // GET api/products
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                return Ok(product);//200
            }
            else
            {
                return NotFound(new { error = "Product not found" });//404
            }
        }

        // POST api/products
        [HttpPost]
        public ActionResult Create([FromBody] Product product)
        {
            if (product != null && ModelState.IsValid)
            {
                _productService.Add(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);//201
            }
            else
            {
                return BadRequest(new { error = "Invalid data" });//400
            }
        }

        // PUT api/products/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            var product = _productService.GetById(id);
            if (product != null && ModelState.IsValid)
            {
                product.Name = updatedProduct.Name ?? product.Name;
                product.Price = updatedProduct.Price == 0 ? product.Price : updatedProduct.Price;
                return Ok(new { message = "Product updated successfully" });
            }
            else
            {
                return NotFound(new { error = "Product not found" });
            }
        }

        // PATCH api/products/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchProduct(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound(new { error = "Product not found" });
            }

            if (patchDoc == null)
            {
                return BadRequest(new { error = "Patch document is null" });
            }

            patchDoc.ApplyTo(product);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(new { message = "Product patched successfully" });
        }

        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                _productService.Remove(product);
                return Ok(new { message = "Product deleted successfully" });
            }
            else
            {
                return NotFound(new { error = "Product not found" });
            }
        }

        // GET api/products/search?name=
        [HttpGet("search")]
        public ActionResult<IEnumerable<Product>> SearchByName([FromQuery] string name)
        {
            var filteredProducts = _productService.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            return Ok(filteredProducts);
        }



    }

    
}
