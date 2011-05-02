using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;

public class Chat
{
    private Guid m_id;

    public Guid Id
    {
        get { return m_id; }
    }

    private List<string> m_messages = new List<string>();

    public List<string> Messages
    {
        get { return m_messages; }
    }

    private Dictionary<Chatter, bool> upToDate = new Dictionary<Chatter, bool>();

    private List<Chatter> m_chatters = new List<Chatter>();

    public void join(Chatter chatter)
    {
        m_chatters.Add(chatter);
        upToDate.Add(chatter, false);
        resetUpToDate();
    }

    public void leave(Chatter chatter)
    {
        m_chatters.Remove(chatter);
        upToDate.Remove(chatter);
        if (m_chatters.Count == 0)
            Chat.removeChat(this);
    }

    public List<Chatter> Chatters
    {
        get { return m_chatters; }
        //set { m_chatters = value; }
    }

    public static ReadOnlyCollection<Chat> ActiveChats()
    {
        if (HttpContext.Current.Application["Chats"] != null)
        {
            List<Chat> chats = ((List<Chat>)HttpContext.Current.Application["Chats"]);
            return new ReadOnlyCollection<Chat>(chats);
        }
        else
        {
            return new ReadOnlyCollection<Chat>(new List<Chat>());
        }
    }

    public static Chat getNewChat()
    {
        lock (typeof(Chat))
        {
            Chat chat = new Chat();
            List<Chat> chats = ((List<Chat>)HttpContext.Current.Application["Chats"]);
            chats.Add(chat);
            HttpContext.Current.Application["Chats"] = chats;
            return chat;
        }
    }

    public static void removeChat(Chat chat)
    {
        lock (typeof(Chat))
        {
            List<Chat> chats = ((List<Chat>)HttpContext.Current.Application["Chats"]);
            chats.Remove(chat);
            HttpContext.Current.Application["Chats"] = chats;
        }
    }

    public string SendMessage(string name, string message)
    {
        string messageMask = "{0} @ {1} : {2}";
        message = string.Format(messageMask, name, DateTime.Now.ToString(), message);
        m_messages.Add(message);
        resetUpToDate();
        return message;
    }

    public string SendMessage(String message) {
        string messageMask = "{0} : {1}";
        message = string.Format(messageMask, DateTime.Now.ToString(), message);
        m_messages.Add(message);
        resetUpToDate();
        return message;
    }

    public Chat()
    {
        m_id = Guid.NewGuid();
    }

    private void resetUpToDate()
    {
        List<Chatter> chatters = new List<Chatter>();
        foreach (Chatter chatter in upToDate.Keys)
            chatters.Add(chatter);
        foreach(Chatter chatter in chatters)
            upToDate[chatter] = false;
    }

    public bool newUpdates(Chatter chatter)
    {
        bool noUpdate = false;
        upToDate.TryGetValue(chatter, out noUpdate);
        bool returnValue = !noUpdate;
        upToDate[chatter] = true;
        return returnValue;
    }
}