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
            return orders;
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetOrderName")]
        public Order GetName(string name)
        {
            Order order = new Order();
            order = dBProduct.Orders.SingleOrDefault(p => p.NameOrder == name);
            return order;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("AddOrders")]
        public void AddOrders(string nameOrders,string nameClient,string phoneNumber,List<Product> products)
        {
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
            dBProduct.Remove(order);
            dBProduct.SaveChanges();
        }
    }
}
