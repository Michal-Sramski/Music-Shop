using Sramski.Interfaces;
using System;

namespace Sramski.DataMock
{
    internal class Producer : IProducer
    {
        protected static int iterator = 1;

        public Producer()
        {
            Id = iterator++;
        }
        private Producer(int id)
        {
            Id = id;
        }
        public Producer(string name) : this()
        {
            Name = name;
        }

        public object Clone()
        {
            Producer p = new Producer(Id);
            p.Name = Name;
            return p;
        }

        public void OverwriteValues(IProducer producer)
        {
            Name = producer.Name;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}
