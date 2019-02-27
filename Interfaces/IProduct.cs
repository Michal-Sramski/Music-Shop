using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sramski.Interfaces
{
    public interface IProduct : ICloneable
    {
        int Id { get; }
        string Name { get; set; }
        IProducer Producer { get; set; }
        double Price { get; set; }
        bool Promotion { get; set; }
        void OverwriteValues(IProduct product);
    }
}
