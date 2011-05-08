using System;
using System.Collections.Generic;
using System.Web;


public class Chatter : IComparable {
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

    public List<Chat> myChats = new List<Chat>();
    public List<Chatter> myBuddies = new List<Chatter>();
    public List<int> buddyList { get; set; }

    public int mainChat;

    public Chat MainChat {
        get { return myChats[mainChat]; }
    }

    public Chatter(Guid id, string name) {
        m_id = id;
        m_name = name;
        mainChat = 0;
    }

    public void Join(Chat chat) {
        if (!myChats.Contains(chat)) {
            chat.join(this);
            myChats.Add(chat);
            chat.SendMessage("User [b]" + m_name + "[/b] has joined the Chat");
        }
    }

    public void Leave(Chat chat) {
        if (!chat.Equals(myChats[0])) {
            chat.leave(this);
            myChats.Remove(chat);
            chat.SendMessage("User [b]" + m_name + "[/b] left the Chat Room");
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
            chat.SendMessage("User [b]" + m_name + "[/b] left the Chat Room");
        }
    }

    public void sendMessage(string msg) {
        myChats[mainChat].SendMessage(m_name, msg);
    }

    public void createNewChatWith(string[] nickNames) {
        List<Chatter> allChatters = new List<Chatter>();
        List<Chatter> searchedChatters = new List<Chatter>();
        foreach (Chatter chatter in Chatter.ActiveChatters().Values)
            allChatters.Add(chatter);
        foreach (string nickName in nickNames) {
            foreach (Chatter chatter in allChatters)
                if (chatter.Name.Equals(nickName))
                    searchedChatters.Add(chatter);
        }

        Chat chat = null;
        if (searchedChatters.Count > 0) {
            chat = Chat.getNewChat();
            String messageMask = "User [b]{0}[/b] created a new Chatroom with {1}";
            String chatUsers = "";
            for (int i = 0; i < searchedChatters.Count; i++) {
                chatUsers += searchedChatters[i].Name;
                if (i < searchedChatters.Count - 1)
                    chatUsers += ", ";
            }
            chat.SendMessageTo(
                         String.Format(messageMask, Name,
                                      chatUsers), intId);
            foreach (Chatter searchedChatter in searchedChatters) {
                chat.SendMessageTo(
                          String.Format(messageMask, Name,
                                       chatUsers), searchedChatter.intId);

                for (int i = 0; i < searchedChatter.myChats.Count; i++) {
                    searchedChatter.myChats[i].SendMessageTo(
                          String.Format(messageMask, Name,
                                       chatUsers), searchedChatter.intId);
                }
            }

        }

        if (searchedChatters.Count > 0) {

            Join(chat);
            foreach (Chatter searchedChatter in searchedChatters) {
                searchedChatter.Join(chat);
            }
            mainChat = myChats.Count - 1;
        }
    }

    public void inviteToChat(string nickName) {
        List<Chatter> allChatters = new List<Chatter>();
        Chatter searchedChatter = null;
        foreach (Chatter chatter in Chatter.ActiveChatters().Values)
            allChatters.Add(chatter);
        foreach (Chatter chatter in allChatters)
            if (chatter.Name.Equals(nickName))
                searchedChatter = chatter;
        if (searchedChatter != null) {
            searchedChatter.Join(MainChat);
        }
    }

    public void changeRoom() {
        mainChat++;
        if (mainChat >= myChats.Count)
            mainChat = 0;
        Chat newChat = myChats[mainChat];
    }

    public void changeRoom(int index) {
        if (index >= 0 && index < myChats.Count)
            mainChat = index;
        else
            mainChat = 0;
    }

    public int CompareTo(object obj) {
        Chatter o = (Chatter)obj;
        return (Name + Id.ToString()).CompareTo(o.Name + o.Id.ToString());
    }

    public bool hasRoomUpdated(int index)
    {
        if (index >= 0 && index < myChats.Count)
            return myChats[index].newUpdates(intId);
        return false;
    }

    public bool newUpdates()
    {
        foreach(Chat chat in myChats)
            if(chat.newUpdates(intId))
                return true;
        return false;
    }
}
