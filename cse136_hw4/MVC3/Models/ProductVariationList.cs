using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class ProductVariationList
    {
        List<SLProductVariation.ProductVariationInfo> pvList = new List<SLProductVariation.ProductVariationInfo>();

        public ProductVariationList()
        {
            SLProductVariation.ISLProductVariation SLPV = new SLProductVariation.SLProductVariationClient();

            string[] errors = new string[0];

            SLProductVariation.ProductVariationInfo[] validPV = SLPV.ReadAllPVCondition('a', ref errors);

            var e = from s in validPV select s;

            for (int i = 0; i < e.Count(); i++)
            {
                pvList.Add(validPV[i]);
            }
        }

        public List<SLProductVariation.ProductVariationInfo> GetPVList()
        {
            return pvList;
        }

        public SLProductVariation.ProductVariationInfo GetPVDetail(int id)
        {
            return pvList[id];
        }
    }
}