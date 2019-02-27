using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sramski.Interfaces
{
    public interface IDAO
    {
        IProduct CreateProduct();
        IProducer CreateProducer();
        IProduct GetProduct(int Id);
        IProducer GetProducer(int Id);
        List<IProducer> GetProducers();
        List<IProduct> GetProducts();
        void SaveProducer(IProducer producer);
        void SaveProduct(IProduct product);
        void DeleteProducer(IProducer producer);
        void DeleteProduct(IProduct product);
    }
}
