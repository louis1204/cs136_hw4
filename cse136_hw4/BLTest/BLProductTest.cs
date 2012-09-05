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
    public class BLProductTest
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
        public void CreateProductTest()
        {
            Random rand = new Random();
            String createString = "Hello Kitty " + rand.Next(1000);

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProduct.CreateProduct(createString, ref errors);
            Assert.AreNotEqual(result, -1);
            AsynchLog.LogNow(errors);

            ProductInfo Product = BLProduct.ReadProduct(result, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(Product.product_id, result);
            Assert.AreEqual(Product.product_name, createString);
        }

        [TestMethod]
        public void ReadAllProductTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductInfo> ProductList1 = BLProduct.ReadAllProduct(ref errors);
            AsynchLog.LogNow(errors);
            List<ProductInfo> ProductList2 = BLProduct.ReadAllProduct(ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(ProductList1.Count, ProductList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < ProductList1.Count; i++)
            {
                Assert.AreEqual(ProductList1[i].product_id, ProductList2[i].product_id);
                Assert.AreEqual(ProductList1[i].product_name, ProductList2[i].product_name);
            }
        }

        [TestMethod()]
        public void UpdateProductTest()
        {
            Random rand = new Random();
            String updateString = "Hello Kitty" + rand.Next(1000);
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProduct.UpdateProduct(1, updateString, ref errors);
            AsynchLog.LogNow(errors);
            ProductInfo Product = BLProduct.ReadProduct(1, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, result);
            Assert.AreEqual(Product.product_id, 1);
            Assert.AreEqual(Product.product_name, updateString);
        }


        [TestMethod()]
        public void CreateProductNullErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProduct.CreateProduct(null, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod()]
        public void CreateProductErrorTest()
        {

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProduct.CreateProduct(null, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, errors.Count);

            errors = new List<string>(); // TODO: Initialize to an appropriate value
            Random rand = new Random();
            string iProductName = "Louis" + rand.Next(1000);

            BLProduct.CreateProduct(iProductName, ref errors);
            AsynchLog.LogNow(errors);
            BLProduct.CreateProduct(iProductName, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod()]
        public void ProductReadErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_Product_id = BLProduct.ReadAllProduct(ref errors).Count + 1;

            BLProduct.ReadProduct(invalid_Product_id, ref errors);
            AsynchLog.LogNow(errors);
            BLProduct.ReadProduct(-1, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual(2, errors.Count);
        }

        [TestMethod()]
        public void ProductUpdateErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_Product_id = BLProduct.ReadAllProduct(ref errors).Count + 1;

            BLProduct.UpdateProduct(-1, "Louis", ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
            BLProduct.UpdateProduct(invalid_Product_id, "Louis", ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);
        }
    }
}
