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

            SLProductVariation.ProductVariationInfo[] validPV = SLPV.ReadAllPV(ref errors);

            var e = from s in validPV select s;

            for (int i = 0; i < e.Count(); i++)
            {
                pvList.Add(validPV[i]);
            }
        }

        public List<SLProductVariation.ProductVariationInfo> GetPVList(char condition)
        {
            List<SLProductVariation.ProductVariationInfo> theList = new List<SLProductVariation.ProductVariationInfo>();
            if (condition == 'a')
            {
                for (int i = 0; i < pvList.Count; i++)
                {
                    if (pvList[i].condition == condition)
                    {
                        theList.Add(pvList[i]);
                    }
                }

                return theList;
            }

            if (condition == 'd')
            {
                for (int i = 0; i < pvList.Count; i++)
                {
                    if (pvList[i].condition == condition)
                    {
                        theList.Add(pvList[i]);
                    }
                }

                return theList;
            }

            return pvList;
        }

        public SLProductVariation.ProductVariationInfo GetPVDetail(int id)
        {
            return pvList[id];
        }
    }
}