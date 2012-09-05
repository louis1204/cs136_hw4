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
    public class SLProductVariation : ISLProductVariation
    {
        public ProductVariationInfo ReadPV(int id, ref List<string> errors)
        {
            return BLProductVariation.ReadPV(id, ref errors);
        }

        public int CreatePV(ProductVariationInfo ProductVariation, ref List<string> errors)
        {
            return BLProductVariation.CreatePV(ProductVariation, ref errors);
        }

        public int UpdatePV(ProductVariationInfo ProductVariation, ref List<string> errors)
        {
            return BLProductVariation.UpdatePV(ProductVariation, ref errors);
        }

        public int DeletePV(int id, ref List<string> errors)
        {
            return BLProductVariation.DeletePV(id, ref errors);
        }

        public List<ProductVariationInfo> ReadAllPV(ref List<string> errors)
        {
            return BLProductVariation.ReadAllPV(ref errors);
        }

        public List<ProductVariationInfo> ReadAllPVCondition(char status, ref List<string> errors)
        {
            return BLProductVariation.ReadAllPV(status, ref errors);
        }
    }
}
