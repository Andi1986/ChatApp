﻿using WebApplication1;
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
        public const string AspNetDevelopmentServerHost = @"D:\Dropbox\Workspace\ChatApp";


        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
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
        public void ExecuteNonQueryTest()
        {
            string sql = string.Empty; // TODO: Passenden Wert initialisieren
            DBConnectionHelper.ExecuteNonQuery(sql);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
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

            int userID1 = 0; // TODO: Passenden Wert initialisieren
            int userID2 = 0; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = DBConnectionHelper.FriendUsers(userID1, userID2);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
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
        public void InitTest()
        {
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
        public void ReadBuddiesFromUserTest()
        {
            int id = 0; // TODO: Passenden Wert initialisieren
            List<int> expected = null; // TODO: Passenden Wert initialisieren
            List<int> actual;
            actual = DBConnectionHelper.ReadBuddiesFromUser(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
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
            List<Record> expected = null; // TODO: Passenden Wert initialisieren
            List<Record> actual;
            actual = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///A test for MakeSQLDeleteQuery
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Dropbox\\Workspace\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void MakeSQLDeleteQueryTest() {
            string table = "Users";
            string[] key = {"CUsers", "CBuddy"};
            string[] value = {"20","21"};
            string expected = "DELETE FROM Users WHERE CUsers=20 AND CBuddy=21";
            string actual;
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
        [AspNetDevelopmentServerHost("D:\\Dropbox\\Workspace\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void UnfriendUsersTest() {
            int userID1 = 0; // TODO: Initialize to an appropriate value
            int userID2 = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = DBConnectionHelper.UnfriendUsers(userID1, userID2);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
