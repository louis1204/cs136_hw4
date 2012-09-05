using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DomainModel;

namespace DALTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DALCustomerTest
    {
        public DALCustomerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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

        /// <summary>
        ///A test for InsertCustomer
        ///</summary>
        [TestMethod]
        public void CreateCustomerTest()
        {
            Customer customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, "None", 1);

            List<string> errors = new List<string>();
            int result = DALCustomer.CreateCustomer(customer, ref errors);

            Assert.AreNotEqual(-1, result);

            Customer verifyCustomer = DALCustomer.ReadCustomer(result, ref errors);
            Assert.AreEqual(0, errors.Count());

            Assert.AreEqual(result, verifyCustomer.customer_id);
            Assert.AreEqual(customer.first_name, verifyCustomer.first_name);
            Assert.AreEqual(customer.last_name, verifyCustomer.last_name);
            Assert.AreEqual(customer.address1, verifyCustomer.address1);
            Assert.AreEqual(customer.city, verifyCustomer.city);
            Assert.AreEqual(customer.state, verifyCustomer.state);
            Assert.AreEqual(customer.zip, verifyCustomer.zip);
            Assert.AreEqual(customer.age, verifyCustomer.age);
            Assert.AreEqual(customer.gender, verifyCustomer.gender);
            Assert.AreEqual(customer.hobby, verifyCustomer.hobby);
            Assert.AreEqual(customer.income, verifyCustomer.income);
            Assert.AreEqual(customer.children, verifyCustomer.children);
            Assert.AreEqual(customer.degree, verifyCustomer.degree);
            Assert.AreEqual(customer.ownHouse, verifyCustomer.ownHouse);

        }
        /// <summary>
        ///A test for UpdateCustomer
        ///</summary>
        [TestMethod]
        public void UpdateCustomerTest()
        {
            int myId = 1;
            Customer customer = new Customer(myId, "first", "last", "address1", "city1", "CA", 92037, 20,
                                 'M', "None", 80000, 2, "None", 1);

            List<string> errors = new List<string>();
            int result = DALCustomer.UpdateCustomer(customer, ref errors);

            Assert.AreNotEqual(-1, result);

            Customer verifyCustomer = DALCustomer.ReadCustomer(myId, ref errors);
            Assert.AreEqual(0, errors.Count());

            Assert.AreEqual(customer.customer_id, verifyCustomer.customer_id);
            Assert.AreEqual(customer.first_name, verifyCustomer.first_name);
            Assert.AreEqual(customer.last_name, verifyCustomer.last_name);
            Assert.AreEqual(customer.address1, verifyCustomer.address1);
            Assert.AreEqual(customer.city, verifyCustomer.city);
            Assert.AreEqual(customer.state, verifyCustomer.state);
            Assert.AreEqual(customer.zip, verifyCustomer.zip);
            Assert.AreEqual(customer.age, verifyCustomer.age);
            Assert.AreEqual(customer.gender, verifyCustomer.gender);
            Assert.AreEqual(customer.hobby, verifyCustomer.hobby);
            Assert.AreEqual(customer.income, verifyCustomer.income);
            Assert.AreEqual(customer.children, verifyCustomer.children);
            Assert.AreEqual(customer.degree, verifyCustomer.degree);
            Assert.AreEqual(customer.ownHouse, verifyCustomer.ownHouse);
        }
        /// <summary>
        ///A test for ReadCustomerList
        ///</summary>
        [TestMethod]
        public void ReadCustomerListTest()
        {
            List<string> errors = new List<string>();
            List<Customer> ul1 = DALCustomer.ReadCustomers(ref errors);
            List<Customer> ul2 = DALCustomer.ReadCustomers(ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(ul1.Count, ul2.Count);

            for (int i = 0; i < ul1.Count; i++)
            {
                Assert.AreEqual(ul1[i].customer_id, ul2[i].customer_id);
                Assert.AreEqual(ul1[i].first_name, ul2[i].first_name);
                Assert.AreEqual(ul1[i].last_name, ul2[i].last_name);
                Assert.AreEqual(ul1[i].address1, ul2[i].address1);
                Assert.AreEqual(ul1[i].city, ul2[i].city);
                Assert.AreEqual(ul1[i].state, ul2[i].state);
                Assert.AreEqual(ul1[i].zip, ul2[i].zip);
                Assert.AreEqual(ul1[i].age, ul2[i].age);
                Assert.AreEqual(ul1[i].gender, ul2[i].gender);
                Assert.AreEqual(ul1[i].hobby, ul2[i].hobby);
                Assert.AreEqual(ul1[i].income, ul2[i].income);
                Assert.AreEqual(ul1[i].children, ul2[i].children);
                Assert.AreEqual(ul1[i].degree, ul2[i].degree);
                Assert.AreEqual(ul1[i].ownHouse, ul2[i].ownHouse);
            }

        }
    }
}
