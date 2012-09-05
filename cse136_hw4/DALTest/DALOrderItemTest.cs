using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DomainModel;

namespace DALTest
{
    [TestClass]
    public class DALOrderItemTest
    {
        [TestMethod]
        public void CreateOrderItemTest()
        {

            List<string> errors = new List<string>();

            //create new order first to get a new order id

            Orders order = new Orders();
            order.order_id = 1;
            order.customer_id = 1;
            order.grand_total = 0;
            order.tax_total = 0;
            order.subtotal = order.grand_total + order.tax_total;
            order.date_created = new DateTime();
            order.condition = 'a';

            int id = DALOrders.CreateOrder(order, ref errors);


            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, id);

            //now safe to create new order item

            Order_item oi = new Order_item();

            order.order_id = id;

            oi.order_id = id;
            oi.product_variation_id = 10;
            oi.quantity = 100;
            oi.sale_price = 15.8F;
            oi.tax = 0.0875F;

            int result = DALOrder_item.CreateOrderItem(order, oi, ref errors);

            Assert.AreEqual(1, result);
            Assert.AreEqual(0, errors.Count);

            Order_item temp = DALOrder_item.ReadOrderItem(id, 10, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(temp.order_id,id);
            Assert.AreEqual(temp.product_variation_id, 10);
            Assert.AreEqual(temp.quantity, oi.quantity);
            Assert.AreEqual(temp.sale_price, oi.sale_price);
            Assert.AreEqual(temp.tax, oi.tax);
            Assert.AreEqual(temp.condition, 'a');

            Orders temp2 = DALOrders.ReadOrder(id, ref errors);

            Assert.AreEqual(1580, temp2.subtotal);
            Assert.AreEqual(138.25, temp2.tax_total);
            Assert.AreEqual(1718.25, temp2.grand_total);
            Assert.AreEqual('a', temp.condition);

        }
        [TestMethod]
        public void ReadOrderItemTest()
        {

            List<string> errors = new List<string>();

            Order_item temp = null;

            temp = DALOrder_item.ReadOrderItem(16, 1, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(16, temp.order_id);
            Assert.AreEqual(1, temp.product_variation_id);
            Assert.AreEqual(49, temp.quantity);
            Assert.AreEqual(42, temp.sale_price);
            Assert.AreEqual(0, temp.tax);
            Assert.AreEqual('a', temp.condition);

        }
        [TestMethod]
        public void ReadOrderItemsTest()
        {

            List<string> errors = new List<string>();

            List<Order_item> temp = null;
            List<Order_item> temp2 = null;

            temp = DALOrder_item.ReadOrderItems(19, ref errors);
            temp2 = DALOrder_item.ReadOrderItems(19, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(19, temp[0].order_id);
            Assert.AreEqual(5, temp[0].product_variation_id);
            Assert.AreEqual(1, temp[0].quantity);
            Assert.AreEqual(28, temp[0].sale_price);
            Assert.AreEqual(0.01F, temp[0].tax);
            Assert.AreEqual('a', temp[0].condition);

            Assert.AreEqual(19, temp[1].order_id);
            Assert.AreEqual(36, temp[1].product_variation_id);
            Assert.AreEqual(38, temp[1].quantity);
            Assert.AreEqual(43, temp[1].sale_price);
            Assert.AreEqual(0, temp[1].tax);
            Assert.AreEqual('a', temp[1].condition);

            Assert.AreEqual(temp.Count, temp2.Count);

            for (int i = 0; i < temp.Count(); i++)
            {
                Assert.AreEqual(temp[i].order_id, temp2[i].order_id);
                Assert.AreEqual(temp[i].product_variation_id, temp2[i].product_variation_id);
                Assert.AreEqual(temp[i].tax, temp2[i].tax);
                Assert.AreEqual(temp[i].quantity, temp2[i].quantity);
                Assert.AreEqual(temp[i].sale_price, temp2[i].sale_price);
                Assert.AreEqual(temp[i].condition, temp2[i].condition);
            }

        }
        [TestMethod]
        public void UpdateOrderItemTest()
        {

            List<string> errors = new List<string>();
            
            //update exist record
            Order_item oi = new Order_item();

            oi.order_id = 1;
            oi.product_variation_id = 32;
            oi.quantity = 13;

            int result = DALOrder_item.UpdateOrderItem(oi, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(1, result);

            Order_item temp2 = null;
            temp2 = DALOrder_item.ReadOrderItem(1, 32, ref errors);
            Assert.AreEqual(1, temp2.order_id);
            Assert.AreEqual(32, temp2.product_variation_id);
            Assert.AreEqual(13, temp2.quantity);
            Assert.AreEqual(18.99F, temp2.sale_price);
            Assert.AreEqual(0F, temp2.tax);
            Assert.AreEqual('a', temp2.condition);

            //check subtotal, grand total, tax total update
            Orders temp = DALOrders.ReadOrder(1,ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(2260.81F, temp.subtotal);
            Assert.AreEqual(545F, temp.customer_id);
            Assert.AreEqual(2260.81F, temp.grand_total);
            Assert.AreEqual(0F, temp.tax_total);
            Assert.AreEqual('a', temp.condition);

        }
        [TestMethod]
        public void DeleteOrderItemTest()
        {

            List<string> errors = new List<string>();

            //Insert new order
            Orders order = new Orders();
            order.order_id = 1;
            order.customer_id = 1;
            order.grand_total = 0;
            order.tax_total = 0;
            order.subtotal = order.grand_total + order.tax_total;
            order.date_created = new DateTime();
            order.condition = 'a';

            int id = DALOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, id);

            order.order_id = id;

            //Insert new order_item

            Order_item new_item = new Order_item();
            new_item.order_id = id;
            new_item.product_variation_id = 13;
            new_item.tax = 0.07F;
            new_item.quantity = 2;
            new_item.condition = 'a';

            int result = DALOrder_item.CreateOrderItem(order, new_item, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(1, result);

            //make sure the record exist!

            Order_item t = DALOrder_item.ReadOrderItem(id, 13, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(id, t.order_id);
            Assert.AreEqual(13, t.product_variation_id);
            Assert.AreEqual(0.07F, t.tax);
            Assert.AreEqual(2, t.quantity);
            Assert.AreEqual('a', t.condition);

            //delete the new record

            result = DALOrder_item.DeleteOrderItem(id, 13, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(1, result);

            t = DALOrder_item.ReadOrderItem(id, 13, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(id, t.order_id);
            Assert.AreEqual(13, t.product_variation_id);
            Assert.AreEqual(0.07F, t.tax);
            Assert.AreEqual(2, t.quantity);
            Assert.AreEqual('d', t.condition);
        }
    }
}
