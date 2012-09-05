using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;


namespace BL
{
    public static class BLProductVariation
    {
        public static int CreatePV(ProductVariationInfo productVariation, ref List<string> errors)
        {

            if (productVariation == null)
            {
                errors.Add("Product Variation cannot be null");
                return -1;
            }
            System.Diagnostics.Debug.WriteLine("THIS IS THE PID:" + productVariation.product_id);
            if (productVariation.product_id <= 0 || productVariation.product_id > DALProduct.ReadProductList(ref errors).Count)
            {
                errors.Add("Invalid product_id");
            }

            if (productVariation.product_brand_id <= 0 || productVariation.product_brand_id > DALBrand.ReadBrandList(ref errors).Count)
            {
                errors.Add("Invalid product_brand_id");
            }
            if (productVariation.product_cutting_id <= 0 || productVariation.product_cutting_id > DALProductCutting.ReadProductCuttingList(ref errors).Count)
            {
                errors.Add("Invalid product_cutting_id");
            }
            if (productVariation.product_color_id <= 0 || productVariation.product_color_id > DALProductColor.ReadProductColorList(ref errors).Count)
            {
                errors.Add("Invalid product_color_id");
            }
            if (productVariation.sex != 'F' && productVariation.sex != 'M' && productVariation.sex != 'U')
            {
                errors.Add("Invalid sex");
            }
            if (productVariation.size != "XS" && productVariation.size != "S" && productVariation.size != "M" && productVariation.size != "L" && productVariation.size != "XL" && productVariation.size != "XXL")
            {
                errors.Add("Invalid size");
            }
            if (productVariation.stock < 0)
            {
                errors.Add("Invalid stock");
            }
            if (productVariation.price < 0)
            {
                errors.Add("Invalid price");
            }
            if (productVariation.condition != 'a' && productVariation.condition != 's' && productVariation.condition != 'd')
            {
                errors.Add("Invalid condition");
            }

            if (errors.Count > 0)
            {
                return -1;
            }

            return DALProductVariationInfo.CreatePV(productVariation, ref errors);
        }

        public static ProductVariationInfo ReadPV(int productVariationId, ref List<string> errors)
        {
            if (productVariationId <= 0)
            {
                System.Diagnostics.Debug.WriteLine("REACHED here is the id: " + productVariationId);
                errors.Add("Invalid product variation id");
            }

            if (errors.Count > 0)
            {
                return null;
            }

            return DALProductVariationInfo.ReadPVDetail(productVariationId, ref errors);
        }

        public static List<ProductVariationInfo> ReadAllPV(ref List<string> errors)
        {
            return DALProductVariationInfo.ReadPVList(ref errors);
        }

        public static int UpdatePV(ProductVariationInfo productVariation, ref List<string> errors)
        {
            if (productVariation == null)
            {
                errors.Add("Product Variation cannot be null");
            }

            else if (productVariation.product_variation_id <= 0 || productVariation.product_variation_id > DALProductVariationInfo.ReadPVList(ref errors).Count)
            {
                errors.Add("Invalid product variation id");
            }

            else if (productVariation.product_id <= 0 || productVariation.product_id > DALProduct.ReadProductList(ref errors).Count)
            {
                errors.Add("Invalid product_id");
            }

            else if (productVariation.product_brand_id <= 0 || productVariation.product_brand_id > DALBrand.ReadBrandList(ref errors).Count)
            {
                errors.Add("Invalid product_brand_d");
            }
            else if (productVariation.product_cutting_id <= 0 || productVariation.product_cutting_id > DALProductCutting.ReadProductCuttingList(ref errors).Count)
            {
                errors.Add("Invalid product_cutting_id");
            }
            else if (productVariation.product_color_id <= 0 || productVariation.product_color_id > DALProductColor.ReadProductColorList(ref errors).Count)
            {
                errors.Add("Invalid product_color_id");
            }
            else if (productVariation.sex != 'F' && productVariation.sex != 'M' && productVariation.sex != 'U')
            {
                errors.Add("Invalid sex");
            }
            else if (productVariation.size != "XS" && productVariation.size != "S" && productVariation.size != "M" && productVariation.size != "L" && productVariation.size != "XL" && productVariation.size != "XXL")
            {
                errors.Add("Invalid size");
            }
            else if (productVariation.stock < 0)
            {
                errors.Add("Invalid stock");
            }
            else if (productVariation.price < 0)
            {
                errors.Add("Invalid price");
            }
            else if (productVariation.condition != 'a' && productVariation.condition != 's' && productVariation.condition != 'd')
            {
                errors.Add("Invalid condition");
            }

            if (errors.Count > 0)
            {
                return -1;
            }

            return DALProductVariationInfo.UpdateProductVariationInfo(productVariation, ref errors);
        }

        public static int DeletePV(int productVariationId, ref List<string> errors)
        {
            if (productVariationId <= 0)
            {
                errors.Add("Invalid product variation id");
            }

            if (errors.Count > 0)
                return -1;

            return DALProductVariationInfo.DeleteProductVariationInfo(productVariationId, ref errors);
        }

        public static List<ProductVariationInfo> ReadAllPV(char condition, ref List<string> errors)
        {
            if (condition != 'a' && condition != 's' && condition != 'd')
            {
                errors.Add("Invalid condition");
                return null;
            }

            return DALProductVariationInfo.ReadPVList(condition, ref errors);
        }
    }
}
