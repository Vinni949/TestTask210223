using Microsoft.AspNetCore.Mvc;
using TestTask210223.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask210223.Controllers
{
    [Route("api/ProductController")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        DBProduct dBProduct = new DBProduct();

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            products = dBProduct.Products.ToList();
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("GetProductName")]
        public string GetProductName(string name)
        {   
            Product product = new Product();
            product = dBProduct.Products.SingleOrDefault(p => p.Name == name);
            return product.Name;
        }

        
        // PUT api/<ProductController>/5
        [HttpPut("AddPosition")]
        public void AddPosition(string name)
        {
            Product product = new Product() { Name=name};
            dBProduct.Products.Add(product);
            dBProduct.SaveChanges();
            
        }
        [HttpPut("CreatedPosition")]
        public void CreatedPosition(string name, string newName)
        {
            Product product = new Product();
            product = dBProduct.Products.SingleOrDefault(p => p.Name == name);
            product.Name = newName;
            dBProduct.SaveChanges();

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("DeletePosition")]
        public void DeletePosition(string name)
        {
            Product product = new Product();
            product = dBProduct.Products.SingleOrDefault(p => p.Name == name);
            dBProduct.Products.Remove(product);
            dBProduct.SaveChanges();
        }
    }
}
