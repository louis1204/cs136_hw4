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
    public interface ISLOrderItem
    {
        [OperationContract]
        int CreateOrderItem(Orders o, Order_item oi, ref List<string> errors);
        [OperationContract]
        int UpdateOrder(Orders o, Order_item oi, ref List<string> errors);
        [OperationContract]
        int DeleteOrder(int id, int pv, ref List<string> errors);
        [OperationContract]
        Order_item ReadOrder(int id, int pv, ref List<string> errors);
        [OperationContract]
        List<Order_item> ReadOrders(int id, ref List<string> errors);
    }
}
