using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;
using BL;

namespace SL
{
    public class SLProduct : ISLProduct
    {
        public ProductInfo ReadProduct(int id, ref List<string> errors)
        {
            return BLProduct.ReadProduct(id, ref errors);
        }

        public int CreateProduct(string ProductName, ref List<string> errors)
        {
            return BLProduct.CreateProduct(ProductName, ref errors);
        }

        public int UpdateProduct(int ProductID, string ProductName, ref List<string> errors)
        {
            return BLProduct.UpdateProduct(ProductID, ProductName, ref errors);
        }

        public List<ProductInfo> ReadAllProduct(ref List<string> errors)
        {
            return BLProduct.ReadAllProduct(ref errors);
        }
    }
}
