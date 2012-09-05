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
    /// <summary>
    /// Summary description for BLCustomerTest
    /// </summary>
    [TestClass]
    public class BLCustomerTest
    {
        public BLCustomerTest()
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

        [TestMethod]
        public void CreateCustomerTest()
        {
            int customer_id = 0;
            int age = 0;
            int zip = 0;
            char gender = 'T';
            int income = -1;
            int children = -1;
            string degree = "Elementary School Diploma";
            int ownHouse = -1;
            Customer customer;

            List<string> errors = new List<string>();
            
            BLCustomer.CreateCustomer(null, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
            
            //customer_id = 0
            errors = new List<string>();
            customer = new Customer(customer_id, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, "None", 1);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //age = 0
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, age,
                                             'M', "None", 80000, 2, "None", 1);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //zip = 0
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", zip, 20,
                                             'M', "None", 80000, 2, "None", 1);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //gender = T
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             gender, "None", 80000, 2, "None", 1);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
            
            //income = -1
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", income, 2, "None", 1);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
            
            //children = -1
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, children, "None", 1);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //degree = Elementary School Diploma
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, degree, 1);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //ownHouse = -1
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, "None", ownHouse);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
            //ownHouse = -1
            
            //all 8 errors
            errors = new List<string>();
            customer = new Customer(customer_id, "first", "last", "address1", "city1", "CA", zip, age,
                                             gender, "None", income, children, degree, ownHouse);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(8, errors.Count);
            AsynchLog.LogNow(errors);

            //no errors
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, "None", 1);
            BLCustomer.CreateCustomer(customer, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void ReadCustomerListTest()
        {
            int id = 0;
            List<string> errors = new List<string>();

            //id = 0
            BLCustomer.ReadCustomer(id, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //no errors
            errors = new List<string>();

            BLCustomer.ReadCustomer(1, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            int customer_id = 0;
            int age = 0;
            int zip = 0;
            char gender = 'T';
            int income = -1;
            int children = -1;
            string degree = "Elementary School Diploma";
            int ownHouse = -1;
            Customer customer;

            List<string> errors = new List<string>();

            BLCustomer.UpdateCustomer(null, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //customer_id = 0
            errors = new List<string>();
            customer = new Customer(customer_id, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, "None", 1);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //age = 0
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, age,
                                             'M', "None", 80000, 2, "None", 1);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //zip = 0
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", zip, 20,
                                             'M', "None", 80000, 2, "None", 1);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //gender = T
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             gender, "None", 80000, 2, "None", 1);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //income = -1
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", income, 2, "None", 1);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //children = -1
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, children, "None", 1);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //degree = Elementary School Diploma
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, degree, 1);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //ownHouse = -1
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, "None", ownHouse);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //all 8 errors
            errors = new List<string>();
            customer = new Customer(customer_id, "first", "last", "address1", "city1", "CA", zip, age,
                                             gender, "None", income, children, degree, ownHouse);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(8, errors.Count);
            AsynchLog.LogNow(errors);

            //no errors
            errors = new List<string>();
            customer = new Customer(1, "first", "last", "address1", "city1", "CA", 92037, 20,
                                             'M', "None", 80000, 2, "None", 1);
            BLCustomer.UpdateCustomer(customer, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }
    }
}
