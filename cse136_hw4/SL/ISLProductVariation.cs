using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel; // this is required
using BL; // this is required

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISLProductVariation
    {

        [OperationContract]
        ProductVariationInfo ReadPV(int id, ref List<string> errors);

        [OperationContract]
        int CreatePV(ProductVariationInfo ProductVariation, ref List<string> errors);

        [OperationContract]
        int UpdatePV(ProductVariationInfo ProductVariation, ref List<string> errors);

        [OperationContract]
        int DeletePV(int id, ref List<string> errors);

        [OperationContract]
        List<ProductVariationInfo> ReadAllPV(ref List<string> errors);

        [OperationContract]
        List<ProductVariationInfo> ReadAllPVCondition(char status, ref List<string> errors);
    }
}
