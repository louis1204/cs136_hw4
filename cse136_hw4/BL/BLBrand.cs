using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLBrand
    {
        public static int CreateBrand(String BrandName, ref List<string> errors)
        {
            if (BrandName == null)
            {
                errors.Add("Brand name cannot be null");

                return -1;
            }
            List<BrandInfo> pi = DALBrand.ReadBrandList(ref errors);

            for (int i = 0; i < pi.Count; i++)
            {
                if (BrandName.ToLower() == pi[i].brand_name.ToLower())
                {
                    errors.Add("Brand name already exists");
                }
            }

            if (errors.Count > 0)
                return -1;

            return DALBrand.CreateBrand(BrandName, ref errors);
        }

        public static BrandInfo ReadBrand(int BrandId, ref List<string> errors)
        {
            if (BrandId <= 0 || BrandId > DALBrand.ReadBrandList(ref errors).Count)
            {
                errors.Add("Invalid Brand id");
            }

            if (errors.Count > 0)
                return null;

            return DALBrand.ReadBrandDetail(BrandId, ref errors);
        }

        public static List<BrandInfo> ReadAllBrand(ref List<string> errors)
        {
            return DALBrand.ReadBrandList(ref errors);
        }

        public static int UpdateBrand(int BrandId, string BrandName, ref List<string> errors)
        {
            if (BrandId <= 0 || BrandId > DALBrand.ReadBrandList(ref errors).Count)
            {
                errors.Add("Invalid Brand id");
            }

            if (errors.Count > 0)
                return -1;

            return DALBrand.UpdateBrand(BrandId, BrandName, ref errors);
        }
    }
}