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
    public class BLProductVariationTest
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
        [TestMethod()]
        public void CreatePVTest()
        {
            char gender = 'M';
            char condition = 'a';

            ProductVariationInfo ProductVariationInfo = new ProductVariationInfo(1, 1, 1, 1, 1, 1, gender, "L", 1, (float)1.0, condition);// TODO: Initialize to an appropriate value
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProductVariation.CreatePV(ProductVariationInfo, ref errors);
            Assert.AreNotEqual(result, -1);
            AsynchLog.LogNow(errors);

            ProductVariationInfo pv = BLProductVariation.ReadPV(result, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(pv.product_id, ProductVariationInfo.product_id);
            Assert.AreEqual(pv.product_brand_id, ProductVariationInfo.product_brand_id);
            Assert.AreEqual(pv.product_cutting_id, ProductVariationInfo.product_cutting_id);
            Assert.AreEqual(pv.product_color_id, ProductVariationInfo.product_color_id);
            Assert.AreEqual(pv.product_type_id, ProductVariationInfo.product_type_id);
            Assert.AreEqual(pv.sex, ProductVariationInfo.sex);
            Assert.AreEqual(pv.size, ProductVariationInfo.size);
            Assert.AreEqual(pv.stock, ProductVariationInfo.stock);
            Assert.AreEqual(pv.price, ProductVariationInfo.price);
            Assert.AreEqual(pv.condition, ProductVariationInfo.condition);
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void ReadAllPVTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            List<ProductVariationInfo> pvList1 = BLProductVariation.ReadAllPV(ref errors);
            AsynchLog.LogNow(errors);
            List<ProductVariationInfo> pvList2 = BLProductVariation.ReadAllPV(ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(pvList1.Count, pvList2.Count);
            Assert.AreEqual(errors.Count, 0);
            for (int i = 0; i < pvList1.Count; i++)
            {
                Assert.AreEqual(pvList1[i].product_variation_id, pvList2[i].product_variation_id);
                Assert.AreEqual(pvList1[i].product_id, pvList2[i].product_id);
                Assert.AreEqual(pvList1[i].product_brand_id, pvList2[i].product_brand_id);
                Assert.AreEqual(pvList1[i].product_cutting_id, pvList2[i].product_cutting_id);
                Assert.AreEqual(pvList1[i].product_color_id, pvList2[i].product_color_id);
                Assert.AreEqual(pvList1[i].product_type_id, pvList2[i].product_type_id);
                Assert.AreEqual(pvList1[i].sex, pvList2[i].sex);
                Assert.AreEqual(pvList1[i].size, pvList2[i].size);
                Assert.AreEqual(pvList1[i].stock, pvList2[i].stock);
                Assert.AreEqual(pvList1[i].price, pvList2[i].price);
                Assert.AreEqual(pvList1[i].condition, pvList2[i].condition);
            }
        }

        [TestMethod()]
        public void UpdateProductVariationInfoTest()
        {
            char gender = 'M';
            char condition = 'a';

            ProductVariationInfo ProductVariationInfo = new ProductVariationInfo(1, 2, 2, 2, 2, 2, gender, "L", 2, (float)1.0, condition); // TODO: Initialize to an appropriate value
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            int result = BLProductVariation.UpdatePV(ProductVariationInfo, ref errors);
            AsynchLog.LogNow(errors);
            ProductVariationInfo pv = BLProductVariation.ReadPV(result, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, result);
            Assert.AreEqual(pv.product_variation_id, 1);
            Assert.AreEqual(pv.product_id, 2);
            Assert.AreEqual(pv.product_brand_id, 2);
            Assert.AreEqual(pv.product_cutting_id, 2);
            Assert.AreEqual(pv.product_color_id, 2);
            Assert.AreEqual(pv.product_type_id, 2);
            Assert.AreEqual(pv.sex, gender);
            Assert.AreEqual(pv.size, "L");
            Assert.AreEqual(pv.stock, 2);
            Assert.AreEqual(pv.price, (float)1.0);
            Assert.AreEqual(pv.condition, condition);
        }

        /// <summary>
        ///A test for DeleteProductVariationInfo
        ///</summary>
        [TestMethod()]
        public void DeleteProductVariationInfoTest()
        {
            char gender = 'M';
            char condition = 'a';

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value
            ProductVariationInfo ProductVariationInfo = new ProductVariationInfo(1, 1, 1, 1, 1, 1, gender, "L", 1, (float)1.0, condition);// TODO: Initialize to an appropriate value
            int result = BLProductVariation.CreatePV(ProductVariationInfo, ref errors);
            AsynchLog.LogNow(errors);
            int t= BLProductVariation.DeletePV(result, ref errors);
            AsynchLog.LogNow(errors);

            ProductVariationInfo pv = BLProductVariation.ReadPV(result, ref errors);
            AsynchLog.LogNow(errors);
            Assert.AreEqual('d', pv.condition);
        }

        [TestMethod()]
        public void CreateProductVariationErrorTest()
        {

            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            List<string> errorsExpected = new List<string>(); // TODO: Initialize to an appropriate value

            BLProductVariation.CreatePV(null, ref errors);
            AsynchLog.LogNow(errors);

            Assert.AreEqual(1, errors.Count);

            errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_pv_id = BLProductVariation.ReadAllPV(ref errors).Count + 1;
            int invalid_product_id = BLProduct.ReadAllProduct(ref errors).Count + 1;
            int invalid_brand_id = BLBrand.ReadAllBrand(ref errors).Count + 1;
            int invalid_product_color_id = BLProductColor.ReadAllProductColor(ref errors).Count + 1;
            int invalid_product_cutting_id = BLProductCutting.ReadAllProductCutting(ref errors).Count + 1;
            char invalid_sex = 'Q';
            string invalid_size = "huge";
            int invalid_stock = -1;
            int invalid_price = -1;
            char invalid_condition = 'f';
            int invalid_product_type_id = BLProductType.ReadAllProductType(ref errors).Count + 1;

            ProductVariationInfo ipv = new ProductVariationInfo(invalid_pv_id, invalid_product_id, invalid_brand_id, invalid_product_cutting_id, invalid_product_color_id,
                invalid_product_type_id, invalid_sex, invalid_size, invalid_stock, invalid_price, invalid_condition);


            BLProductVariation.CreatePV(ipv, ref errors);
            Assert.AreEqual(8, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod()]
        public void ProductVariationUpdateErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            int invalid_pv_id = BLProductVariation.ReadAllPV(ref errors).Count + 1;

            char gender = 'M';
            char condition = 'a';

            ProductVariationInfo ProductVariationInfo1 = new ProductVariationInfo(invalid_pv_id, 2, 2, 2, 2, 2, gender, "L", 2, (float)1.0, condition); // TODO: Initialize to an appropriate value

            ProductVariationInfo ProductVariationInfo2 = new ProductVariationInfo(-1, 2, 2, 2, 2, 2, gender, "L", 2, (float)1.0, condition); // TODO: Initialize to an appropriate value

            BLProductVariation.UpdatePV(ProductVariationInfo1, ref errors);
            Assert.AreEqual(1, errors.Count);
            BLProductVariation.UpdatePV(ProductVariationInfo2, ref errors);
            Assert.AreEqual(2, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod()]
        public void ProductVariationDeleteErrorTest()
        {
            List<string> errors = new List<string>(); // TODO: Initialize to an appropriate value
            //int invalid_pv_id = BLProductVariation.ReadAllPV(ref errors).Count + 1;

            //create PV, should have no errors
            char gender = 'M';
            char condition = 'a';
            ProductVariationInfo ProductVariationInfo = new ProductVariationInfo(1, 1, 1, 1, 1, 1, gender, "L", 1, (float)1.0, condition);
            int id_created = BLProductVariation.CreatePV(ProductVariationInfo, ref errors);
            Assert.AreEqual(0, errors.Count);
            Console.WriteLine("id: "+id_created);
            //should delete without error
            BLProductVariation.DeletePV(id_created, ref errors);
            Assert.AreEqual(0, errors.Count);

            
            //BLProductVariation.DeletePV(invalid_pv_id, ref errors);
            Assert.AreEqual(0, errors.Count);
            BLProductVariation.DeletePV(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);
        }
    }
}
