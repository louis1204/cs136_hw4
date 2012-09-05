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
    public class DALProductColorTest
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
        ///A test for CreateProductColor
        ///</summary>
        [TestMethod()]
        public void CreateProductColorTest()
        {
            Random rand = new Random();
            string ProductColor_name = "Diarrhea Green " + rand.Next(10000); // TODO: Initialize to an appropriate value
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            int actual;
            actual = DALProductColor.CreateProductColor(ProductColor_name, ref errors);
            ProductColorInfo pi = DALProductColor.ReadProductColorDetail(actual, ref errors);
            Assert.AreEqual(pi.product_color_name, ProductColor_name);
            Assert.AreEqual(pi.product_color_id, actual);
        }

        /// <summary>
        ///A test for UpdateProductColor
        ///</summary>
        [TestMethod()]
        public void UpdateProductColorTest()
        {
            int myId = 1;
            Random rand = new Random();
            ProductColorInfo Color = new ProductColorInfo(myId, "Sanrio Pink " + rand.Next(10000));
            List<string> errors = new List<string>();
            int result = DALProductColor.UpdateProductColor(Color.product_color_id, Color.product_color_name, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, result);

            ProductColorInfo verifyColor = DALProductColor.ReadProductColorDetail(myId, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(Color.product_color_id, verifyColor.product_color_id);
            Assert.AreEqual(Color.product_color_name, verifyColor.product_color_name);
        }

        /// <summary>
        ///A test for ReadAllProductColor
        ///</summary>
        [TestMethod]
        public void ReadAllProductColorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductColorInfo> ProductColorList1 = DALProductColor.ReadProductColorList(ref errors);
            List<ProductColorInfo> ProductColorList2 = DALProductColor.ReadProductColorList(ref errors);

            Assert.AreEqual(ProductColorList1.Count, ProductColorList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < ProductColorList1.Count; i++)
            {
                Assert.AreEqual(ProductColorList1[i].product_color_id, ProductColorList2[i].product_color_id);
                Assert.AreEqual(ProductColorList1[i].product_color_name, ProductColorList2[i].product_color_name);
            }
        }
    }
}
