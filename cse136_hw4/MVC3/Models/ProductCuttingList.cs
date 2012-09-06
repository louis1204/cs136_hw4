using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class ProductCuttingList
    {
        List<SLProductCutting.ProductCuttingInfo> theProductCuttingList = new List<SLProductCutting.ProductCuttingInfo>();

        public ProductCuttingList()
        {
            SLProductCutting.ISLProductCutting SLProductCutting = new SLProductCutting.SLProductCuttingClient();

            string[] errors = new string[0];

            SLProductCutting.ProductCuttingInfo[] validProductCutting = SLProductCutting.ReadAllProductCutting(ref errors);

            var e = from s in validProductCutting select s;

            for (int i = 0; i < e.Count(); i++)
            {
                theProductCuttingList.Add(validProductCutting[i]);
            }
        }

        public List<SLProductCutting.ProductCuttingInfo> GettheProductCuttingList()
        {
            return theProductCuttingList;
        }

        public SLProductCutting.ProductCuttingInfo GetProductCuttingDetail(int id)
        {
            return theProductCuttingList[id];
        }
    }
}