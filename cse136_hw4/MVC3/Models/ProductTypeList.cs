using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class ProductTypeList
    {
        List<SLProductType.ProductTypeInfo> theProductTypeList = new List<SLProductType.ProductTypeInfo>();

        public ProductTypeList()
        {
            SLProductType.ISLProductType SLProductType = new SLProductType.SLProductTypeClient();

            string[] errors = new string[0];

            SLProductType.ProductTypeInfo[] validProductType = SLProductType.ReadAllProductType(ref errors);

            var e = from s in validProductType select s;

            for (int i = 0; i < e.Count(); i++)
            {
                theProductTypeList.Add(validProductType[i]);
            }
        }

        public List<SLProductType.ProductTypeInfo> GettheProductTypeList()
        {
            return theProductTypeList;
        }

        public SLProductType.ProductTypeInfo GetProductTypeDetail(int id)
        {
            return theProductTypeList[id];
        }
    }
}