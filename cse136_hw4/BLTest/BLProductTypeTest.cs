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
    public class BLProductTypeTest
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
        public void CreateProductTypeTest()
        {
            Random rand = new Random();
            String createString = "Super deep v turtle neck " + rand.Next(1000);

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProductType.CreateProductType(createString, ref errors);
            Assert.AreNotEqual(result, -1);
            AsynchLog.LogNow(errors);

            ProductTypeInfo ProductType = BLProductType.ReadProductType(result, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(ProductType.product_type_id, result);
            Assert.AreEqual(ProductType.product_type_name, createString);
        }

        [TestMethod]
        public void ReadAllProductTypeTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductTypeInfo> ProductTypeList1 = BLProductType.ReadAllProductType(ref errors);
            AsynchLog.LogNow(errors);
            List<ProductTypeInfo> ProductTypeList2 = BLProductType.ReadAllProductType(ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(ProductTypeList1.Count, ProductTypeList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < ProductTypeList1.Count; i++)
            {
                Assert.AreEqual(ProductTypeList1[i].product_type_id, ProductTypeList2[i].product_type_id);
                Assert.AreEqual(ProductTypeList1[i].product_type_name, ProductTypeList2[i].product_type_name);
            }
        }

        [TestMethod()]
        public void UpdateProductTypeTest()
        {
            Random rand = new Random();
            String updateString = "Lingerie " + rand.Next(1000);
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProductType.UpdateProductType(1, updateString, ref errors);
            AsynchLog.LogNow(errors);
            ProductTypeInfo ProductType = BLProductType.ReadProductType(1, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, result);
            Assert.AreEqual(ProductType.product_type_id, 1);
            Assert.AreEqual(ProductType.product_type_name, updateString);
        }


        [TestMethod()]
        public void CreateProductTypeNullErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProductType.CreateProductType(null, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, errors.Count);
        }
        [TestMethod()]
        public void CreateProductTypeErrorTest()
        {

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProductType.CreateProductType(null, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, errors.Count);

            errors = new List<string>(); // TODO: Initialize to an appropriate value
            Random rand = new Random();
            string iProductTypeName = "Louis"+ rand.Next(1000);

            BLProductType.CreateProductType(iProductTypeName, ref errors);
            AsynchLog.LogNow(errors);
            BLProductType.CreateProductType(iProductTypeName, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod()]
        public void ProductTypeReadErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_ProductType_id = BLProductType.ReadAllProductType(ref errors).Count + 1;

            BLProductType.ReadProductType(invalid_ProductType_id, ref errors);
            AsynchLog.LogNow(errors);
            BLProductType.ReadProductType(-1, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual(2, errors.Count);
        }

        [TestMethod()]
        public void ProductTypeUpdateErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_ProductType_id = BLProductType.ReadAllProductType(ref errors).Count + 1;

            BLProductType.UpdateProductType(-1, "Louis", ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
            BLProductType.UpdateProductType(invalid_ProductType_id, "Louis", ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);
        }
    }
}
