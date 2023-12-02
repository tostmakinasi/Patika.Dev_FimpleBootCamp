using Assignment.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Product> _products;
        public ProductsController()
        {
            _products = new List<Product>();
            Seeds();
        }

        private void Seeds() //Başlangıçta veri kümesini oluşturmak için
        {
            _products.Add(new Product { Id = 1, Name = "Product 1", Price = 10.0 });
            _products.Add(new Product { Id = 2, Name = "Product 2", Price = 20.0 });
            _products.Add(new Product { Id = 3, Name = "Product 3", Price = 10.0 });
            _products.Add(new Product { Id = 4, Name = "Product 4", Price = 20.0 });
            _products.Add(new Product { Id = 5, Name = "Product 5", Price = 10.0 });
            _products.Add(new Product { Id = 6, Name = "Product 6", Price = 20.0 });
            _products.Add(new Product { Id = 7, Name = "Product 7", Price = 10.0 });
            _products.Add(new Product { Id = 8, Name = "Product 8", Price = 20.0 });
            _products.Add(new Product { Id = 9, Name = "Product 9", Price = 10.0 });
            _products.Add(new Product { Id = 10, Name = "Product 10", Price = 20.0 });
            _products.Add(new Product { Id = 11, Name = "Product 11", Price = 10.0 });
            _products.Add(new Product { Id = 12, Name = "Product 12", Price = 20.0 });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_products);//200 Kodu döndürür
        }

        // GET api/products
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
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
                product.Id = _products.OrderByDescending(x=> x.Id).First().Id + 1;
                _products.Add(product);
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
            var product = _products.FirstOrDefault(p => p.Id == id);
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
            var product = _products.FirstOrDefault(p => p.Id == id);

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
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products = _products.Where(p => p.Id != id).ToList();
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
            var filteredProducts = _products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            return Ok(filteredProducts);
        }

        //GET api/products/sort
       [HttpGet("sort")]
        public ActionResult<IEnumerable<Product>> Sort([FromQuery] List<SortParameters> sorting)
        {
            if (sorting == null || !sorting.Any())
            {
                throw new ArgumentException("Sorting parameters are missing.");
            }

            var sortedProducts = _products.ToList();

            
            foreach (var sort in sorting)
            {
                switch (sort.Name.ToLower())
                {
                    case nameof(Product.Name):
                        sortedProducts = sort.Order == Ordering.Ascending
                            ? sortedProducts.OrderBy(p => p.Name).ToList()
                            : sortedProducts.OrderByDescending(p => p.Name).ToList();
                        break;
                    case nameof(Product.Id):
                        sortedProducts = sort.Order == Ordering.Ascending
                            ? sortedProducts.OrderBy(p => p.Id).ToList()
                            : sortedProducts.OrderByDescending(p => p.Id).ToList();
                        break;

                    case nameof(Product.Price):
                        sortedProducts = sort.Order == Ordering.Ascending
                            ? sortedProducts.OrderBy(p => p.Price).ToList()
                            : sortedProducts.OrderByDescending(p => p.Id).ToList();
                        break;

                    default:
                        
                        throw new ArgumentException($"Invalid sorting parameter: {sort.Name}");
                }
            }

            return Ok(sortedProducts);
        }


    }
    public struct SortParameters
    {
        public SortParameters()
        {
            
        }
        public string Name = nameof(Product.Id);
        public Ordering Order = Ordering.Ascending;
    }
    public enum Ordering
    {
        Ascending,
        Descending
    }
}
