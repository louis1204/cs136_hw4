using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using DAL;
using DomainModel;

namespace BLTest
{
    [TestClass]
    public class BLOrderItemTest
    {
        [TestMethod]
        public void CreateOrderItemTest()
        {
            int order_id = -1;
            int pv_id = -1;
            float tax = -1F;
            int quantity = -1;
            float sale_price = -1F;
            char condition = 'z';

            Order_item oi = new Order_item();
            Orders o = new Orders();

            o.order_id = order_id;
            oi.order_id = order_id;
            oi.product_variation_id = 1;
            oi.tax = 0F;
            oi.quantity = 0;
            oi.sale_price = 0F;
            oi.condition = 'a';

            List<string> errors = new List<string>();

            BLOrder_item.CreateOrderItem(null, null, ref errors);
            Assert.AreEqual(1, errors.Count);

            AsynchLog.LogNow(errors);

            //order_id = -1
            errors = new List<string>();

            BLOrder_item.CreateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);

            AsynchLog.LogNow(errors);

            //pv_id = -1
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = pv_id;
            oi.tax = 0F;
            oi.quantity = 0;
            oi.sale_price = 0F;
            oi.condition = 'a';

            errors = new List<string>();

            BLOrder_item.CreateOrderItem(o, oi, ref errors);

            Assert.AreEqual(1, errors.Count);

            AsynchLog.LogNow(errors);

            //tax = -1
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = tax;
            oi.quantity = 0;
            oi.sale_price = 0F;
            oi.condition = 'a';

            errors = new List<string>();
            BLOrder_item.CreateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);

            AsynchLog.LogNow(errors);

            //quantity = -1
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = 0;
            oi.quantity = quantity;
            oi.sale_price = 0F;
            oi.condition = 'a';

