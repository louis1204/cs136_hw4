using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLProductType
    {
        public static int CreateProductType(String ProductTypeName, ref List<string> errors)
        {
            List<ProductTypeInfo> pi = DALType.ReadProductTypeList(ref errors);

            if (ProductTypeName == null)
            {
                errors.Add("Product type name cannot be null");
                return -1;
            }

            for (int i = 0; i < pi.Count; i++)
            {
                if (ProductTypeName.ToLower() == pi[i].product_type_name.ToLower())
                {
                    errors.Add("ProductType name already exists");
                }
            }

            if (errors.Count > 0)
                return -1;

            return DALType.CreateProductType(ProductTypeName, ref errors);
        }

        public static ProductTypeInfo ReadProductType(int ProductTypeId, ref List<string> errors)
        {
            if (ProductTypeId <= 0 || ProductTypeId > DALType.ReadProductTypeList(ref errors).Count)
            {
                errors.Add("Invalid ProductType id");
            }

            if (errors.Count > 0)
                return null;

            return DALType.ReadProductTypeDetail(ProductTypeId, ref errors);
        }

        public static List<ProductTypeInfo> ReadAllProductType(ref List<string> errors)
        {
            return DALType.ReadProductTypeList(ref errors);
        }

        public static int UpdateProductType(int ProductTypeId, string ProductTypeName, ref List<string> errors)
        {
            if (ProductTypeId <= 0 || ProductTypeId > DALType.ReadProductTypeList(ref errors).Count)
            {
                errors.Add("Invalid ProductType id");
            }

            if (errors.Count > 0)
                return -1;

            return DALType.UpdateProductType(ProductTypeId, ProductTypeName, ref errors);
        }
    }
}