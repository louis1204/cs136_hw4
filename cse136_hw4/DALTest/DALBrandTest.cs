using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DomainModel;

namespace DALTest
{


    /// <summary>
    ///This is a test class for DALProductTest and is intended
    ///to contain all DALProductTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DALBrandTest
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
        ///A test for CreateBrand
        ///</summary>
        [TestMethod()]
        public void CreateBrandTest()
        {
            Random rand = new Random();
            string Brand_name = "Hello Kitty" + rand.Next(10000); // TODO: Initialize to an appropriate value
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            int actual;
            actual = DALBrand.CreateBrand(Brand_name, ref errors);
            BrandInfo pi = DALBrand.ReadBrandDetail(actual, ref errors);
            Assert.AreEqual(pi.brand_name, Brand_name);
            Assert.AreEqual(pi.brand_id, actual);
        }

        /// <summary>
        ///A test for UpdateBrand
        ///</summary>
        [TestMethod()]
        public void UpdateProductBrandTest()
        {
            int myId = 1;
            Random rand = new Random();
            BrandInfo Brand = new BrandInfo(myId, "Sanrio " + rand.Next(10000));
            List<string> errors = new List<string>();
            int result = DALBrand.UpdateBrand(Brand.brand_id, Brand.brand_name, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, result);

            BrandInfo verifyBrand = DALBrand.ReadBrandDetail(myId, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(Brand.brand_id, verifyBrand.brand_id);
            Assert.AreEqual(Brand.brand_name, verifyBrand.brand_name);
        }

        /// <summary>
        ///A test for ReadAllBrand
        ///</summary>
        [TestMethod]
        public void ReadAllBrandTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<BrandInfo> BrandList1 = DALBrand.ReadBrandList(ref errors);
            List<BrandInfo> BrandList2 = DALBrand.ReadBrandList(ref errors);

            Assert.AreEqual(BrandList1.Count, BrandList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < BrandList1.Count; i++)
            {
                Assert.AreEqual(BrandList1[i].brand_id, BrandList2[i].brand_id);
                Assert.AreEqual(BrandList1[i].brand_name, BrandList2[i].brand_name);
            }
        }
    }
}
