using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace Tests
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ChatterTest" und soll
    ///alle ChatterTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ChatterTest
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
        ///Ein Test für "Chatter-Konstruktor"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ChatterConstructorTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "ActiveChatters"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ActiveChattersTest()
        {
            Dictionary<Guid, Chatter> expected = null; // TODO: Passenden Wert initialisieren
            Dictionary<Guid, Chatter> actual;
            actual = Chatter.ActiveChatters();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "CompareTo"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void CompareToTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            object obj = null; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.CompareTo(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Join"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void JoinTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            Chat chat = null; // TODO: Passenden Wert initialisieren
            target.Join(chat);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Leave"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void LeaveTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            Chat chat = null; // TODO: Passenden Wert initialisieren
            target.Leave(chat);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "LeaveAll"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void LeaveAllTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            target.LeaveAll();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "changeRoom"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void changeRoomTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            target.changeRoom();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "changeRoom"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void changeRoomTest1()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            int index = 0; // TODO: Passenden Wert initialisieren
            target.changeRoom(index);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "createNewChatWith"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void createNewChatWithTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            string[] nickNames = null; // TODO: Passenden Wert initialisieren
            target.createNewChatWith(nickNames);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "inviteToChat"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void inviteToChatTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            string nickName = string.Empty; // TODO: Passenden Wert initialisieren
            target.inviteToChat(nickName);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "sendMessage"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void sendMessageTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            string msg = string.Empty; // TODO: Passenden Wert initialisieren
            target.sendMessage(msg);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Id"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void IdTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            Guid actual;
            actual = target.Id;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "MainChat"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void MainChatTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            Chat actual;
            actual = target.MainChat;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Name"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void NameTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "buddyList"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void buddyListTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            List<int> expected = null; // TODO: Passenden Wert initialisieren
            List<int> actual;
            target.buddyList = expected;
            actual = target.buddyList;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "email"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void emailTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            target.email = expected;
            actual = target.email;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "intId"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void intIdTest()
        {
            Guid id = new Guid(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            Chatter target = new Chatter(id, name); // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            target.intId = expected;
            actual = target.intId;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
