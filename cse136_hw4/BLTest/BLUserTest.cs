using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using DomainModel;

namespace BLTest
{
    /// <summary>
    /// Summary description for BLUserTest
    /// </summary>
    [TestClass]
    public class BLUserTest
    {
        public BLUserTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateUserTest()
        {
            int users_id = 0;
            int customer_id = 0;
            char user_level = 'j';
            char condition = 'c';
            string email = "such@bullshit@email.addresses.com";

            Random random = new Random();
            Users users;

            List<string> errors = new List<string>();

            BLUser.CreateUser(null, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //users_id = 0
            errors = new List<string>();
            users = new Users(users_id, 1, "username" + random.Next(10000), "password", 'u',
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, 'a');
            BLUser.CreateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //customer_id = 0
            errors = new List<string>();
            users = new Users(1, customer_id, "username" + random.Next(10000), "password", 'u',
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, 'a');
            BLUser.CreateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //user_level = j
            errors = new List<string>();
            users = new Users(1, 1, "username" + random.Next(10000), "password", user_level,
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, 'a');
            BLUser.CreateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //condition = c
            errors = new List<string>();
            users = new Users(1, 1, "username" + random.Next(10000), "password", 'u',
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, condition);
            BLUser.CreateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //email = such@bullshit@email.addresses.com
            errors = new List<string>();
            users = new Users(1, 1, "username" + random.Next(10000), "password", 'u',
                                    email, DateTime.Now, DateTime.Now, 'a');
            BLUser.CreateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //all 5
            errors = new List<string>();
            users = new Users(users_id, customer_id, "username" + random.Next(10000), "password", user_level,
                                    email, DateTime.Now, DateTime.Now, condition);
            BLUser.CreateUser(users, ref errors);
            Assert.AreEqual(5, errors.Count);
            AsynchLog.LogNow(errors);

            //none
            errors = new List<string>();
            users = new Users(1, 1, "username" + random.Next(10000), "password", 'u',
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, 'a');
            BLUser.CreateUser(users, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void ReadUserTest()
        {
            int id = 0;
            List<string> errors = new List<string>();

            //id = 0
            BLUser.ReadUser(id, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //no errors
            errors = new List<string>();
            BLUser.ReadUser(1, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            int users_id = 0;
            int customer_id = 0;
            char user_level = 'j';
            char condition = 'c';
            string email = "such@bullshit@email.addresses.com";

            Random random = new Random();
            Users users;

            List<string> errors = new List<string>();

            BLUser.UpdateUser(null, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //users_id = 0
            errors = new List<string>();
            users = new Users(users_id, 1, "username" + random.Next(10000), "password", 'u',
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, 'a');
            BLUser.UpdateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //customer_id = 0
            errors = new List<string>();
            users = new Users(1, customer_id, "username" + random.Next(10000), "password", 'u',
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, 'a');
            BLUser.UpdateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //user_level = j
            errors = new List<string>();
            users = new Users(1, 1, "username" + random.Next(10000), "password", user_level,
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, 'a');
            BLUser.UpdateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //condition = c
            errors = new List<string>();
            users = new Users(1, 1, "username" + random.Next(10000), "password", 'u',
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, condition);
            BLUser.UpdateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //email = such@bullshit@email.addresses.com
            errors = new List<string>();
            users = new Users(1, 1, "username" + random.Next(10000), "password", 'u',
                                    email, DateTime.Now, DateTime.Now, 'a');
            BLUser.UpdateUser(users, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

            //all 5
            errors = new List<string>();
            users = new Users(users_id, customer_id, "username" + random.Next(10000), "password", user_level,
                                    email, DateTime.Now, DateTime.Now, condition);
            BLUser.UpdateUser(users, ref errors);
            Assert.AreEqual(5, errors.Count);
            AsynchLog.LogNow(errors);

            //none
            errors = new List<string>();
            users = new Users(1, 1, "username" + random.Next(10000), "password", 'u',
                                    "test" + random.Next(10000) + "@test.com", DateTime.Now, DateTime.Now, 'a');
            BLUser.UpdateUser(users, ref errors);
            Assert.AreEqual(0, errors.Count);
            AsynchLog.LogNow(errors);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            int id = 0;
            List<string> errors = new List<string>();

            //id = 0
            BLUser.DeleteUser(id, ref errors);
            Assert.AreEqual(1, errors.Count);
            AsynchLog.LogNow(errors);

        }
    }
}
