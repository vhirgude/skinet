using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController:ControllerBase  
    {
        private readonly StoreContext _context;
         public ProductsController(StoreContext context)
         {
            _context=context;

         }
         
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products=await _context.Products.ToListAsync();
            return products;
        }
        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int id)
        {
            var product=await _context.Products.FindAsync(id);
            return product;
        }

        
    }
}