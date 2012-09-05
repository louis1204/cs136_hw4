using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DomainModel;

namespace DALTest
{


    /// <summary>
    ///This is a test class for DALProductCuttingTest and is intended
    ///to contain all DALProductCuttingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DALProductCuttingTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CreateProductCutting
        ///</summary>
        [TestMethod()]
        public void CreateProductCuttingTest()
        {
            Random rand = new Random();
            string product_cutting_name = "super deep v sweater " + rand.Next(10000);
            List<string> errors = new List<string>();
            int result = DALProductCutting.CreateProductCutting(product_cutting_name, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, result);

            ProductCuttingInfo verifyCutting = DALProductCutting.ReadProductCuttingDetail(result, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(result, verifyCutting.product_cutting_id);
            Assert.AreEqual(product_cutting_name, verifyCutting.product_cutting_name);
        }

        /// <summary>
        ///A test for UpdateProductCutting
        ///</summary>
        [TestMethod()]
        public void UpdateProductCuttingTest()
        {
            int myId = 1;
            Random rand = new Random();
            ProductCuttingInfo cutting= new ProductCuttingInfo(myId,"turtle neck " + rand.Next(10000));
            List<string> errors = new List<string>();
            int result = DALProductCutting.UpdateProductCutting(cutting.product_cutting_id, cutting.product_cutting_name, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, result);

            ProductCuttingInfo verifyCutting = DALProductCutting.ReadProductCuttingDetail(myId, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(cutting.product_cutting_id, verifyCutting.product_cutting_id);
            Assert.AreEqual(cutting.product_cutting_name, verifyCutting.product_cutting_name);
        }

        /// <summary>
        ///A test for ReaddAllUpdateProductCutting
        ///</summary>
        [TestMethod]
        public void ReadAllProductCuttingTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductCuttingInfo> ProductCuttingList1 = DALProductCutting.ReadProductCuttingList(ref errors);
            List<ProductCuttingInfo> ProductCuttingList2 = DALProductCutting.ReadProductCuttingList(ref errors);

            Assert.AreEqual(ProductCuttingList1.Count, ProductCuttingList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < ProductCuttingList1.Count; i++)
            {
                Assert.AreEqual(ProductCuttingList1[i].product_cutting_id, ProductCuttingList2[i].product_cutting_id);
                Assert.AreEqual(ProductCuttingList1[i].product_cutting_name, ProductCuttingList2[i].product_cutting_name);
            }
        }
    }
}