            errors = new List<string>();
            BLOrder_item.CreateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);

            AsynchLog.LogNow(errors);

            //sale_price = -1
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = 0;
            oi.quantity = 1;
            oi.sale_price = sale_price;
            oi.condition = 'a';

            errors = new List<string>();
            BLOrder_item.CreateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);

            AsynchLog.LogNow(errors);

            //condition = k
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = 0;
            oi.quantity = 1;
            oi.sale_price = 0;
            oi.condition = condition;

            errors = new List<string>();
            BLOrder_item.CreateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);

            AsynchLog.LogNow(errors);

            //all 8 errors
            o.order_id = order_id;
            oi.order_id = order_id;
            oi.product_variation_id = pv_id;
            oi.tax = tax;
            oi.quantity = quantity;
            oi.sale_price = sale_price;
            oi.condition = condition;

            errors = new List<string>();
            BLOrder_item.CreateOrderItem(o, oi, ref errors);
            Assert.AreEqual(6, errors.Count);

            AsynchLog.LogNow(errors);

            //no errors
            errors = new List<string>();

            //create new order 
            Orders oo = new Orders();
            oo.order_id = 1;
            oo.customer_id = 1;
            oo.subtotal = 0;
            oo.grand_total = 0;
            oo.tax_total = 0;
            oo.condition = 'a';

            int xx = BLOrders.CreateOrder(oo, ref errors);
            Assert.AreEqual(0, errors.Count);

            AsynchLog.LogNow(errors);

            o.order_id = xx;
            oi.order_id = xx;
            oi.product_variation_id = 1;
            oi.tax = 0;
            oi.quantity = 1;
            oi.sale_price = 0;
            oi.condition = 'a';

            errors = new List<string>();
            BLOrder_item.CreateOrderItem(o, oi, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void ReadOrderItemTest()
        {
            int id = 0;
            int pv_id = 0;
            List<string> errors = new List<string>();

            //id = 0 pv_id =0
            Order_item x = BLOrder_item.ReadOrderItem(id, pv_id, ref errors);
            Assert.AreEqual(2, errors.Count);
            Assert.AreEqual(null, x);

            errors = new List<string>();

            //id = 1 pv_id =0
            x = BLOrder_item.ReadOrderItem(1, pv_id, ref errors);
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(null, x);

            errors = new List<string>();

            //id = 0 pv_id =1
            x = BLOrder_item.ReadOrderItem(id, 1, ref errors);
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(null, x);

            //no errors
            errors = new List<string>();

            Order_item y = BLOrder_item.ReadOrderItem(1, 10, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(null, y);
        }

        [TestMethod]
        public void ReadOrderItemsTest()
        {
            int id = 0;
            List<string> errors = new List<string>();

            //id = 0
            List<Order_item> x = BLOrder_item.ReadOrderItems(id, ref errors);
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(null, x);
            AsynchLog.LogNow(errors);

            //no errors
            errors = new List<string>();

            List<Order_item> y = BLOrder_item.ReadOrderItems(19, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);

            errors = new List<string>();

            List<Order_item> z = BLOrder_item.ReadOrderItems(19, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);

            Assert.AreNotEqual(null, y);
            Assert.AreNotEqual(null, z);

            for (int i = 0; i < y.Count; i++)
            {
                Assert.AreEqual(y[i].order_id,z[i].order_id);
            }
        }

        [TestMethod]
        public void UpdateOrderItemTest()
        {
            int order_id = -1;
            int pv_id = -1;
            float tax = -1F;
            int quantity = -1;
            float sale_price = -1F;
            char condition = 'z';

            Order_item oi = new Order_item();
            Orders o = new Orders();

            o.order_id = order_id;
            oi.order_id = order_id;
            oi.product_variation_id = 1;
            oi.tax = 0F;
            oi.quantity = 0;
            oi.sale_price = 0F;
            oi.condition = 'a';

            List<string> errors = new List<string>();

            BLOrder_item.UpdateOrderItem(null, null, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //order_id = -1
            errors = new List<string>();

            BLOrder_item.UpdateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //pv_id = -1
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = pv_id;
            oi.tax = 0F;
            oi.quantity = 0;
            oi.sale_price = 0F;
            oi.condition = 'a';

            errors = new List<string>();

            BLOrder_item.UpdateOrderItem(o, oi, ref errors);

            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //tax = -1
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = tax;
            oi.quantity = 0;
            oi.sale_price = 0F;
            oi.condition = 'a';

            errors = new List<string>();
            BLOrder_item.UpdateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //quantity = -1
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = 0;
            oi.quantity = quantity;
            oi.sale_price = 0F;
            oi.condition = 'a';

            errors = new List<string>();
            BLOrder_item.UpdateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //sale_price = -1
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = 0;
            oi.quantity = 1;
            oi.sale_price = sale_price;
            oi.condition = 'a';

            errors = new List<string>();
            BLOrder_item.UpdateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //condition = k
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = 0;
            oi.quantity = 1;
            oi.sale_price = 0;
            oi.condition = condition;

            errors = new List<string>();
            BLOrder_item.UpdateOrderItem(o, oi, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //all 8 errors
            o.order_id = order_id;
            oi.order_id = order_id;
            oi.product_variation_id = pv_id;
            oi.tax = tax;
            oi.quantity = quantity;
            oi.sale_price = sale_price;
            oi.condition = condition;

            errors = new List<string>();
            BLOrder_item.UpdateOrderItem(o, oi, ref errors);
            Assert.AreEqual(6, errors.Count);
            AsynchLog.LogNow(errors);

            //no errors
            o.order_id = 1;
            oi.order_id = 1;
            oi.product_variation_id = 1;
            oi.tax = 0;
            oi.quantity = 1;
            oi.sale_price = 0;
            oi.condition = 'a';

            errors = new List<string>();
            BLOrder_item.UpdateOrderItem(o, oi, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void DeleteOrderItemTest()
        {
            int id = 0;
            int pv_id = 0;
            List<string> errors = new List<string>();

            //id = 0 pv_id = 0
            int x = BLOrder_item.DeleteOrderItem(id, pv_id, ref errors);
            Assert.AreEqual(2, errors.Count);
            Assert.AreEqual(-1, x);
            AsynchLog.LogNow(errors);

            errors = new List<string>();

            //id = 1 pv_id = 0
            x = BLOrder_item.DeleteOrderItem(1, pv_id, ref errors);
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(-1, x);
            AsynchLog.LogNow(errors);

            errors = new List<string>();

            //id = 0 pv_id = 1
            x = BLOrder_item.DeleteOrderItem(id, 1, ref errors);
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(-1, x);
            AsynchLog.LogNow(errors);

        }
    }
}
