using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TokenTest.Auth;
using TokenTest.Models;
using TokenTest.Models.Errors;

namespace TokenTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly TokenAppDbContext _context;

        public ProductsController(TokenAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            List<Product> productsExists = await _context.Products.ToListAsync();
            if (productsExists.Count < 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new BaseError("There are no products"));
            }
            else return productsExists;
        }


        // GET: api/products/filter/query
        [HttpGet("filter/{query}")]
        public IEnumerable<Product> SearchProduct(string query)
        {
            //Contains is already case insensitive: no actions needed.
            IEnumerable<Product> products = _context.Products.Where(product => product.Name.Contains(query));

            if (products.Count() < 1)
            {
                return (IEnumerable<Product>)StatusCode(StatusCodes.Status400BadRequest, new BaseError("Product does not exists!"));
            }
            else return products.ToList();

        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new BaseError("Product does not exists!"));
            }

            return product;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct([FromRoute]long id, [FromBody]Product product)
        {
            if (id != product.ProductId)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new BaseError("Id values used as arguments must be the same"));
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound, new BaseError("Product does not exists!"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new BaseError("Something went wrong"));
                }
            }
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody]Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductById", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new BaseError($"No products found which id is {id}"));
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

    }
}
