using WebApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace Tests
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "DBConnectionHelperTest" und soll
    ///alle DBConnectionHelperTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class DBConnectionHelperTest
    {


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
            set
            {
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
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
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
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void FriendUsersTest()
        {
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
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void InitTest()
        {
            string dbPath = string.Empty; // TODO: Passenden Wert initialisieren
            DBConnectionHelper.Init(dbPath);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "MakeSQLInsertQuery"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void MakeSQLInsertQueryTest()
        {
            string table = string.Empty; // TODO: Passenden Wert initialisieren
            string[] columns = null; // TODO: Passenden Wert initialisieren
            string[] values = null; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = DBConnectionHelper.MakeSQLInsertQuery(table, columns, values);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ReadBuddiesFromUser"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
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
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ReadUserRecordsTest()
        {
            List<Record> expected = null; // TODO: Passenden Wert initialisieren
            List<Record> actual;
            actual = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
