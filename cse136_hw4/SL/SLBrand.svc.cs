using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;
using BL;

namespace SL
{
    public class SLBrand : ISLBrand
    {
        public BrandInfo ReadBrand(int id, ref List<string> errors)
        {
            return BLBrand.ReadBrand(id, ref errors);
        }

        public int CreateBrand(string BrandName, ref List<string> errors)
        {
            return BLBrand.CreateBrand(BrandName, ref errors);
        }

        public int UpdateBrand(int BrandID, string BrandName, ref List<string> errors)
        {
            return BLBrand.UpdateBrand(BrandID, BrandName, ref errors);
        }

        public List<BrandInfo> ReadAllBrand(ref List<string> errors)
        {
            return BLBrand.ReadAllBrand(ref errors);
        }
    }
}
