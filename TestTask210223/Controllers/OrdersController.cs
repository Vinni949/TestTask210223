using Microsoft.AspNetCore.Mvc;
using TestTask210223.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask210223.Controllers
{
    [Route("api/OrdersController")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        DBProduct dBProduct = new DBProduct();

        // GET: api/<ValuesController>
        [HttpGet("GetOrdersAll")]
        public IEnumerable<Order> Get()
        {
            List<Order> orders = new List<Order>();
            orders = dBProduct.Orders.ToList();
            if (orders != null)
            {
                return orders;
            }
            else
                return null;
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetOrderName")]
        public Order GetName(string name)
        {
            Order order = new Order();
            order = dBProduct.Orders.SingleOrDefault(p => p.NameOrder == name);
            if (order != null)
            { 
                return order; 
            }
            else
                return null;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("AddOrders")]
        public void AddOrders(string nameOrders,string nameClient,string phoneNumber,List<string> nameProducts)
        {
            List<Product> products = new List<Product>();
            foreach (string product in nameProducts)
            {
                Product p = dBProduct.Products.SingleOrDefault(p => p.Name == product);
                if (p != null)
                {
                    products.Add(p);
                }
            }
            Order order = new Order() { NameOrder=nameOrders,Client=nameClient,PhoneNumber=phoneNumber,Products=products};
            dBProduct.Add(order);
            dBProduct.SaveChanges();
        }

        [HttpPut("CreatedOrdersAddPositions")]
        public void CreatedOrdersAddPositions(string name, Product product)
        {
            Order order = new Order();
            order = dBProduct.Orders.SingleOrDefault(p => p.NameOrder == name);
            if (order != null)
            {
                order.Products.Add(product);
                dBProduct.SaveChanges();
            }
        }

        [HttpPut("CreatedOrdersDellPositions")]
        public void CreatedOrdersDellPositions(string name, Product product)
        {
            Order order = new Order();
            order = dBProduct.Orders.SingleOrDefault(p => p.NameOrder == name);
            if (order != null)
            {
                order.Products.Remove(product);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("DeleteName")]
        public void DeleteName(string name)
        {
            Order order = new Order();
            order = dBProduct.Orders.SingleOrDefault(p => p.NameOrder == name);
            if (order != null)
            {
                dBProduct.Remove(order);
                dBProduct.SaveChanges();
            }
        }
    }
}
