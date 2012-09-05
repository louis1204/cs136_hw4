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
    public class SLProductType : ISLProductType
    {
        public ProductTypeInfo ReadProductType(int id, ref List<string> errors)
        {
            return BLProductType.ReadProductType(id, ref errors);
        }

        public int CreateProductType(string ProductTypeName, ref List<string> errors)
        {
            return BLProductType.CreateProductType(ProductTypeName, ref errors);
        }

        public int UpdateProductType(int ProductTypeID, string ProductTypeName, ref List<string> errors)
        {
            return BLProductType.UpdateProductType(ProductTypeID, ProductTypeName, ref errors);
        }

        public List<ProductTypeInfo> ReadAllProductType(ref List<string> errors)
        {
            return BLProductType.ReadAllProductType(ref errors);
        }
    }
}
