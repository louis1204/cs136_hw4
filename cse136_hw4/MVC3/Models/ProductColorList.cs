using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class ProductColorList
    {
        List<SLProductColor.ProductColorInfo> theProductColorList = new List<SLProductColor.ProductColorInfo>();

        public ProductColorList()
        {
            SLProductColor.ISLProductColor SLProductColor = new SLProductColor.SLProductColorClient();

            string[] errors = new string[0];

            SLProductColor.ProductColorInfo[] validProductColor = SLProductColor.ReadAllProductColor(ref errors);

            var e = from s in validProductColor select s;

            for (int i = 0; i < e.Count(); i++)
            {
                theProductColorList.Add(validProductColor[i]);
            }
        }

        public List<SLProductColor.ProductColorInfo> GettheProductColorList()
        {
            return theProductColorList;
        }

        public SLProductColor.ProductColorInfo GetProductColorDetail(int id)
        {
            return theProductColorList[id];
        }
    }
}