using System;
using System.Collections.Generic;
using System.Web;


public class Chatter {
    private Guid m_id;
    public Guid Id {
        get { return m_id; }
    }

    private string m_name;
    public string Name {
        get { return m_name; }
    }

    public string email { get; set; }
    public int intId { get; set; }


    public static Dictionary<Guid, Chatter> ActiveChatters() {
        Dictionary<Guid, Chatter> retval = new Dictionary<Guid, Chatter>();
        if (HttpContext.Current.Application["Chatters"] != null) {
            List<Chatter> chatters = ((List<Chatter>)HttpContext.Current.Application["Chatters"]);
            foreach (Chatter chatter in chatters) {
                retval.Add(chatter.Id, chatter);
            }
        }
        return retval;
    }

    private List<Chat> myChats = new List<Chat>();
    public List<Chatter> myBuddies = new List<Chatter>();
    public List<int> buddyList { get; set; }

    private int mainChat;

    public Chat MainChat {
        get { return myChats[mainChat]; }
    }

    public Chatter(Guid id, string name) {
        m_id = id;
        m_name = name;
        mainChat = 0;
    }

    public void Join(Chat chat) {
        if (!myChats.Contains(chat))
        {
            chat.join(this);
            myChats.Add(chat);
            chat.SendMessage("User " + m_name + " has joined the Chat");
        }
    }

    public void Leave(Chat chat) {
        if (!chat.Equals(myChats[0])) {
            chat.leave(this);
            myChats.Remove(chat);
            chat.SendMessage("User " + m_name + " left the Chat Room");
        }
        mainChat = 0;
    }

    public void LeaveAll() {
        List<Chat> chats = new List<Chat>();
        foreach (Chat chat in myChats)
            chats.Add(chat);
        foreach (Chat chat in chats) {
            chat.leave(this);
            myChats.Remove(chat);
            chat.SendMessage("User " + m_name + " left the Chat Room");
        }
    }

    public void sendMessage(string msg) {
        myChats[mainChat].SendMessage(m_name, msg);
    }

    public void createNewChatWith(string nickName) {
        List<Chatter> allChatters = new List<Chatter>();
        Chatter searchedChatter = null;
        foreach (Chatter chatter in Chatter.ActiveChatters().Values)
            allChatters.Add(chatter);
        foreach (Chatter chatter in allChatters)
            if (chatter.Name.Equals(nickName))
                searchedChatter = chatter;
        if (searchedChatter != null) {
            Chat chat = Chat.getNewChat();
            Join(chat);
            searchedChatter.Join(chat);
            mainChat = myChats.Count - 1;
        }
    }

    public void inviteToChat(string nickName)
    {
        List<Chatter> allChatters = new List<Chatter>();
        Chatter searchedChatter = null;
        foreach (Chatter chatter in Chatter.ActiveChatters().Values)
            allChatters.Add(chatter);
        foreach (Chatter chatter in allChatters)
            if (chatter.Name.Equals(nickName))
                searchedChatter = chatter;
        if (searchedChatter != null)
        {
            searchedChatter.Join(MainChat);
        }
    }

    public void changeRoom() {
        mainChat++;
        if (mainChat >= myChats.Count)
            mainChat = 0;
        Chat newChat = myChats[mainChat];
    }






}
