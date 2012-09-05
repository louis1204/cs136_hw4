using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DomainModel;

namespace DALUserTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DALUserTest
    {
        public DALUserTest()
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

        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod]
        public void CreateUserTest()
        {
            Random random = new Random();
            Users users = new Users(1, 1, "username" + random.Next(10000), "password", 'u', "test" + random.Next(10000) + "@test.com",
                                    DateTime.Now, DateTime.Now, 'a');

            List<string> errors = new List<string>();
            int result = DALUser.CreateUser(users, ref errors);

            Assert.AreNotEqual(-1, result);

            Users verifyUser = DALUser.ReadUser(result, ref errors);
            Assert.AreEqual(0, errors.Count());

            Assert.AreEqual(result, verifyUser.users_id);
            Assert.AreEqual(users.customer_id, verifyUser.customer_id);
            Assert.AreEqual(users.username, verifyUser.username);
            Assert.AreEqual(users.password, verifyUser.password);
            Assert.AreEqual(users.user_level, verifyUser.user_level);
            Assert.AreEqual(users.email, verifyUser.email);
            Assert.AreEqual(users.condition, verifyUser.condition);

        }
        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        [TestMethod]
        public void UpdateUserTest()
        {
            int myId = 1;
            Random random = new Random();
            Users users = new Users(myId, 1, "username" + random.Next(10000), "password", 'u', "test" + random.Next(10000) + "@test.com",
                                    DateTime.Now, DateTime.Now, 'a');

            List<string> errors = new List<string>();
            int result = DALUser.UpdateUser(users, ref errors);

            Assert.AreNotEqual(-1, result);

            Users verifyUser = DALUser.ReadUser(myId, ref errors);
            Assert.AreEqual(0, errors.Count());

            Assert.AreEqual(users.users_id, verifyUser.users_id);
            Assert.AreEqual(users.customer_id, verifyUser.customer_id);
            Assert.AreEqual(users.password, verifyUser.password);
            Assert.AreEqual(users.user_level, verifyUser.user_level);
            Assert.AreEqual(users.email, verifyUser.email);
        }
        /// <summary>
        ///A test for DeletetUser
        ///</summary>
        [TestMethod]
        public void DeleteUserTest()
        {
            List<string> errors = new List<string>();

            Random random = new Random();

            Users users = new Users(1, 1, "username" + random.Next(10000), "password", 'u', "test" + random.Next(10000) + "@test.com",
                                    DateTime.Now, DateTime.Now, 'a');
            int id = DALUser.CreateUser(users, ref errors);

            Assert.AreNotEqual(-1, id);


            int result = DALUser.DeleteUser(id, ref errors);
            Assert.AreNotEqual(-1, result);

            Users verifyUser = DALUser.ReadUser(id, ref errors);
            Assert.AreEqual(0, errors.Count());

            Assert.AreEqual('d', verifyUser.condition);

            Assert.AreNotEqual(-1, result);
        }
        /// <summary>
        ///A test for ReadUserList
        ///</summary>
        [TestMethod]
        public void ReadUserListTest()
        {
            List<string> errors = new List<string>();    
            List<Users> ul1 = DALUser.ReadUsers(ref errors);
            List<Users> ul2 = DALUser.ReadUsers(ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(ul1.Count, ul2.Count);

            for (int i = 0; i < ul1.Count; i++)
            {
                Assert.AreEqual(ul1[i].users_id, ul2[i].users_id);
                Assert.AreEqual(ul1[i].username, ul2[i].username);
                Assert.AreEqual(ul1[i].password, ul2[i].password);
                Assert.AreEqual(ul1[i].customer_id, ul2[i].customer_id);
                Assert.AreEqual(ul1[i].user_level, ul2[i].user_level);
                Assert.AreEqual(ul1[i].email, ul2[i].email);
                Assert.AreEqual(ul1[i].last_login, ul2[i].last_login);
                Assert.AreEqual(ul1[i].create_date, ul2[i].create_date);
                Assert.AreEqual(ul1[i].condition, ul2[i].condition);
            }

        }
    }
}
