using System;

namespace Sramski.Interfaces
{
    public interface IProducer : ICloneable
    {
        int Id { get; }
        string Name { get; set; }
        void OverwriteValues(IProducer producer);
    }
}
