using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Tests
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ChatTest" und soll
    ///alle ChatTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ChatTest
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
        ///Ein Test für "Chat-Konstruktor"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ChatConstructorTest()
        {
            Chat target = new Chat();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "ActiveChats"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ActiveChatsTest()
        {

            Assert.IsNotNull(Chat.ActiveChats());
            Assert.IsInstanceOfType(Chat.ActiveChats(), typeof(ReadOnlyCollection<Chat>));
            Assert.IsNotNull(Chat.ActiveChats()[0]);


           /* ReadOnlyCollection<Chat> expected = null; // TODO: Passenden Wert initialisieren
            ReadOnlyCollection<Chat> actual;
            actual = Chat.ActiveChats();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");*/
        }

        /// <summary>
        ///Ein Test für "GetMyMessages"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void GetMyMessagesTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            int id = 0; // TODO: Passenden Wert initialisieren
            List<string> expected = null; // TODO: Passenden Wert initialisieren
            List<string> actual;
            actual = target.GetMyMessages(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "SendMessage"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void SendMessageTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            string message = string.Empty; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.SendMessage(name, message);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "SendMessage"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void SendMessageTest1()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            string message = string.Empty; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.SendMessage(message);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "SendMessageTo"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void SendMessageToTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            string message = string.Empty; // TODO: Passenden Wert initialisieren
            int id = 0; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.SendMessageTo(message, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "SendMessageTo"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void SendMessageToTest1()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            string message = string.Empty; // TODO: Passenden Wert initialisieren
            int id = 0; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.SendMessageTo(name, message, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ToString"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ToStringTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "getNewChat"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void getNewChatTest()
        {
            Chat expected = null; // TODO: Passenden Wert initialisieren
            Chat actual;
            actual = Chat.getNewChat();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "join"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void joinTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            Chatter chatter = null; // TODO: Passenden Wert initialisieren
            target.join(chatter);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "leave"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void leaveTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            Chatter chatter = null; // TODO: Passenden Wert initialisieren
            target.leave(chatter);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "newUpdates"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void newUpdatesTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            Chatter chatter = null; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.newUpdates(chatter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "removeChat"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void removeChatTest()
        {
            Chat chat = null; // TODO: Passenden Wert initialisieren
            Chat.removeChat(chat);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "resetUpToDate"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        [DeploymentItem("WebApplication1.dll")]
        public void resetUpToDateTest()
        {
            Chat_Accessor target = new Chat_Accessor(); // TODO: Passenden Wert initialisieren
            target.resetUpToDate();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "AllMessages"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void AllMessagesTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            List<Chat.ChatMessageLine> actual;
            actual = target.AllMessages;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Chatters"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\SoftwareEngineeringII\\chatApp\\ChatApp", "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ChattersTest()
        {
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            List<Chatter> actual;
            actual = target.Chatters;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
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
            Chat target = new Chat(); // TODO: Passenden Wert initialisieren
            Guid actual;
            actual = target.Id;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
