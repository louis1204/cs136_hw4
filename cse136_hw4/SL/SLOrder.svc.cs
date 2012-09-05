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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLOrder" in code, svc and config file together.
    public class SLOrder : ISLOrder
    {

        public int CreateOrder(Orders order, ref List<string> errors)
        {
            return BLOrders.CreateOrder(order, ref errors);
        }

        public int UpdateOrder(Orders order, ref List<string> errors)
        {
            return BLOrders.UpdateOrder(order, ref errors);
        }

        public int DeleteOrder(int id, ref List<string> errors)
        {
            return BLOrders.DeleteOrder(id, ref errors);
        }

        public Orders ReadOrder(int id, ref List<string> errors)
        {
            return BLOrders.ReadOrder(id, ref errors);
        }
    }
}
