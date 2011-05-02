using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {
        //sinnloser Kommentar um git zu testen

        void Application_Start(object sender, EventArgs e)
        {
            // Code, der beim Starten der Anwendung ausgeführt wird.
            List<Chatter> chatters = new List<Chatter>();
            /*chatters.Add(new Chatter(new Guid("CD863C27-2CEE-45fd-A2E0-A69E62B816B9"), "Me"));
            chatters.Add(new Chatter(Guid.NewGuid(), "Juan"));
            chatters.Add(new Chatter(Guid.NewGuid(), "Joe"));
            chatters.Add(new Chatter(Guid.NewGuid(), "Eric"));
            chatters.Add(new Chatter(Guid.NewGuid(), "Brian"));
            chatters.Add(new Chatter(Guid.NewGuid(), "Kim"));
            chatters.Add(new Chatter(Guid.NewGuid(), "Victor"));*/
            Application.Add("Chatters", chatters);

            List<Chat> chats = new List<Chat>();
            chats.Add(new Chat());
            chats.Add(new Chat());
            Application.Add("Chats", chats);

            /*
            foreach (KeyValuePair<Guid, Chatter> chatter in Chatter.ActiveChatters())
            {
                chatter.Value.Join(Chat.ActiveChats()[0]);
            }*/
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code, der beim Herunterfahren der Anwendung ausgeführt wird.

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code, der bei einem nicht behandelten Fehler ausgeführt wird.

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code, der beim Starten einer neuen Sitzung ausgeführt wird.

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code, der am Ende einer Sitzung ausgeführt wird. 
            // Hinweis: Das Session_End-Ereignis wird nur ausgelöst, wenn der sessionstate-Modus
            // in der Datei "Web.config" auf InProc festgelegt wird. Wenn der Sitzungsmodus auf StateServer festgelegt wird
            // oder auf SQLServer, wird das Ereignis nicht ausgelöst.

        }

    }
}
