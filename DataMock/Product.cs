using Sramski.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sramski.DataMock
{
    class Product : IProduct
    {
        protected static int iterator = 1;

        public Product()
        {
            Id = Product.iterator++;
        }
        private Product(int id)
        {
            Id = id;
        }
        public Product(string name) : this()
        {
            Name = name;
        }
        public Product(string name, IProducer producer) : this(name)
        {
            Producer = producer;
        }
        public Product(string name, IProducer producer, double price) : this(name, producer)
        {
            Price = price;
        }
        public Product(string name, IProducer producer, double price, bool promotion) : this(name, producer, price)
        {
            Promotion = promotion;
        }

        public object Clone()
        {
            Product p = new Product(Id);
            p.Name = Name;
            p.Producer = Producer;
            p.Price = Price;
            p.Promotion = Promotion;
            return p;
        }

        public void OverwriteValues(IProduct product)
        {
            Name = product.Name;
            Producer = product.Producer;
            Price = product.Price;
            Promotion = product.Promotion;
        }

        public int Id { get; }
        public string Name { get; set; }
        public IProducer Producer { get; set; }
        public double Price { get; set; }
        public bool Promotion { get; set; }
    }
}
