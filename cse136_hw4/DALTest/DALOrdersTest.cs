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
    public class DALOrdersTest
    {
        [TestMethod]
        public void CreateOrdersTest(){

            List<string> errors = new List<string>();

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

            Orders temp = null;

            temp = DALOrders.ReadOrder(id, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(order.subtotal, temp.subtotal);
            Assert.AreEqual(order.customer_id, temp.customer_id);
            Assert.AreEqual(order.grand_total, temp.grand_total);
            Assert.AreEqual(order.tax_total, temp.tax_total);
            Assert.AreEqual(order.condition, temp.condition);

        }
        [TestMethod]
        public void ReadOrdersTest()
        {

            List<string> errors = new List<string>();

            Orders temp = null;

            temp = DALOrders.ReadOrder(1, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(1, temp.order_id);
            Assert.AreEqual(545, temp.customer_id);
            Assert.AreEqual(2260.81F, temp.subtotal);
            Assert.AreEqual(2260.81F, temp.grand_total);
            Assert.AreEqual(0, temp.tax_total);
            Assert.AreEqual('a', temp.condition);

        }
        [TestMethod]
        public void UpdateOrdersTest()
        {

            List<string> errors = new List<string>();

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

            Orders temp = null;

            temp = DALOrders.ReadOrder(id, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(order.subtotal, temp.subtotal);
            Assert.AreEqual(order.customer_id, temp.customer_id);
            Assert.AreEqual(order.grand_total, temp.grand_total);
            Assert.AreEqual(order.tax_total, temp.tax_total);
            Assert.AreEqual(order.condition, temp.condition);

            //update order
            order.order_id = id;
            order.condition = 's';
            int status = DALOrders.UpdateOrder(order, ref errors);

            temp = DALOrders.ReadOrder(id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(1, status);

            Assert.AreEqual(order.subtotal, temp.subtotal);
            Assert.AreEqual(order.customer_id, temp.customer_id);
            Assert.AreEqual(order.grand_total, temp.grand_total);
            Assert.AreEqual(order.tax_total, temp.tax_total);
            Assert.AreEqual(order.condition, temp.condition);

        }
        [TestMethod]
        public void DeleteOrdersTest()
        {

            List<string> errors = new List<string>();

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

            int status = DALOrders.DeleteOrder(id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(1, status);

        }   
    }
}
