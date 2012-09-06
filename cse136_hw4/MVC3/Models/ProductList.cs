using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class ProductList
    {
        List<SLProduct.ProductInfo> theProductList = new List<SLProduct.ProductInfo>();

        public ProductList()
        {
            SLProduct.ISLProduct SLProduct = new SLProduct.SLProductClient();

            string[] errors = new string[0];

            SLProduct.ProductInfo[] validProduct = SLProduct.ReadAllProduct(ref errors);

            var e = from s in validProduct select s;

            for (int i = 0; i < e.Count(); i++)
            {
                theProductList.Add(validProduct[i]);
            }
        }

        public List<SLProduct.ProductInfo> GettheProductList()
        {
            return theProductList;
        }

        public SLProduct.ProductInfo GetProductDetail(int id)
        {
            return theProductList[id];
        }
    }
}