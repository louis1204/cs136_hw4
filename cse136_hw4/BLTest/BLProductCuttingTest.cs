using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DomainModel;
using System.Collections.Generic;

namespace BLTest
{


    /// <summary>
    ///This is a test class for BLProductVariationTest and is intended
    ///to contain all BLProductVariationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BLProductCuttingTest
    {

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


        [TestMethod()]
        public void CreateProductCuttingTest()
        {
            Random rand = new Random();
            String createString = "Midget " + rand.Next(1000);

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProductCutting.CreateProductCutting(createString, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreNotEqual(result, -1);
            ProductCuttingInfo ProductCutting = BLProductCutting.ReadProductCutting(result, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(ProductCutting.product_cutting_id, result);
            Assert.AreEqual(ProductCutting.product_cutting_name, createString);
        }

        [TestMethod]
        public void ReadAllProductCuttingTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductCuttingInfo> ProductCuttingList1 = BLProductCutting.ReadAllProductCutting(ref errors);
            AsynchLog.LogNow(errors);
            List<ProductCuttingInfo> ProductCuttingList2 = BLProductCutting.ReadAllProductCutting(ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(ProductCuttingList1.Count, ProductCuttingList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < ProductCuttingList1.Count; i++)
            {
                Assert.AreEqual(ProductCuttingList1[i].product_cutting_id, ProductCuttingList2[i].product_cutting_id);
                Assert.AreEqual(ProductCuttingList1[i].product_cutting_name, ProductCuttingList2[i].product_cutting_name);
            }
        }

        [TestMethod()]
        public void UpdateProductCuttingTest()
        {
            Random rand = new Random();
            String updateString = "Tall " + rand.Next(1000);
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProductCutting.UpdateProductCutting(1, updateString, ref errors);
            AsynchLog.LogNow(errors);
            ProductCuttingInfo ProductCutting = BLProductCutting.ReadProductCutting(1, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, result);
            Assert.AreEqual(ProductCutting.product_cutting_id, 1);
            Assert.AreEqual(ProductCutting.product_cutting_name, updateString);
        }


        [TestMethod()]
        public void CreateProductCuttingNullErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProductCutting.CreateProductCutting(null, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod()]
        public void CreateProductCuttingErrorTest()
        {

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProductCutting.CreateProductCutting(null, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, errors.Count);

            errors = new List<string>(); // TODO: Initialize to an appropriate value
            Random rand = new Random();
            string iProductCuttingName = "Louis"+rand.Next(1000);

            BLProductCutting.CreateProductCutting(iProductCuttingName, ref errors);
            AsynchLog.LogNow(errors);
            BLProductCutting.CreateProductCutting(iProductCuttingName, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod()]
        public void ProductCuttingReadErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_ProductCutting_id = BLProductCutting.ReadAllProductCutting(ref errors).Count + 1;

            BLProductCutting.ReadProductCutting(invalid_ProductCutting_id, ref errors);
            AsynchLog.LogNow(errors);
            BLProductCutting.ReadProductCutting(-1, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual(2, errors.Count);
        }

        [TestMethod()]
        public void ProductCuttingUpdateErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_ProductCutting_id = BLProductCutting.ReadAllProductCutting(ref errors).Count + 1;

            BLProductCutting.UpdateProductCutting(-1, "Louis", ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
            BLProductCutting.UpdateProductCutting(invalid_ProductCutting_id, "Louis", ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);
        }
    }
}