using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class BrandList
    {
        List<SLBrand.BrandInfo> theBrandList = new List<SLBrand.BrandInfo>();

        public BrandList()
        {
            SLBrand.ISLBrand SLBrand = new SLBrand.SLBrandClient();

            string[] errors = new string[0];

            SLBrand.BrandInfo[] validBrand = SLBrand.ReadAllBrand(ref errors);

            var e = from s in validBrand select s;

            for (int i = 0; i < e.Count(); i++)
            {
                theBrandList.Add(validBrand[i]);
            }
        }

        public List<SLBrand.BrandInfo> GetBrandList()
        {
            return theBrandList;
        }

        public SLBrand.BrandInfo GetBrandDetail(int id)
        {
            return theBrandList[id];
        }
    }
}