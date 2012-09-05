using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLOrders
    {
        public static int CreateOrder(Orders order, ref List<string> errors)
        {

            if (order == null)
            {
                errors.Add("Order cannot be null");
                Console.WriteLine("Order cannot be null");
            }

            if (errors.Count > 0)
                return -1;


            if (order.order_id <= 0)
            {
                errors.Add("Invalid order id");
            }
            if (order.customer_id < 0)
            {
                errors.Add("Invalid customer id");
            }
            if (order.subtotal < 0)
            {
                errors.Add("Invalid subtotal range");
            }
            if (order.tax_total < 0)
            {
                errors.Add("Invalid taxtotal range");
            }
            if (order.grand_total < 0)
            {
                errors.Add("Invalid grand total range");
            }
            if (order.subtotal + order.tax_total != order.grand_total)
            {
                errors.Add("Invalid amount");
            }
            if (order.condition != 'a' && order.condition != 'd' && order.condition != 's')
            {
                errors.Add("Invalid order condition");
            }
            

            if (errors.Count > 0)
                return -1;

            return DALOrders.CreateOrder(order, ref errors);
        }

        public static int UpdateOrder(Orders order, ref List<string> errors)
        {
            if (order == null)
            {
                errors.Add("Order cannot be null");
            }

            if (errors.Count > 0)
                return -1;

            if (order.order_id <= 0)
            {
                errors.Add("Invalid order id");
            }
            if (order.customer_id < 0)
            {
                errors.Add("Invalid customer id");
            }
            if (order.subtotal < 0)
            {
                errors.Add("Invalid subtotal range");
            }
            if (order.tax_total < 0)
            {
                errors.Add("Invalid taxtotal range");
            }
            if (order.grand_total < 0)
            {
                errors.Add("Invalid grand total range");
            }
            if (order.subtotal + order.tax_total != order.grand_total)
            {
                errors.Add("Invalid amount");
            }
            if (order.condition != 'a' && order.condition != 'd' && order.condition != 's')
            {
                errors.Add("Invalid order condition");
            }
            

            if (errors.Count > 0)
                return -1;

            return DALOrders.UpdateOrder(order, ref errors);
        }

        public static int DeleteOrder(int o, ref List<string> errors)
        {
            if (o <= 0)
            {
                errors.Add("Invalid order id");
            }

            if (errors.Count > 0)
                return -1;

            return DALOrders.DeleteOrder(o, ref errors);
        }

        public static Orders ReadOrder(int o, ref List<string> errors)
        {
            if (o <= 0)
                errors.Add("Invalid order id");

            if (errors.Count > 0)
                return null;

            return DALOrders.ReadOrder(o, ref errors);
        }

    }
}
