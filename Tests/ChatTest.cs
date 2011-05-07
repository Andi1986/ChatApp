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
        private const string serverhost = "C:\\Users\\Frank\\Documents\\Visual Studio 2010\\Projects\\Chat";
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


        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        [TestCleanup()]
        public void MyTestCleanup()
        {
            int numberOfRooms = Chat.ActiveChats().Count;
            for (int i = 1; i < numberOfRooms; i++)
                Chat.removeChat(Chat.ActiveChats()[i]);
            Chat chat = Chat.ActiveChats()[0];
            int numberOfChatters = chat.Chatters.Count;
            for (int i = 0; i < numberOfChatters; i++)
                chat.leave(chat.Chatters[i]);
            chat.AllMessages.Clear();
        }

        /// <summary>
        ///Ein Test für "Chat-Konstruktor"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost,"/")]
        [UrlToTest("http://localhost:51655/")]
        public void ChatConstructorTest()
        {
            Chat target = new Chat();
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(target, typeof(Chat));
        }

        /// <summary>
        ///Ein Test für "ActiveChats"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ActiveChatsTest()
        {
            Assert.IsNotNull(Chat.ActiveChats());
            Assert.IsInstanceOfType(Chat.ActiveChats(), typeof(ReadOnlyCollection<Chat>));
            Assert.IsNotNull(Chat.ActiveChats()[0]);
        }

        /// <summary>
        ///Ein Test für "join"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void joinTest()
        {
            Chat chat = Chat.ActiveChats()[0];
            Assert.IsNotNull(chat.Chatters);
            Chatter chatter1 = new Chatter(new Guid(), "chatter 1");
            chatter1.intId = 0;
            Chatter chatter2 = new Chatter(new Guid(), "chatter 2");
            chatter1.intId = 1;
            chat.join(chatter1);
            chat.join(chatter2);
            Assert.IsTrue(chat.Chatters.Contains(chatter1), "chatter 1 was not joined");
            Assert.IsTrue(chat.Chatters.Contains(chatter2), "chatter 2 was not joined");
            chat.leave(chatter1);
            chat.leave(chatter2);
        }

        /// <summary>
        ///Ein Test für "leave"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void leaveTest()
        {
            Chat chat = Chat.ActiveChats()[0];
            Chatter chatter1 = new Chatter(new Guid(), "chatter 1");
            chatter1.intId = 0;
            Chatter chatter2 = new Chatter(new Guid(), "chatter 2");
            chatter2.intId = 1;
            Chatter chatter3 = new Chatter(new Guid(), "chatter 3");
            chatter3.intId = 2;
            chat.join(chatter1);
            chat.join(chatter2);
            chat.join(chatter3);
            chat.leave(chatter2);
            Assert.IsTrue(chat.Chatters.Contains(chatter1), "chatter 1 was removed");
            Assert.IsFalse(chat.Chatters.Contains(chatter2), "chatter 2 was not removed");
            Assert.IsTrue(chat.Chatters.Contains(chatter3), "chatter 3 was removed");
            chat.leave(chatter1);
            chat.leave(chatter3);
            Assert.IsTrue(chat.Chatters.Count == 0, "chat.Chatters is not empty after removing all chatters");
        }


        /// <summary>
        ///Ein Test für "SendMessage"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void SendMessageTest()
        {
            Chat chat = Chat.ActiveChats()[0];
            for (int i = 0; i < 5; i++)
            {
                string name = "myName"+i;
                string message = "A test message from me. =)"+i;
                string returnMessage = chat.SendMessage(name, message);
                Assert.IsTrue(returnMessage.Contains(name), "Run "+i+": the name was not used");
                Assert.IsTrue(returnMessage.Contains(message), "Run "+i+": the message text was not used");
                Assert.AreEqual(returnMessage, chat.AllMessages[chat.AllMessages.Count - 1].Message, "Run " + i + ": the saved message is not the returned message");
                Assert.AreEqual(-1, chat.AllMessages[chat.AllMessages.Count - 1].id, "Run " + i + ": The message is not visible for all chatters");
            }
        }

        /// <summary>
        ///Ein Test für "SendMessage"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void SendMessageTest1()
        {
            Chat chat = Chat.ActiveChats()[0];
            for (int i = 0; i < 5; i++)
            {
                string message = "Another test message!!! " + i;
                string returnMessage = chat.SendMessage(message);
                Assert.IsTrue(returnMessage.Contains(message), "Run " + i + ": the message text was not used");
                Assert.AreEqual(returnMessage, chat.AllMessages[chat.AllMessages.Count - 1].Message, "Run " + i + ": the saved message is not the returned message");
                Assert.AreEqual(-1, chat.AllMessages[chat.AllMessages.Count - 1].id, "Run " + i + ": The message is not visible for all chatters");
            }
        }

        /// <summary>
        ///Ein Test für "SendMessageTo"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void SendMessageToTest()
        {
            Chat chat = Chat.ActiveChats()[0];
            for (int i = 0; i < 5; i++)
            {
                string message = "A test message from me for you.." + i;
                int id = i;
                string returnMessage = chat.SendMessageTo(message, id);
                Assert.IsTrue(returnMessage.Contains(message), "Run " + i + ": the message text was not used");
                Assert.AreEqual(returnMessage, chat.AllMessages[chat.AllMessages.Count - 1].Message, "Run " + i + ": the saved message is not the returned message");
                Assert.AreEqual(i, chat.AllMessages[chat.AllMessages.Count - 1].id, "Run " + i + ": The message is not for the right id only");
            }
        }

        /// <summary>
        ///Ein Test für "SendMessageTo"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void SendMessageToTest1()
        {
            Chat chat = Chat.ActiveChats()[0];
            for (int i = 0; i < 5; i++)
            {
                string name = "myName" + i;
                string message = "A test message from me for you.." + i;
                int id = i;
                string returnMessage = chat.SendMessageTo(name, message, id);
                Assert.IsTrue(returnMessage.Contains(name), "Run " + i + ": the name was not used");
                Assert.IsTrue(returnMessage.Contains(message), "Run " + i + ": the message text was not used");
                Assert.AreEqual(returnMessage, chat.AllMessages[chat.AllMessages.Count - 1].Message, "Run " + i + ": the saved message is not the returned message");
                Assert.AreEqual(i, chat.AllMessages[chat.AllMessages.Count - 1].id, "Run " + i + ": The message is not for the right id only");
            }
        }

        /// <summary>
        ///Ein Test für "GetMyMessages"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void GetMyMessagesTest()
        {
            Chat chat = Chat.ActiveChats()[0];
            List<Chat.ChatMessageLine> allMessages = chat.AllMessages;
            Chat.ChatMessageLine messageForAll = new Chat.ChatMessageLine();
            messageForAll.id = -1;
            messageForAll.Message = "This is a message for all chatters";
            Chat.ChatMessageLine privateMessage = new Chat.ChatMessageLine();
            privateMessage.id = 3;
            privateMessage.Message = "This is a message just for you";
            allMessages.Add(messageForAll);
            allMessages.Add(privateMessage);

            Assert.IsTrue(chat.GetMyMessages(3).Contains(messageForAll.Message), "The message for all was not returned");
            Assert.IsTrue(chat.GetMyMessages(3).Contains(privateMessage.Message), "The private message was not returned");
            Assert.IsTrue(chat.GetMyMessages(2).Contains(messageForAll.Message), "The message for all was not returned");
            Assert.IsFalse(chat.GetMyMessages(2).Contains(privateMessage.Message), "The private message was returned to the wrong chatter");
        }


        /// <summary>
        ///Ein Test für "ToString"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void ToStringTest()
        {
        }

        /// <summary>
        ///Ein Test für "getNewChat"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void getNewChatTest()
        {
            Chat chat = Chat.getNewChat();
            Assert.IsTrue(chat == Chat.ActiveChats()[1], "The room was not created");
            Chat.removeChat(chat);
        }


        /// <summary>
        ///Ein Test für "newUpdates"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void newUpdatesTest()
        {
            Chat chat = Chat.ActiveChats()[0];
            Assert.IsFalse(chat.newUpdates(1), "Updates for a not existing chatter id");
            Chatter chatter = new Chatter(new Guid(), "chatter");
            chatter.intId = 2;
            chat.join(chatter);
            Assert.IsTrue(chat.newUpdates(chatter.intId), "No updates after joining");
            chat.iAmUpToDate(chatter.intId);
            Assert.IsFalse(chat.newUpdates(chatter.intId), "Updates after call 'I'm up to date'");
            chat.SendMessage("hallo");
            Assert.IsTrue(chat.newUpdates(chatter.intId), "No updates after receiving a new message");
            chat.iAmUpToDate(chatter.intId);
            chat.SendMessageTo("hallo", 1);
            Assert.IsFalse(chat.newUpdates(chatter.intId), "Updates after whispering to a different chatter");
            chat.SendMessageTo("hallo", 2);
            Assert.IsTrue(chat.newUpdates(chatter.intId), "No updates after whispering to this chatter");
        }


        /// <summary>
        ///Ein Test für "removeChat"
        ///</summary>
        // TODO: Sicherstellen, dass mit dem UrlToTest-Attribut die URL zu einer ASP.NET-Seite angegeben wird (z.B.
        // http://.../Default.aspx). Dies ist notwendig, damit der Komponententest auf dem Webserver ausgeführt wird,
        // unabhängig davon, ob eine Seite, ein Webdienst oder ein WCF-Dienst getestet wird.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost(serverhost, "/")]
        [UrlToTest("http://localhost:51655/")]
        public void removeChatTest()
        {
            Chat chat = Chat.getNewChat();
            Assert.IsTrue(chat == Chat.ActiveChats()[1], "The room was not created");
            Chat.removeChat(chat);
            Assert.IsTrue(Chat.ActiveChats().Count == 1, "The room was not removed");
            Chat.removeChat(Chat.ActiveChats()[0]);
            Assert.IsTrue(Chat.ActiveChats().Count == 1, "Main room was removed");
        }

    }
}
