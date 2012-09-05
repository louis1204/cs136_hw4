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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLOrderItem" in code, svc and config file together.
    public class SLOrderItem : ISLOrderItem
    {

        public int CreateOrderItem(Orders o, Order_item oi, ref List<string> errors)
        {
            return BLOrder_item.CreateOrderItem(o, oi, ref errors);
        }

        public int UpdateOrder(Orders o, Order_item oi, ref List<string> errors)
        {
            return BLOrder_item.UpdateOrderItem(o, oi, ref errors);
        }

        public int DeleteOrder(int id, int pv, ref List<string> errors)
        {
            return BLOrder_item.DeleteOrderItem(id, pv, ref errors);
        }

        public Order_item ReadOrder(int id, int pv, ref List<string> errors)
        {
            return BLOrder_item.ReadOrderItem(id, pv, ref errors);
        }

        public List<Order_item> ReadOrders(int id, ref List<string> errors)
        {
            return BLOrder_item.ReadOrderItems(id, ref errors);
        }
    }
}
