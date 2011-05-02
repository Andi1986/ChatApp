using System;
using System.Collections.Generic;
using System.Web;


public class Chatter
{
    private Guid m_id;

    public Guid Id
    {
        get { return m_id; }
    }

    private string m_name;

    public string Name
    {
        get { return m_name; }
    }



    public static Dictionary<Guid, Chatter> ActiveChatters()
    {
        Dictionary<Guid, Chatter> retval = new Dictionary<Guid, Chatter>();
        if (HttpContext.Current.Application["Chatters"] != null)
        {
            List<Chatter> chatters = ((List<Chatter>)HttpContext.Current.Application["Chatters"]);
            foreach (Chatter chatter in chatters)
            {
                retval.Add(chatter.Id, chatter);
            }
        }
        return retval;
    }

    private List<Chat> myChats = new List<Chat>();
    private List<Chatter> myBuddies = new List<Chatter>();
    private int mainChat;

    public int MainChat
    {
        get { return mainChat; }
    }

    public Chatter(Guid id, string name)
    {
        m_id = id;
        m_name = name;
        mainChat = 0;
    }

    public void Join(Chat chat)
    {
        chat.join(this);
        myChats.Add(chat);
        chat.SendMessage("User " + m_name + " has joined the Chat");
    }

    public void Leave(Chat chat)
    {
        chat.leave(this);
        myChats.Remove(chat);
        chat.SendMessage("User " + m_name + " left the Chat Room");
    }

    public void LeaveAll()
    {
        List<Chat> chats = new List<Chat>();
        foreach (Chat chat in myChats)
            chats.Add(chat);
        foreach (Chat chat in chats)
            Leave(chat);

    }

    public void sendMessage(string msg)
    {
        Chat.ActiveChats()[mainChat].SendMessage(m_name, msg);
    }

    public void changeRoom()
    {
        Chat oldChat = Chat.ActiveChats()[mainChat];
        Leave(oldChat);
        mainChat++;
        if (mainChat >= Chat.ActiveChats().Count)
            mainChat = 0;
        Chat newChat = Chat.ActiveChats()[mainChat];
        if (!myChats.Contains(newChat))
            Join(newChat);

    }





    
}
