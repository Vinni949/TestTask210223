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
            if (products != null)
            {
                return products;
            }
            else
                return null;
        }

        // GET api/<ProductController>/5
        [HttpGet("GetProductName")]
        public Product GetProductName(string name)
        {   
            Product product = new Product();
            product = dBProduct.Products.SingleOrDefault(p => p.Name == name);
            if (product != null)
            {
                return product;
            }
            else
                return null;
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
            if (product != null)
            {
                product.Name = newName;
                dBProduct.SaveChanges();
            }

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("DeletePosition")]
        public void DeletePosition(string name)
        {
            Product product = new Product();
            product = dBProduct.Products.SingleOrDefault(p => p.Name == name);
            if (product != null)
            {
                dBProduct.Products.Remove(product);
                dBProduct.SaveChanges();
            }
        }
    }
}
