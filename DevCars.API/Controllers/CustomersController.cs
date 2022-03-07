using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var customer = new Customer( model.FullName, model.Document, model.BirthDate);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return Ok();
        }


        // POST api/customers/2/orders
        [HttpPost("{Id}/orders")]
        public IActionResult PostOrder([FromBody] AddOrderInputModel model, int id)
        {
            var extraItems = model.ExtraItems.Select(e => new ExtraOrderItem(e.Description, e.Price)).ToList();

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == model.IdCar);
            var order = new Order(model.IdCar, model.IdCustomer, car.Price, extraItems);
  
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetOrder),
                new { id = order.IdCustomer, orderid = order.Id },
                model
                );
        }


        // GET api/customers/2/orders/3
        [HttpGet("{Id}/orders/{orderid}")]
        public IActionResult GetOrder(int id, int orderid)
        {
            var order = _dbContext.Orders
                .Include(o => o.ExtraItems)
                .SingleOrDefault(o => o.Id == orderid);

            if (order == null)
            {
                return NotFound();
            }

            var extraItems = order.ExtraItems.Select(e => e.Desciption).ToList();
            var orderViewModel = new OrderDetailsViewModel(order.IdCar, order.IdCustomer, extraItems, order.TotalCost);

            return Ok(orderViewModel);
        }

        // api/customers/1
        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {

            return Ok();
        }



        // PUT api/customers/1
        [HttpPut("Id")]
        public IActionResult Put(int id)
        {
            return Ok();
        }


        // PUT api/customers/2
        [HttpDelete("Id")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }


    }
}
