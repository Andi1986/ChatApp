using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Chatter_offlineTest
    {
        Chatter chatter;

        [TestInitialize]
        public void createChatter()
        {
            chatter = new Chatter(Guid.NewGuid(), "TestChatter");
        }
        
        [TestMethod]
        public void ChatterConstructorTest()
        {
            Assert.IsNotNull(chatter);
            Assert.IsInstanceOfType(chatter, typeof(Chatter));
            Assert.AreEqual("TestChatter", chatter.Name);
        }

        [TestMethod]
        public void ActiveChattersTest()
        {
            //uses the HttpContext.Current.Application Variable, which is only available on the server
            //--> no offline test possible
        }

        [TestMethod]
        public void JoinTest()
        {
            Chat chat = new Chat();
            Assert.IsFalse(chat.Chatters.Contains(chatter));
            chatter.Join(chat);
            Assert.IsTrue(chat.Chatters.Contains(chatter));
            chatter.Leave(chat);
            Assert.IsFalse(chat.Chatters.Contains(chatter));
        }

        //[TestMethod]
        public void LeaveTest()
        {
            Chat chat = new Chat();
            chatter.Join(chat);
            //chat.Chatters.Add(chatter);
            //chatter.myChats.Add(chat);
            Assert.IsTrue(chatter.myChats.Contains(chat));
            chatter.Leave(chat);
            Assert.IsFalse(chatter.myChats.Contains(chat));
        }


        //[TestMethod()]
        public void LeaveAllTest()
        {
            Chat chat1 = new Chat();
            Chat chat2 = new Chat();
            chatter.Join(chat1);
            chatter.Join(chat2);
            chatter.LeaveAll();
            Assert.IsFalse(chat1.Chatters.Contains(chatter) || chat2.Chatters.Contains(chatter));
        }

    }
}
