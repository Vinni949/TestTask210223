using Microsoft.AspNetCore.Mvc;
using TestTask210223.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask210223.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        DBProduct dBProduct = new DBProduct();

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            List<Product> products = new List<Product>();
            products = dBProduct.Products.ToList();
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{name}")]
        public string Get(string name)
        {   
            Product product = new Product();
            product = dBProduct.Products.SingleOrDefault(p => p.Name == name);
            return product.Name;
        }

        
        // PUT api/<ProductController>/5
        [HttpPut("{AddPosition}")]
        public void Put(string name)
        {
            Product product = new Product() { Name=name};
            dBProduct.Products.Add(product);
            dBProduct.SaveChanges();
            
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{DeletePosition}")]
        public void Delete(string name)
        {
            Product product = new Product();
            product = dBProduct.Products.SingleOrDefault(p => p.Name == name);
            dBProduct.Products.Remove(product);
            dBProduct.SaveChanges();
        }
    }
}
