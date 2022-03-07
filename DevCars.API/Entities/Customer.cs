using System;
using System.Collections.Generic;

namespace DevCars.API.Entities
{
    public class Customer
    {

        protected Customer()
        {

        }

        public Customer(string fullName, string document, DateTime birthDAte)
        {
            FullName = fullName;
            Document = document;
            BirthDAte = birthDAte;

            Orders = new List<Order>();
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Document { get; private set; }
        public DateTime  BirthDAte { get; private set; }
        public List<Order> Orders { get; private set; }

        public void Purchase(Order order)
        {
            Orders.Add(order);
        }

    }
}
