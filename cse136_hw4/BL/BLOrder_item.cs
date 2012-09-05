using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLOrder_item
    {
        public static int CreateOrderItem(Orders order, Order_item oi, ref List<string> errors)
        {
            if (order == null || oi == null)
            {
                errors.Add("Order cannot be null");
            }
            if (errors.Count > 0)
            {
                return -1;
            }
            if (order.order_id <= 0 || oi.order_id <= 0)
            {
                errors.Add("Invalid order id");
            }
            if (oi.product_variation_id < 0)
            {
                errors.Add("Invalid product variation id");
            }
            if (oi.tax < 0)
            {
                errors.Add("Invalid tax range");
            }
            if (oi.quantity < 0)
            {
                errors.Add("Invalid quantity");
            }
            if (oi.sale_price < 0)
            {
                errors.Add("Invalid sale price");
            }
            if (oi.condition != 'a' && oi.condition != 'd')
            {
                errors.Add("Invalid order item condition");
            }


            if (errors.Count > 0)
                return -1;

            return DALOrder_item.CreateOrderItem(order, oi, ref errors);
        }

        public static int UpdateOrderItem(Orders order, Order_item oi, ref List<string> errors)
        {
            if (order == null || oi == null)
            {
                errors.Add("Order cannot be null");
            }
            if (errors.Count > 0)
            {
                return -1;
            }
            if (order.order_id <= 0 || oi.order_id <= 0)
            {
                errors.Add("Invalid order id");
            }
            if (oi.product_variation_id < 0)
            {
                errors.Add("Invalid product variation id");
            }
            if (oi.tax < 0)
            {
                errors.Add("Invalid tax range");
            }
            if (oi.quantity < 0)
            {
                errors.Add("Invalid quantity");
            }
            if (oi.sale_price < 0)
            {
                errors.Add("Invalid sale price");
            }
            if (oi.condition != 'a' && oi.condition != 'd')
            {
                errors.Add("Invalid order item condition");
            }


            if (errors.Count > 0)
                return -1;

            return DALOrders.UpdateOrder(order, ref errors);
        }

        public static int DeleteOrderItem(int o, int pv, ref List<string> errors)
        {
            if (o <= 0)
            {
                errors.Add("Invalid order id");
            }
            if (pv <= 0)
            {
                errors.Add("Invalid product variation id");
            }

            if (errors.Count > 0)
                return -1;
            return DALOrder_item.DeleteOrderItem(o, pv, ref errors);
        }

        public static Order_item ReadOrderItem(int o, int pv, ref List<string> errors)
        {
            if (o <= 0)
            {
                errors.Add("Invalid order id");
            }
            if (pv <= 0)
            {
                errors.Add("Invalid product variation id");
            }

            if (errors.Count > 0)
                return null;

            return DALOrder_item.ReadOrderItem(o, pv, ref errors);
        }

        public static List<Order_item> ReadOrderItems(int o, ref List<string> errors)
        {
            if (o <= 0)
            {
                errors.Add("Invalid order id");
            }

            if (errors.Count > 0)
                return null;

            return DALOrder_item.ReadOrderItems(o, ref errors);            
        }
    }
}
