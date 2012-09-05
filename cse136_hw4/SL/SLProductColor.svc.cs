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
    public class SLProductColor : ISLProductColor
    {
        public ProductColorInfo ReadProductColor(int id, ref List<string> errors)
        {
            return BLProductColor.ReadProductColor(id, ref errors);
        }

        public int CreateProductColor(string ProductColorName, ref List<string> errors)
        {
            return BLProductColor.CreateProductColor(ProductColorName, ref errors);
        }

        public int UpdateProductColor(int ProductColorID, string ProductColorName, ref List<string> errors)
        {
            return BLProductColor.UpdateProductColor(ProductColorID, ProductColorName, ref errors);
        }

        public List<ProductColorInfo> ReadAllProductColor(ref List<string> errors)
        {
            return BLProductColor.ReadAllProductColor(ref errors);
        }
    }
}
