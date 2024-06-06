using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Address
    {
        private string street;
        private string city;
        private string stateProvince;
        private string country;

        public Address(string street, string city, string stateProvince, string country)
        {
            this.street = street;
            this.city = city;
            this.stateProvince = stateProvince;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country.ToLower() == "usa";
        }

        public string GetFullAddress()
        {
            return $"{street}\n{city}, {stateProvince}\n{country}";
        }
    }

    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public bool IsInUSA()
        {
            return address.IsInUSA();
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }
    }

    public class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetTotalCost()
        {
            return price * quantity;
        }

        public string GetName()
        {
            return name;
        }

        public string GetProductId()
        {
            return productId;
        }
    }

    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(List<Product> products, Customer customer)
        {
            this.products = products;
            this.customer = customer;
        }

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (Product product in products)
            {
                totalCost += product.GetTotalCost();
            }
            totalCost += customer.IsInUSA() ? 5 : 35;
            return totalCost;
        }

        public string GetPackingLabel()
        {
            string packingLabel = "Packing Label:\n";
            foreach (Product product in products)
            {
                packingLabel += $"{product.GetName()} ({product.GetProductId()})\n";
            }
            return packingLabel;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
            Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");

            Customer customer1 = new Customer("Emily Johnson", address1);
            Customer customer2 = new Customer("Michael Anderson", address2);

            Product product1 = new Product("Gizmos", "W123", 3.5, 10);
            Product product2 = new Product("Thingamabobs", "G456", 5.0, 5);
            Product product3 = new Product("Whatsits", "T789", 7.25, 2);

            List<Product> productsOrder1 = new List<Product> { product1, product2 };
            List<Product> productsOrder2 = new List<Product> { product3 };

            Order order1 = new Order(productsOrder1, customer1);
            Order order2 = new Order(productsOrder2, customer2);

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}\n");
        }
    }
}