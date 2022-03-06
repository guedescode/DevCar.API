using System.Collections.Generic;

namespace DevCars.API.ViewModel
{
    public class OrderDetailsViewModel
    {
        public OrderDetailsViewModel(int idCar, int idCustomer, List<string> extraItems, decimal totalCost)
        {
            IdCar = idCar;
            IdCustomer = idCustomer;
            ExtraItems = extraItems;
            TotalCost = totalCost;
        }

        public int IdCar { get; private set; }
        public int IdCustomer { get; private set; }
        public List<string> ExtraItems { get; private set; }
        public decimal TotalCost { get; private set; }

    }
}
