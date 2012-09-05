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
    public interface ISLProduct
    {

        [OperationContract]
        ProductInfo ReadProduct(int id, ref List<string> errors);

        [OperationContract]
        int CreateProduct(string name, ref List<string> errors);

        [OperationContract]
        int UpdateProduct(int id, string name, ref List<string> errors);

        [OperationContract]
        List<ProductInfo> ReadAllProduct(ref List<string> errors);
    }
}
