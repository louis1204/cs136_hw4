using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLProductColor
    {
        public static int CreateProductColor(String ProductColorName, ref List<string> errors)
        {
            List<ProductColorInfo> pi = DALProductColor.ReadProductColorList(ref errors);

            if (ProductColorName == null)
            {
                errors.Add("Product color name cannot be null");
                return -1;
            }

            for (int i = 0; i < pi.Count; i++)
            {
                if (ProductColorName.ToLower() == pi[i].product_color_name.ToLower())
                {
                    errors.Add("ProductColor name already exists");
                }
            }

            if (errors.Count > 0)
                return -1;

            return DALProductColor.CreateProductColor(ProductColorName, ref errors);
        }

        public static ProductColorInfo ReadProductColor(int ProductColorId, ref List<string> errors)
        {
            if (ProductColorId <= 0 || ProductColorId > DALProductColor.ReadProductColorList(ref errors).Count)
            {
                errors.Add("Invalid ProductColor id");
            }

            if (errors.Count > 0)
                return null;

            return DALProductColor.ReadProductColorDetail(ProductColorId, ref errors);
        }

        public static List<ProductColorInfo> ReadAllProductColor(ref List<string> errors)
        {
            return DALProductColor.ReadProductColorList(ref errors);
        }

        public static int UpdateProductColor(int ProductColorId, string ProductColorName, ref List<string> errors)
        {
            if (ProductColorId <= 0 || ProductColorId > DALProductColor.ReadProductColorList(ref errors).Count)
            {
                errors.Add("Invalid ProductColor id");
            }

            if (errors.Count > 0)
                return -1;

            return DALProductColor.UpdateProductColor(ProductColorId, ProductColorName, ref errors);
        }
    }
}