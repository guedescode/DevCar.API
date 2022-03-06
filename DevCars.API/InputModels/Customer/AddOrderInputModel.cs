using System.Collections.Generic;

namespace DevCars.API.InputModels
{
    public class AddOrderInputModel
    {

        public int IdCar { get; private set; }
        public int IdCustomer { get;private set; }
        public decimal Price { get; private set; }
        public List<ExtraItemInputModel> ExtraItems { get; private set; }

    }

    public class ExtraItemInputModel
    {
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }

}
