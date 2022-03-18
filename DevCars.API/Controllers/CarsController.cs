using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevCars.API.Controllers
{
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {

        private readonly DevCarsDbContext _dbContext;
        public CarsController(DevCarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var cars = _dbContext.Cars;

            var carsViewModel = cars
                .Where(c => c.Status == CarStatusEnum.Available)
                .Select(c => new CarItemViewModel(c.Id, c.Brand, c.Model, c.Price))
                .ToList();

            return Ok(carsViewModel);
        }

        // api/cars/1
        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            var carDetailViewModel = new CarDetailsViewModel(
                    car.Id,
                    car.Brand,
                    car.Color,
                    car.Model,
                    car.VinCode,
                    car.Year,
                    car.Price,
                    car.ProductionDate                 
                );

            return Ok(carDetailViewModel);
        }

        // POST api/cars
        [HttpPost]
        public IActionResult Post([FromBody] AddCarInputModel model)
        {
            var car = new Car(model.VinCode, model.Brand, model.Model, model.Year,model.Price,model.Color,model.ProductionDate);

            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = car.Id},
                model
                );
        }

        // PUT api/cars/1
        [HttpPut("Id")]
        public IActionResult Put(int id, [FromBody] UpdateCarInputModel model)
        {
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            car.Update(model.Color, model.Price);
            _dbContext.SaveChanges();

            return NoContent();
        }


        // PUT api/cars/2
        [HttpDelete("Id")]
        public IActionResult Delete(int id)
        {
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            car.SetAsSuspended();
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}
