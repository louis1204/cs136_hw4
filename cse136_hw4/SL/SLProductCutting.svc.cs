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
    public class SLProductCutting : ISLProductCutting
    {
        public ProductCuttingInfo ReadProductCutting(int id, ref List<string> errors)
        {
            return BLProductCutting.ReadProductCutting(id, ref errors);
        }

        public int CreateProductCutting(string ProductCuttingName, ref List<string> errors)
        {
            return BLProductCutting.CreateProductCutting(ProductCuttingName, ref errors);
        }

        public int UpdateProductCutting(int ProductCuttingID, string ProductCuttingName, ref List<string> errors)
        {
            return BLProductCutting.UpdateProductCutting(ProductCuttingID, ProductCuttingName, ref errors);
        }

        public List<ProductCuttingInfo> ReadAllProductCutting(ref List<string> errors)
        {
            return BLProductCutting.ReadAllProductCutting(ref errors);
        }
    }
}
