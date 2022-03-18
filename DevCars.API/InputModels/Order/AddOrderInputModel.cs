using System.Collections.Generic;

namespace DevCars.API.InputModels.Order
{
    public class AddOrderInputModel
    {
        public int IdCar { get; set; }
        public int IdCustomer { get; set; }
        public List<ExtraItemInputModel> ExtraItems { get; set; }
    }
}
