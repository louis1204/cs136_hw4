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
    public interface ISLProductType
    {

        [OperationContract]
        ProductTypeInfo ReadProductType(int id, ref List<string> errors);

        [OperationContract]
        int CreateProductType(string name, ref List<string> errors);

        [OperationContract]
        int UpdateProductType(int id, string name, ref List<string> errors);

        [OperationContract]
        List<ProductTypeInfo> ReadAllProductType(ref List<string> errors);
    }
}
