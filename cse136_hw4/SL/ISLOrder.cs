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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISLOrder" in both code and config file together.
    [ServiceContract]
    public interface ISLOrder
    {
        [OperationContract]
        int CreateOrder(Orders order, ref List<string> errors);
        [OperationContract]
        int UpdateOrder(Orders order, ref List<string> errors);
        [OperationContract]
        int DeleteOrder(int id, ref List<string> errors);
        [OperationContract]
        Orders ReadOrder(int id, ref List<string> errors);
    }
}
