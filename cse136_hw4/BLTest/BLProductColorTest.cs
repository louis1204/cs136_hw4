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
    public class BLProductColorTest
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
        public void CreateProductColorTest()
        {
            Random rand = new Random();
            String createString = "Sanrio Pink " + rand.Next(1000);

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProductColor.CreateProductColor(createString, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreNotEqual(result, -1);
            System.Diagnostics.Debug.WriteLine("RESULT:" + result);
            ProductColorInfo ProductColor = BLProductColor.ReadProductColor(result, ref errors);
            AsynchLog.LogNow(errors);

            System.Diagnostics.Debug.WriteLine("RESULT:" + ProductColor.product_color_id);
            System.Diagnostics.Debug.WriteLine("RESULT:" + ProductColor.product_color_name);

            Assert.AreEqual(ProductColor.product_color_id, result);
            Assert.AreEqual(ProductColor.product_color_name, createString);
        }

        [TestMethod]
        public void ReadAllProductColorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductColorInfo> ProductColorList1 = BLProductColor.ReadAllProductColor(ref errors);
            AsynchLog.LogNow(errors);
            List<ProductColorInfo> ProductColorList2 = BLProductColor.ReadAllProductColor(ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(ProductColorList1.Count, ProductColorList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < ProductColorList1.Count; i++)
            {
                Assert.AreEqual(ProductColorList1[i].product_color_id, ProductColorList2[i].product_color_id);
                Assert.AreEqual(ProductColorList1[i].product_color_name, ProductColorList2[i].product_color_name);
            }
        }

        [TestMethod()]
        public void UpdateProductColorTest()
        {
            Random rand = new Random();
            String updateString = "Hello Kitty Pink " + rand.Next(1000);
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProductColor.UpdateProductColor(1, updateString, ref errors);
            AsynchLog.LogNow(errors);
            ProductColorInfo ProductColor = BLProductColor.ReadProductColor(1, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, result);
            Assert.AreEqual(ProductColor.product_color_id, 1);
            Assert.AreEqual(ProductColor.product_color_name, updateString);
        }


        [TestMethod()]
        public void CreateProductColorNullErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProductColor.CreateProductColor(null, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod()]
        public void CreateProductColorErrorTest()
        {

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProductColor.CreateProductColor(null, ref errors);

            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            errors = new List<string>(); // TODO: Initialize to an appropriate value

            Random rand = new Random();
            string iProductColorName = "Louis" + rand.Next(1000);

            BLProductColor.CreateProductColor(iProductColorName, ref errors);
            AsynchLog.LogNow(errors);
            BLProductColor.CreateProductColor(iProductColorName, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod()]
        public void ProductColorReadErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_ProductColor_id = BLProductColor.ReadAllProductColor(ref errors).Count + 1;

            BLProductColor.ReadProductColor(invalid_ProductColor_id, ref errors);
            AsynchLog.LogNow(errors);
            BLProductColor.ReadProductColor(-1, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual(2, errors.Count);
        }

        [TestMethod()]
        public void ProductColorUpdateErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_ProductColor_id = BLProductColor.ReadAllProductColor(ref errors).Count + 1;

            BLProductColor.UpdateProductColor(-1, "Louis", ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
            BLProductColor.UpdateProductColor(invalid_ProductColor_id, "Louis", ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);
        }
    }
}