using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;

public class Chat {
    private Guid m_id;

    public Guid Id {
        get { return m_id; }
    }

    public struct ChatMessageLine {
        public String Message;
        public int id;
    }

    private List<ChatMessageLine> m_messages = new List<ChatMessageLine>();

    public List<ChatMessageLine> AllMessages {
        get { return m_messages; }
    }

    public List<String> GetMyMessages(int id) {
        List<String> customList = new List<String>();
        lock (typeof(Chat)) {
            for (int i = 0; i < AllMessages.Count; i++) {
                ChatMessageLine line = AllMessages[i];
                if (line.id == -1 || line.id == id)
                    customList.Add(line.Message);
            }
        }
        return customList;
    }

    private Dictionary<Chatter, bool> upToDate = new Dictionary<Chatter, bool>();

    private List<Chatter> m_chatters = new List<Chatter>();

    public void join(Chatter chatter) {
        m_chatters.Add(chatter);
        upToDate.Add(chatter, false);
        resetUpToDate();
    }

    public void leave(Chatter chatter) {
        m_chatters.Remove(chatter);
        upToDate.Remove(chatter);
        if (m_chatters.Count == 0)
            Chat.removeChat(this);
    }

    public List<Chatter> Chatters {
        get { return m_chatters; }
        //set { m_chatters = value; }
    }

    public static ReadOnlyCollection<Chat> ActiveChats() {
        if (HttpContext.Current.Application["Chats"] != null) {
            List<Chat> chats = ((List<Chat>)HttpContext.Current.Application["Chats"]);
            return new ReadOnlyCollection<Chat>(chats);
        } else {
            return new ReadOnlyCollection<Chat>(new List<Chat>());
        }
    }

    public static Chat getNewChat() {
        lock (typeof(Chat)) {
            Chat chat = new Chat();
            List<Chat> chats = ((List<Chat>)HttpContext.Current.Application["Chats"]);
            chats.Add(chat);
            HttpContext.Current.Application["Chats"] = chats;
            return chat;
        }
    }

    public static void removeChat(Chat chat) {
        lock (typeof(Chat)) {
            List<Chat> chats = ((List<Chat>)HttpContext.Current.Application["Chats"]);
            if (!chat.Equals(chats[0])) {
                chats.Remove(chat);
                HttpContext.Current.Application["Chats"] = chats;
            }
        }
    }

    public string SendMessage(string name, string message) {
        string messageMask = "[{0}] {1} : {2}";
        message.Replace("<", "-");
        message.Replace(">", "-");
        message = string.Format(messageMask, DateTime.Now.ToString("t"), name, message);
        lock (typeof(Chat)) {
            m_messages.Add(new ChatMessageLine { id = -1, Message = message });
        }
        resetUpToDate();
        return message;
    }

    public string SendMessage(String message) {
        string messageMask = "{0} : {1}";
        message = string.Format(messageMask, DateTime.Now.ToString(), message);
        message = "[i]" + message + "[/i]";
        lock (typeof(Chat)) {
            m_messages.Add(new ChatMessageLine { id = -1, Message = message });
        }
        resetUpToDate();
        return message;
    }

    public string SendMessageTo(String message, int id)
    {
        string messageMask = "{0} : {1}";
        message = string.Format(messageMask, DateTime.Now.ToString(), message);
        message = "[i]" + message + "[/i]";
        lock (typeof(Chat)) {
            m_messages.Add(new ChatMessageLine { id = id, Message = message });
        }
        resetUpToDate();
        return message;
    }

    public string SendMessageTo(String name, String message, int id)
    {
        string messageMask = "[{0}] Whisper from {1} : {2}";
        message.Replace("<", "-");
        message.Replace(">", "-");
        message = string.Format(messageMask, DateTime.Now.ToString("t"), name, message);
        lock (typeof(Chat)) {
            m_messages.Add(new ChatMessageLine { id = id, Message = message });
        }
        resetUpToDate();
        return message;
    }

    public Chat() {
        m_id = Guid.NewGuid();
    }

    private void resetUpToDate() {
        List<Chatter> chatters = new List<Chatter>();
        foreach (Chatter chatter in upToDate.Keys)
            chatters.Add(chatter);
        foreach (Chatter chatter in chatters)
            upToDate[chatter] = false;
    }

    public bool newUpdates(Chatter chatter) {
        bool noUpdate = false;
        upToDate.TryGetValue(chatter, out noUpdate);
        bool returnValue = !noUpdate;
        upToDate[chatter] = true;
        return returnValue;
    }

    public override string ToString() {
        String tmp = "";
        for (int i = 0; i < Chatters.Count; i++) {
            tmp += Chatters[i].Name;
            if (i < Chatters.Count - 1)
                tmp += ", ";
        }
        if (String.IsNullOrWhiteSpace(tmp))
            return "Empty Chat";

        return tmp;

    }
}