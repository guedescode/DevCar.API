using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevCars.API.Controllers
{
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        public CustomersController(DevCarsDbContext context)
        {
            _dbContext = context;
        }


        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody] AddCustomerInputModel model)
        {
            var customer = new Customer(4, model.FullName, model.Document, model.BirthDate);
            _dbContext.Customers.Add(customer);

            return Ok();
        }


        // POST api/customers/2/orders
        [HttpPost("{id}/orders")]
        public IActionResult PostOrder([FromBody] AddOrderInputModel model, int id)
        {
            var extraItems = model.ExtraItems.Select(e => new ExtraOrderItem(e.Description, e.Price)).ToList();

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == model.IdCar);
            var order = new Order(1, model.IdCar, model.IdCustomer, car.Price, extraItems);
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == model.IdCustomer);
            customer.Purchase(order);

            return CreatedAtAction(nameof(GetOrder),
                new { id = customer.Id, orderid = order.id },
                model
                );
        }


        // GET api/customers/2/orders/3
        [HttpGet("{id}/orders/{orderid}")]
        public IActionResult GetOrder(int id, int orderid)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            var order = customer.Orders.SingleOrDefault(o => o.id == orderid);

            if (order == null)
            {
                return NotFound();
            }

            var extraItems = order.ExtraItems.Select(e => e.Desciption).ToList();
            var orderViewModel = new OrderDetailsViewModel(order.IdCar, order.IdCustomer, extraItems, order.TotalCost);

            return Ok(orderViewModel);
        }

        // api/customers/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok();
        }



        // PUT api/customers/1
        [HttpPut("id")]
        public IActionResult Put(int id)
        {
            return Ok();
        }


        // PUT api/customers/2
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }


    }
}
