using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLProductCutting
    {
        public static int CreateProductCutting(String ProductCuttingName, ref List<string> errors)
        {
            List<ProductCuttingInfo> pi = DALProductCutting.ReadProductCuttingList(ref errors);

            if (ProductCuttingName == null)
            {
                errors.Add("Product cutting name cannot be null");
                return -1;
            }

            for (int i = 0; i < pi.Count; i++)
            {
                if (ProductCuttingName.ToLower() == pi[i].product_cutting_name.ToLower())
                {
                    errors.Add("ProductCutting name already exists");
                }
            }

            if (errors.Count > 0)
                return -1;

            return DALProductCutting.CreateProductCutting(ProductCuttingName, ref errors);
        }

        public static ProductCuttingInfo ReadProductCutting(int ProductCuttingId, ref List<string> errors)
        {
            if (ProductCuttingId <= 0 || ProductCuttingId > DALProductCutting.ReadProductCuttingList(ref errors).Count)
            {
                errors.Add("Invalid ProductCutting id");
            }

            if (errors.Count > 0)
                return null;

            return DALProductCutting.ReadProductCuttingDetail(ProductCuttingId, ref errors);
        }

        public static List<ProductCuttingInfo> ReadAllProductCutting(ref List<string> errors)
        {
            return DALProductCutting.ReadProductCuttingList(ref errors);
        }

        public static int UpdateProductCutting(int ProductCuttingId, string ProductCuttingName, ref List<string> errors)
        {
            if (ProductCuttingId <= 0 || ProductCuttingId > DALProductCutting.ReadProductCuttingList(ref errors).Count)
            {
                errors.Add("Invalid ProductCutting id");
            }

            if (errors.Count > 0)
                return -1;

            return DALProductCutting.UpdateProductCutting(ProductCuttingId, ProductCuttingName, ref errors);
        }
    }
}
