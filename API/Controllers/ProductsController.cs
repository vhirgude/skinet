using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController:ControllerBase  
    {
        public IProductRepository _productRepo { get; }
         public ProductsController(IProductRepository productRepo)
         {
            _productRepo = productRepo;

         }
         
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products=await _productRepo.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int id)
        {
            var product=await _productRepo.GetProductByIdAsync(id);
            return product;
        }

        
    }
}