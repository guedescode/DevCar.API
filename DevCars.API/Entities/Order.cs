using System.Collections.Generic;
using System.Linq;

namespace DevCars.API.Entities
{
    public class Order
    {
        public Order(int id, int idCar, int idCustomer,decimal price, List<ExtraOrderItem> items)
        {
            this.id = id;
            IdCar = idCar;
            IdCustomer = idCustomer;
            TotalCost = items.Sum(i => i.Price) + price;

            ExtraItems = items;
        }

        public int id { get; private set; }
        public int IdCar { get; private set; }
        public int IdCustomer { get; private set; }
        public decimal TotalCost { get; private set; }
        public List<ExtraOrderItem> ExtraItems { get; private set; }
    }

    public class ExtraOrderItem
    {
        public ExtraOrderItem(string desciption, decimal price)
        {
            Desciption = desciption;
            Price = price;
        }

        public int Id { get; private set; }
        public string Desciption { get; private set; }
        public decimal Price { get; private set; }



    }
}