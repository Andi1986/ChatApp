using System.Threading;
using WebApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace Tests {

    /// <summary>
    ///Dies ist eine Testklasse für "DBConnectionHelperTest" und soll
    ///alle DBConnectionHelperTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class DBConnectionHelperTest {

        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        // 
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "ExecuteNonQuery"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ExecuteNonQueryTest() {
            string sql = "INSERT INTO TUsers (CName, CPassword, CEmail, CGuid) VALUES ('Testname', 'Testpassword', 'Testemail', 'Testguid')";
            DBConnectionHelper.ExecuteNonQuery(sql);
            List<Record> list = DBConnectionHelper.ReadUserRecords();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Testname", list[0].Entries[DBConnectionHelper._columnName]);
            Assert.AreEqual("Testpassword", list[0].Entries[DBConnectionHelper._columPasword]);
            Assert.AreEqual("Testemail", list[0].Entries[DBConnectionHelper._columnEmail]);
            Assert.AreEqual("Testguid", list[0].Entries[DBConnectionHelper._columnGuid]);

            sql = "DELETE FROM TUsers WHERE ID=" + list[0].Entries["ID"];
            DBConnectionHelper.ExecuteNonQuery(sql);
            list = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        ///Ein Test für "FriendUsers"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void FriendUsersTest() {

            for (int i = 0; i < 2; i++) {
                DBConnectionHelper.ExecuteNonQuery(DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser, new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                             new String[] {"Username" + i.ToString("00"),
                                "Password"+ i.ToString("00"),
                                "email"+ i.ToString("00")+"@mail.de",
                               Guid.NewGuid().ToString()}));
            }
            Thread.Sleep(1000);

            List<Record> list = DBConnectionHelper.ReadUserRecords();
            int userID1 = Convert.ToInt32(list[0].Entries["ID"]);
            int userID2 = Convert.ToInt32(list[1].Entries["ID"]);
            bool re = DBConnectionHelper.FriendUsers(userID1, userID2);
            Assert.AreEqual(true, re);
            List<int> actual = DBConnectionHelper.ReadBuddiesFromUser(userID1);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(userID2, actual[0]);

            actual = DBConnectionHelper.ReadBuddiesFromUser(userID2);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(userID1, actual[0]);
        }

        /// <summary>
        ///Ein Test für "Init"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void InitTest() {
            string dbPath = string.Empty; // TODO: Passenden Wert initialisieren
            DBConnectionHelper.Init(dbPath);
            Assert.IsFalse(String.IsNullOrEmpty(DBConnectionHelper._columnBuddyBuddy), "_columnBuddyBuddy is null or empty. config was not read");
            Assert.IsFalse(String.IsNullOrEmpty(DBConnectionHelper._columnBuddyUser), "_columnBuddyUser is null or empty. config was not read");
            Assert.IsFalse(String.IsNullOrEmpty(DBConnectionHelper._columnEmail), "_columnEmail is null or empty. config was not read");
            Assert.IsFalse(String.IsNullOrEmpty(DBConnectionHelper._columnGuid), "_columnGuid is null or empty. config was not read");
            Assert.IsFalse(String.IsNullOrEmpty(DBConnectionHelper._columnName), "_columnName is null or empty. config was not read");
            Assert.IsFalse(String.IsNullOrEmpty(DBConnectionHelper._columPasword), "_columPasword is null or empty. config was not read");
            Assert.IsFalse(String.IsNullOrEmpty(DBConnectionHelper._tableBuddy), "_tableBuddy is null or empty. config was not read");
            Assert.IsFalse(String.IsNullOrEmpty(DBConnectionHelper._tableUser), "_tableUser is null or empty. config was not read");
        }

        /// <summary>
        ///Ein Test für "MakeSQLInsertQuery"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void MakeSQLInsertQueryTest() {
            string table = "TUsers";
            string[] columns = { "Name", "Password", "Email" };
            string[] values = { "Testname", "Testpassword", "Testemail" };
            string expected = "INSERT INTO TUsers (Name, Password, Email) VALUES ('Testname', 'Testpassword', 'Testemail')";
            string actual;
            actual = DBConnectionHelper.MakeSQLInsertQuery(table, columns, values);
            Assert.AreEqual(expected, actual);
            table = "TUsers";
            columns = new string[] { "Name" };
            values = new string[] { "Testname" };
            expected = "INSERT INTO TUsers (Name) VALUES ('Testname')";
            actual = DBConnectionHelper.MakeSQLInsertQuery(table, columns, values);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "ReadBuddiesFromUser"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ReadBuddiesFromUserTest() {
            int id = 1;
            int expected = 0;
            List<int> actual;
            actual = DBConnectionHelper.ReadBuddiesFromUser(id);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Count);

            int count = 3;
            for (int i = 0; i < count; i++) {
                DBConnectionHelper.ExecuteNonQuery(DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser, new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                             new String[] {"Username" + i.ToString("00"),
                                "Password"+ i.ToString("00"),
                                "email"+ i.ToString("00")+"@mail.de",
                               Guid.NewGuid().ToString()}));
            }
            Thread.Sleep(1000);

            List<Record> list = DBConnectionHelper.ReadUserRecords();
            for (int i = 0; i < count - 1; i++) {
                DBConnectionHelper.FriendUsers(Convert.ToInt32(list[0].Entries["ID"]),
                               Convert.ToInt32(list[i + 1].Entries["ID"]));
            }


            actual = DBConnectionHelper.ReadBuddiesFromUser(Convert.ToInt32(list[0].Entries["ID"]));
            for (int i = 0; i < count - 1; i++) {
                Assert.IsTrue(actual.Contains(Convert.ToInt32(list[i + 1].Entries["ID"])), "Expected ID " + list[i + 1].Entries["ID"] + " not found");
            }

            Assert.AreEqual(count - 1, actual.Count);
        }

        /// <summary>
        ///Ein Test für "ReadUserRecords"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ReadUserRecordsTest() {
            int expected = 0; // 
            List<Record> actual;
            actual = DBConnectionHelper.ReadUserRecords();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Count);

            int count = 3;
            for (int i = 0; i < count; i++) {
                DBConnectionHelper.ExecuteNonQuery(DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser, new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                             new String[] {"Username" + i.ToString("00"),
                                "Password"+ i.ToString("00"),
                                "email"+ i.ToString("00")+"@mail.de",
                               Guid.NewGuid().ToString()}));
            }
            Thread.Sleep(1000);
            actual = DBConnectionHelper.ReadUserRecords();
            Assert.IsNotNull(actual);
            Assert.AreEqual(count, actual.Count);

            for (int i = 0; i < count; i++) {
                Record record = actual[i];

                Assert.AreEqual("Username" + i.ToString("00"), record.Entries[DBConnectionHelper._columnName]);
                Assert.AreEqual("Password" + i.ToString("00"), record.Entries[DBConnectionHelper._columPasword]);
                Assert.AreEqual("email" + i.ToString("00") + "@mail.de", record.Entries[DBConnectionHelper._columnEmail]);
            }


        }

        /// <summary>
        ///A test for MakeSQLDeleteQuery
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void MakeSQLDeleteQueryTest() {
            string table = "Users";
            string[] key = { "CUsers", "CBuddy" };
            string[] value = { "20", "21" };
            string expected = "DELETE FROM Users WHERE CUsers=20 AND CBuddy=21";
            string actual;
            actual = DBConnectionHelper.MakeSQLDeleteQuery(table, key, value);
            Assert.AreEqual(expected, actual);

            table = "Users";
            key = new string[] { "CUsers" };
            value = new string[] { "20" };
            expected = "DELETE FROM Users WHERE CUsers=20";
            actual = DBConnectionHelper.MakeSQLDeleteQuery(table, key, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UnfriendUsers
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void UnfriendUsersTest() {
            FriendUsersTest();
            List<Record> list = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(2, list.Count);

            int userID1 = Convert.ToInt32(list[0].Entries["ID"]);
            int userID2 = Convert.ToInt32(list[1].Entries["ID"]);

            bool actual = DBConnectionHelper.UnfriendUsers(userID1, userID2);
            Assert.AreEqual(true, actual);

            list = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(2, list.Count);

            List<int> buddies = DBConnectionHelper.ReadBuddiesFromUser(userID1);
            Assert.AreEqual(0, buddies.Count);
            buddies = DBConnectionHelper.ReadBuddiesFromUser(userID2);
            Assert.AreEqual(0, buddies.Count);

        }


        /// <summary>
        ///A test for ClearTable
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ClearTableTest() {
            DBConnectionHelper.Init(_ProjectPath.projectPath + @"\DB\Database_Test.mdb");
            string table = DBConnectionHelper._tableBuddy;
            DBConnectionHelper.ClearTable(table);
            Thread.Sleep(1000);
            List<Record> list = DBConnectionHelper.ReadUserRecords();
            int before = list.Count;
            if (before == 0) {
                DBConnectionHelper.ExecuteNonQuery(DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser, new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                                new String[] {"Username",
                                "Password",
                                "email@mail.de",
                               Guid.NewGuid().ToString()}));
                Thread.Sleep(1000);
                before = (list = DBConnectionHelper.ReadUserRecords()).Count;
            }
            Assert.IsTrue(before > 0, "No entries in table");

            table = DBConnectionHelper._tableUser;
            DBConnectionHelper.ClearTable(table);
            Thread.Sleep(1000);
            int after = (list = DBConnectionHelper.ReadUserRecords()).Count;
            Assert.AreEqual(0, after);
        }

        [TestInitialize]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void Setup() {
            DBConnectionHelper.Init(_ProjectPath.projectPath + @"\DB\Database_Test.mdb");
            DBConnectionHelper.ClearTable(DBConnectionHelper._tableBuddy);
            DBConnectionHelper.ClearTable(DBConnectionHelper._tableUser);
        }

        [TestCleanup]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void Teardown() {
            DBConnectionHelper.ClearTable(DBConnectionHelper._tableBuddy);
            DBConnectionHelper.ClearTable(DBConnectionHelper._tableUser);
        }

        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(_ProjectPath.projectPath, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void DeleteUserTest() {
            int id = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = DBConnectionHelper.DeleteUser(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
