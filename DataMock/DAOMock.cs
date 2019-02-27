using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sramski.Interfaces;

namespace Sramski.DataMock
{
    public class DAOMock : IDAO
    {
        private List<IProducer> Producers;
        private List<IProduct> Products;

        public DAOMock()
        {
            CreateLists();
            CreateExampleData();
        }

        void CreateLists()
        {
            Producers = new List<IProducer>();
            Products = new List<IProduct>();
        }

        void CreateExampleData()
        {
            // https://en.wikipedia.org/wiki/Category:Audio_equipment_manufacturers
            IProducer aiwa = new Producer("Aiwa");
            IProducer armstrong = new Producer("Armstrong Audio");
            IProducer blaupunkt = new Producer("Blaupunkt");
            IProducer grundig = new Producer("Grundig");
            IProducer jvc = new Producer("JVC");
            IProducer microlab = new Producer("Microlab");
            IProducer samsung = new Producer("Samsung");

            Producers.Add(aiwa);
            Producers.Add(armstrong);
            Producers.Add(blaupunkt);
            Producers.Add(grundig);
            Producers.Add(jvc);
            Producers.Add(microlab);
            Producers.Add(samsung);

            IProduct prod1 = new Product("Gitara elektryczna", aiwa, 400, false);
            IProduct prod2 = new Product("Gitara basowa", aiwa, 500, true);
            IProduct prod3 = new Product("Gitara akustyczna", aiwa, 550, false);
            IProduct prod4 = new Product("Wieża", samsung, 820, false);
            IProduct prod5 = new Product("Walkman", grundig, 99.99, false);
            IProduct prod6 = new Product("Discman", jvc, 49.99, false);
            IProduct prod7 = new Product("Głośnik basowy", blaupunkt, 420, false);
            IProduct prod8 = new Product("Głośnik bluetooth", jvc, 430, false);

            Products.Add(prod1);
            Products.Add(prod2);
            Products.Add(prod3);
            Products.Add(prod4);
            Products.Add(prod5);
            Products.Add(prod6);
            Products.Add(prod7);
            Products.Add(prod8);
        }

        public IProduct CreateProduct()
        {
            return new Product();
        }

        public IProducer CreateProducer()
        {
            return new Producer();
        }

        public IProducer GetProducer(int Id)
        {
            foreach(IProducer producer in Producers)
            {
                if(producer.Id == Id)
                {
                    return producer;
                }
            }
            throw new Exception("Producer with id "+ Id +" not found");
        }

        public List<IProducer> GetProducers()
        {
            return Producers;
        }

        public IProduct GetProduct(int Id)
        {
            foreach (IProduct product in Products)
            {
                if (product.Id == Id)
                {
                    return product;
                }
            }
            throw new Exception("Product with id " + Id + " not found");
        }

        public List<IProduct> GetProducts()
        {
            return Products;
        }

        public void SaveProducer(IProducer producer)
        {
            if (!Producers.Contains(producer))
            {
                Console.WriteLine("Dodaje bo nie znalazlem, id "+ producer.Id);
                Producers.Add(producer);
            }
            Console.WriteLine("Producer with id "+ producer.Id +" saved!");
        }

        public void SaveProduct(IProduct product)
        {
            if (!Products.Contains(product))
            {
                Products.Add(product);
            }
            Console.WriteLine("Product with id " + product.Id + " saved!");
        }

        public void DeleteProducer(IProducer producer)
        {
            Producers.Remove(producer);
            Console.WriteLine("Producer with id " + producer.Id + " deleted!");
        }

        public void DeleteProduct(IProduct product)
        {
            Products.Remove(product);
            Console.WriteLine("Product with id " + product.Id + " deleted!");
        }
    }
}
