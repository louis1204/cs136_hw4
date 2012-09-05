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
    public class DALProductTest
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
        ///A test for CreateProduct
        ///</summary>
        [TestMethod()]
        public void CreateProductTest()
        {
            Random rand = new Random();
            string product_name = "Hello Kitty" + rand.Next(10000); // TODO: Initialize to an appropriate value
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            
            int actual;
            actual = DALProduct.CreateProduct(product_name, ref errors);
            ProductInfo pi = DALProduct.ReadProductDetail(actual, ref errors);
            Assert.AreEqual(pi.product_name, product_name);
            Assert.AreEqual(pi.product_id, actual);
        }

        /// <summary>
        ///A test for UpdateProduct
        ///</summary>
        [TestMethod()]
        public void UpdateProductTest()
        {
            int myId = 1;
            Random rand = new Random();
            ProductInfo pi = new ProductInfo(myId, "turtle neck " + rand.Next(10000));
            List<string> errors = new List<string>();
            int result = DALProduct.UpdateProduct(pi.product_id, pi.product_name, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, result);

            ProductInfo verify = DALProduct.ReadProductDetail(myId, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(pi.product_id, verify.product_id);
            Assert.AreEqual(pi.product_name, verify.product_name);
        }

        /// <summary>
        ///A test for ReaddAllProduct
        ///</summary>
        [TestMethod]
        public void ReadAllProductTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductInfo> ProductList1 = DALProduct.ReadProductList(ref errors);
            List<ProductInfo> ProductList2 = DALProduct.ReadProductList(ref errors);

            Assert.AreEqual(ProductList1.Count, ProductList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < ProductList1.Count; i++)
            {
                Assert.AreEqual(ProductList1[i].product_id, ProductList2[i].product_id);
                Assert.AreEqual(ProductList1[i].product_name, ProductList2[i].product_name);
            }
        }
    }
}
