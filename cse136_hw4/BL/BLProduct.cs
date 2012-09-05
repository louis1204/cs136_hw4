using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLProduct
    {
        public static int CreateProduct(String productName, ref List<string> errors)
        {
            List<ProductInfo> pi = DALProduct.ReadProductList(ref errors);

            if (productName == null)
            {
                errors.Add("Product name cannot be null");
                return -1;
            }

            for(int i = 0; i < pi.Count; i++)
            {
                if (productName.ToLower() == pi[i].product_name.ToLower())
                {
                    errors.Add("Product name already exists");
                }
            }

            if (errors.Count > 0)
                return -1;

            return DALProduct.CreateProduct(productName, ref errors);
        }

        public static ProductInfo ReadProduct(int productId, ref List<string> errors)
        {
            if (productId <= 0 || productId > DALProduct.ReadProductList(ref errors).Count)
            {
                errors.Add("Invalid product id");
            }

            if (errors.Count > 0)
                return null;

            return DALProduct.ReadProductDetail(productId, ref errors);
        }

        public static List<ProductInfo> ReadAllProduct(ref List<string> errors)
        {
            return DALProduct.ReadProductList(ref errors);
        }

        public static int UpdateProduct(int productId, string productName, ref List<string> errors)
        {
            if (productId <= 0 || productId > DALProduct.ReadProductList(ref errors).Count)
            {
                errors.Add("Invalid product id");
            }

            if (errors.Count > 0)
                return -1;

            return DALProduct.UpdateProduct(productId, productName, ref errors);
        }
    }
}
