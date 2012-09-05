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
    public class BLOrdersTest
    {

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateOrderTest()
        {
            int order_id = -1;
            int customer_id = -1;
            float subtotal = -1F;
            float tax_total = -1F;
            float grand_total = -1F;
            char condition = 'z';



            Orders order = null;

            List<string> errors = new List<string>();

            BLOrders.CreateOrder(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            AsynchLog.LogNow(errors);

            //order_id = -1
            errors = new List<string>(); 

            order = new Orders();
            order.order_id = order_id;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = 'a';
            
            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //customer_id = -1
            order.order_id = 1;
            order.customer_id = customer_id;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = 'a';

            errors = new List<string>(); 

            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //subtotal = -1
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = subtotal;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);

            //grand_total = -1
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = grand_total;
            order.tax_total = 0;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);

            //tax_total = -1
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = tax_total;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);

            //grand_total calculation
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 1F;
            order.grand_total = 0;
            order.tax_total = 1F;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //condition = k
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = condition;

            errors = new List<string>(); 
            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //all 8 errors
            order.order_id = order_id;
            order.customer_id = customer_id;
            order.subtotal = subtotal;
            order.grand_total = grand_total;
            order.tax_total = tax_total;
            order.condition = condition;

            errors = new List<string>(); 
            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(7, errors.Count);
            AsynchLog.LogNow(errors);

            //no errors
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.CreateOrder(order, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void ReadOrderTest()
        {
            int id = 0;
            List<string> errors = new List<string>();

            //id = 0
            Orders x = BLOrders.ReadOrder(id, ref errors);
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(null, x);

            //no errors
            errors = new List<string>(); 

            Orders y = BLOrders.ReadOrder(1, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(null, y);
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            int order_id = -1;
            int customer_id = -1;
            float subtotal = -1F;
            float tax_total = -1F;
            float grand_total = -1F;
            char condition = 'z';

            Orders order;

            List<string> errors = new List<string>();

            BLOrders.UpdateOrder(null, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //order_id = -1
            errors = new List<string>(); 

            order = new Orders();
            order.order_id = order_id;
            order.customer_id = 0;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = 'a';

            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //customer_id = -1
            order.order_id = 1;
            order.customer_id = customer_id;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = 'a';

            errors = new List<string>(); 

            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //subtotal = -1
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = subtotal;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);

            //grand_total = -1
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = grand_total;
            order.tax_total = 0;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);

            //tax_total = -1
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = tax_total;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);

            //grand_total calculation
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 1F;
            order.grand_total = 0;
            order.tax_total = 1F;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //condition = k
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = condition;

            errors = new List<string>(); 
            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //all 7 errors
            order.order_id = order_id;
            order.customer_id = customer_id;
            order.subtotal = subtotal;
            order.grand_total = grand_total;
            order.tax_total = tax_total;
            order.condition = condition;

            errors = new List<string>(); 
            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(7, errors.Count);
            AsynchLog.LogNow(errors);

            //no errors
            order.order_id = 1;
            order.customer_id = 1;
            order.subtotal = 0;
            order.grand_total = 0;
            order.tax_total = 0;
            order.condition = 'a';

            errors = new List<string>(); 
            BLOrders.UpdateOrder(order, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void DeleteOrderTest()
        {
            int id = 0;
            List<string> errors = new List<string>();

            //id = 0
            int x = BLOrders.DeleteOrder(id, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

        }
    }
}
