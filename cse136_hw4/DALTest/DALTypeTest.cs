using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DomainModel;

namespace DALTest
{


    /// <summary>
    ///This is a test class for DALTypeTest and is intended
    ///to contain all DALTypeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DALTypeTest
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
        ///A test for CreateProductType
        ///</summary>
        [TestMethod()]
        public void CreateProductTypeTest()
        {
            Random rand = new Random();
            string product_type_name = "extremely hot sweater " + rand.Next(10000);
            List<string> errors = new List<string>();
            int result = DALType.CreateProductType(product_type_name, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, result);

            ProductTypeInfo verifyType = DALType.ReadProductTypeDetail(result, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(result, verifyType.product_type_id);
            Assert.AreEqual(product_type_name, verifyType.product_type_name);
        }

        /// <summary>
        ///A test for UpdateProductType
        ///</summary>
        [TestMethod()]
        public void UpdateProductTypeTest()
        {
            int myId = 1;
            Random rand = new Random();
            ProductTypeInfo type = new ProductTypeInfo(myId, "extremely hot sweater " + rand.Next(10000));
            List<string> errors = new List<string>();
            int result = DALType.UpdateProductType(type.product_type_id, type.product_type_name, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreNotEqual(-1, result);

            ProductTypeInfo verifyType = DALType.ReadProductTypeDetail(myId, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(type.product_type_id, verifyType.product_type_id);
            Assert.AreEqual(type.product_type_name, verifyType.product_type_name);
        }

        /// <summary>
        ///A test for ReaddAllProductType
        ///</summary>
        [TestMethod]
        public void ReadAllProductTypeTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductTypeInfo> ProductTypeList1 = DALType.ReadProductTypeList(ref errors);
            List<ProductTypeInfo> ProductTypeList2 = DALType.ReadProductTypeList(ref errors);

            Assert.AreEqual(ProductTypeList1.Count, ProductTypeList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < ProductTypeList1.Count; i++)
            {
                Assert.AreEqual(ProductTypeList1[i].product_type_id, ProductTypeList2[i].product_type_id);
                Assert.AreEqual(ProductTypeList1[i].product_type_name, ProductTypeList2[i].product_type_name);
            }
        }
    }
}
