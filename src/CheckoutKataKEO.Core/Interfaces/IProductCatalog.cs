using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core.Interfaces
{
    public interface IProductCatalog
    {
        Product GetProduct(string sku);
    }
}
