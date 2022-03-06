using DevCars.API.Entities;
using System.Collections.Generic;

namespace DevCars.API.Persistence
{
    public class DevCarsDbContext
    {

        public DevCarsDbContext()
        {
            Cars = new List<Car>
            {
                new Car(1,"123Abv","Honda","Civic",2021,120000,"Cinza",new System.DateTime(2021,1,1)),
                new Car(3,"789Abv","Chevrolet","Onix",2021,30000,"Branco",new System.DateTime(2021,1,1)),
                new Car(2,"456Abv","Hyundai","Hb20",2021,95000,"Azul",new System.DateTime(2021,1,1)),
            };

            Customers = new List<Customer>
            {
                new Customer(1,"LUCIANO","123",new System.DateTime(1999,1,1)),
                new Customer(1,"GUSTAVO","123",new System.DateTime(1999,1,1)),
                new Customer(1,"GABRIEL","123",new System.DateTime(1999,1,1))
            };

        }

        public List<Car> Cars { get; set; }
        public List<Customer> Customers { get; set; }

    }
}
