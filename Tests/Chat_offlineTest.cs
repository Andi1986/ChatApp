using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestClass]
    public class Chat_offlineTest
    {



        [TestMethod()]
        public void ChatConstructorTest()
        {
            Chat target = new Chat();
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(target, typeof(Chat));
        }

        [TestMethod()]
        public void ActiveChatsTest()
        {
            //uses the HttpContext.Current.Application Variable, which is only available on the server
            //--> no offline test possible
        }

        [TestMethod()]
        public void joinTest()
        {
            Chat chat = new Chat();
            Assert.IsNotNull(chat.Chatters);
            Chatter chatter1 = new Chatter(new Guid(), "chatter 1");
            chatter1.intId = 0;
            Chatter chatter2 = new Chatter(new Guid(), "chatter 2");
            chatter1.intId = 1;
            chat.join(chatter1);
            chat.join(chatter2);
            Assert.IsTrue(chat.Chatters.Contains(chatter1), "chatter 1 was not joined");
            Assert.IsTrue(chat.Chatters.Contains(chatter2), "chatter 2 was not joined");
        }


        [TestMethod()]
        public void leaveTest()
        {
            //uses ActiveChats() --> no offline test possible
        }

        [TestMethod()]
        public void SendMessageTest()
        {
            Chat chat = new Chat();
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

        [TestMethod()]
        public void SendMessageTest1()
        {
            Chat chat = new Chat();
            for (int i = 0; i < 5; i++)
            {
                string message = "Another test message!!! " + i;
                string returnMessage = chat.SendMessage(message);
                Assert.IsTrue(returnMessage.Contains(message), "Run " + i + ": the message text was not used");
                Assert.AreEqual(returnMessage, chat.AllMessages[chat.AllMessages.Count - 1].Message, "Run " + i + ": the saved message is not the returned message");
                Assert.AreEqual(-1, chat.AllMessages[chat.AllMessages.Count - 1].id, "Run " + i + ": The message is not visible for all chatters");
            }
        }

        [TestMethod()]
        public void SendMessageToTest()
        {
            Chat chat = new Chat();
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

        [TestMethod()]
        public void SendMessageToTest1()
        {
            Chat chat = new Chat();
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

        [TestMethod()]
        public void GetMyMessagesTest()
        {
            Chat chat = new Chat();
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

        [TestMethod()]
        public void getNewChatTest()
        {
            //uses the HttpContext.Current.Application Variable, which is only available on the server
            //--> no offline test possible
        }

        [TestMethod()]
        public void newUpdatesTest()
        {
            Chat chat = new Chat();
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

        [TestMethod()]
        public void removeChatTest()
        {
            //uses the HttpContext.Current.Application Variable, which is only available on the server
            //--> no offline test possible
        }


    }
}
