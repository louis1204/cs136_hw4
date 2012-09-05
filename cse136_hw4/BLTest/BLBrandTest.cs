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
    public class BLBrandTest
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
        public void CreateBrandTest()
        {
            Random rand = new Random();
            String createString = "Sanrio " + rand.Next(1000);
    
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLBrand.CreateBrand(createString, ref errors);
            Assert.AreNotEqual(result, -1);

            BrandInfo Brand = BLBrand.ReadBrand(result, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(Brand.brand_id, result);
            Assert.AreEqual(Brand.brand_name, createString);
        }

        [TestMethod]
        public void ReadAllBrandTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<BrandInfo> BrandList1 = BLBrand.ReadAllBrand(ref errors);
            List<BrandInfo> BrandList2 = BLBrand.ReadAllBrand(ref errors);


            Assert.AreEqual(BrandList1.Count, BrandList2.Count);
            Assert.AreEqual(errors.Count, 0);
            AsynchLog.LogNow(errors);
            for (int i = 0; i < BrandList1.Count; i++)
            {
                Assert.AreEqual(BrandList1[i].brand_id, BrandList2[i].brand_id);
                Assert.AreEqual(BrandList1[i].brand_name, BrandList2[i].brand_name);
            }
        }

        [TestMethod()]
        public void UpdateBrandTest()
        {
            Random rand = new Random();
            String updateString = "Hello Kitty" + rand.Next(1000);
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLBrand.UpdateBrand(1, updateString, ref errors);
            BrandInfo Brand = BLBrand.ReadBrand(1, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, result);
            Assert.AreEqual(Brand.brand_id, 1);
            Assert.AreEqual(Brand.brand_name, updateString);
        }


        [TestMethod()]
        public void CreateBrandNullErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLBrand.CreateBrand(null, ref errors);

            Assert.AreEqual(1, errors.Count);
        }


        [TestMethod()]
        public void CreateBrandErrorTest()
        {

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLBrand.CreateBrand(null, ref errors);

            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            errors = new List<string>(); // TODO: Initialize to an appropriate value
            Random rand = new Random();
            string iBrandName = "Louis" + rand.Next(1000);

            BLBrand.CreateBrand(iBrandName, ref errors);
            BLBrand.CreateBrand(iBrandName, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod()]
        public void BrandReadErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_Brand_id = BLBrand.ReadAllBrand(ref errors).Count + 1;

            BLBrand.ReadBrand(invalid_Brand_id, ref errors);
            BLBrand.ReadBrand(-1, ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod()]
        public void BrandUpdateErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_Brand_id = BLBrand.ReadAllBrand(ref errors).Count + 1;

            BLBrand.UpdateBrand(-1, "Louis", ref errors);
            Assert.AreEqual(1, errors.Count);
            BLBrand.UpdateBrand(invalid_Brand_id, "Louis", ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);
        }
    }
}
