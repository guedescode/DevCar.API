using System;

namespace DevCars.API.ViewModel
{
    public class CarDetailsViewModel
    {
        public CarDetailsViewModel(int id, string brand, string color, string model, string vinCode, int year, decimal price, DateTime productionDate)
        {
            Id = id;
            Brand = brand;
            Color = color;
            Model = model;
            VinCode = vinCode;
            Year = year;
            Price = price;
            ProductionDate = productionDate;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string VinCode { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public DateTime ProductionDate { get; set; }

    }
}
