using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {
    public partial class _Chat : System.Web.UI.Page {
        private Chat m_chat;
        private Chatter m_chatter;

        private static object m_lock = new object();

        protected void Page_Load(object sender, EventArgs e) {

            Guid guid = new Guid();
            if (Session["Guid"] != null) {
                guid = (Guid)Session["Guid"];
                try { m_chatter = Chatter.ActiveChatters()[guid]; } catch { Response.Redirect("Default.aspx"); }
                m_chat = m_chatter.MainChat;

                _UpdateChatterList();
                _UpdateChatMessageList();
                WelcomeLabel.Text = "Hallo " + m_chatter.Name;
                if (m_chatter.mainChat == 0)
                    ChatRoomNameLabel.Text = "[0] Main Chatroom";
                else
                    ChatRoomNameLabel.Text = String.Format("[{0}] {1}", m_chatter.mainChat, m_chat);
            } else {
                Response.Redirect("Default.aspx");
                return;
            }

            if (IsPostBack) {
                if (m_chatter != null && m_chat != null) {
                    String n = FriendRequestId.Value;
                    if (!String.IsNullOrEmpty(n)) {
                        if (Session["PrevHiddenValue"] == null || n != Session["PrevHiddenValue"].ToString()) {
                            Session["PrevHiddenValue"] = n;

                            List<Record> userList = DBConnectionHelper.ReadUserRecords();
                            Record userRecord = null;
                            foreach (Record record in userList) {
                                if (record.Entries[DBConnectionHelper._columnName].ToLower() == n.ToLower()) {
                                    userRecord = record;
                                    break;
                                }
                            }

                            if (userRecord != null) {
                                int friendId = Convert.ToInt32(userRecord.Entries["ID"]);

                                if (!m_chatter.buddyList.Contains(friendId)) {
                                    if (DBConnectionHelper.FriendUsers(m_chatter.intId, friendId)) {
                                        m_chatter.buddyList.Add(friendId);
                                        foreach (Chatter chatter in Chatter.ActiveChatters().Values) {
                                            if (chatter.intId == friendId) {
                                                chatter.buddyList.Add(m_chatter.intId);
                                                m_chatter.myBuddies.Add(chatter);
                                                chatter.myBuddies.Add(m_chatter);
                                                updateAll();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void updateAll() {
            m_chat = m_chatter.MainChat;
            _UpdateChatterList();
            _UpdateChatMessageList();
            _UpdateAllChatter();
            m_chat.iAmUpToDate(m_chatter.intId);

            _UpdateChatRooms();
            ChatUpdatePanel.Update();
            NewMessageTextBox.Focus();
        }

        // People in Chatroom
        private void _UpdateChatterList() {
            List<string> chatters = new List<string>();
            foreach (Chatter chatter in m_chat.Chatters) {
                if (!chatter.Name.Equals(m_chatter.Name))
                    chatters.Add(chatter.Name);
                /*if (!chatter.Name.Equals(m_chatter.Name)) {
                    if (m_chatter.buddyList.Contains(chatter.intId)) {
                        chatters.Add(chatter.Name);
                        if (!m_chatter.myBuddies.Contains(chatter))
                            m_chatter.myBuddies.Add(chatter);
                    }
                }*/
            }



            ChattersBulletedList.DataSource = chatters.DefaultIfEmpty("You're alone here!");
            ChattersBulletedList.DataBind();
        }

        // Buddy List
        private void _UpdateAllChatter() {
            List<string> chatters = new List<string>();
            foreach (Chatter chatter in Chatter.ActiveChatters().Values) {
                //if (!chatter.Name.Equals(m_chatter.Name))
                //    chatters.Add(chatter.Name);

                if (!chatter.Name.Equals(m_chatter.Name)) {
                    if (m_chatter.buddyList.Contains(chatter.intId)) {
                        chatters.Add(chatter.Name);
                        if (!m_chatter.myBuddies.Contains(chatter))
                            m_chatter.myBuddies.Add(chatter);
                    }
                }
            }

            if (chatters.Count < 1)
            {
                NewChatButton.Enabled = false;
                InviteButton.Enabled = false;
            }
            else
            {
                NewChatButton.Enabled = true;
                InviteButton.Enabled = true;
            }

            ddlAllBuddys.DataSource = chatters;
            ddlAllBuddys.DataBind();
        }

        private void _UpdateChatRooms()
        {

            ChatRoomListBox.Items.Clear();

            int i = 0;
            string change = "";
            foreach (Chat chat in m_chatter.myChats)
            {
                if (m_chatter.hasRoomUpdated(i))
                    change = "! ";
                else
                    change = "";
                if (i == 0)
                    ChatRoomListBox.Items.Add(new ListItem(change + "[0] Main Chatroom", chat.Id.ToString()));
                else
                    ChatRoomListBox.Items.Add(new ListItem(String.Format(change + "[{0}] {1}", i, chat), chat.Id.ToString()));
                i++;
            }

            TextBoxUpdatePanel.Update();


        }

        private void _UpdateChatMessageList() {
            ChatMessageList.DataSource = m_chat.GetMyMessages(m_chatter.intId);
            ChatMessageList.DataBind();
        }


        protected void SendButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(NewMessageTextBox.Text)) {
                m_chatter.sendMessage(NewMessageTextBox.Text);
            }
            NewMessageTextBox.Text = "";
            TextBoxUpdatePanel.Update();
            updateAll();
        }

        protected void LogoutButton_Click(object sender, EventArgs e) {
            List<Chatter> chatters = (List<Chatter>)Application.Get("Chatters");
            Guid guid = (Guid)Session["Guid"];
            Chatter chatter = null;
            foreach (Chatter _chatter in chatters) {
                if (_chatter.Id.Equals(guid))
                    chatter = _chatter;
            }
            if (chatter != null) {
                chatters.Remove(chatter);
                chatter.LeaveAll();
            }
            Application.Add("Chatters", chatters);

            Response.Redirect("Default.aspx");
        }

        protected void ChatTextTimer_Tick(object sender, EventArgs e) {
            if (m_chatter.newUpdates())
                updateAll();
        }

        protected void NewChatButton_Click(object sender, EventArgs e) {
            string[] nickNames = CheckboxListSelections(ddlAllBuddys);
            m_chatter.createNewChatWith(nickNames);
            updateAll();
        }

        protected void InviteButton_Click(object sender, EventArgs e)
        {
            string nickName = ddlAllBuddys.SelectedValue;
            if(!nickName.Equals(""))
                m_chatter.inviteToChat(nickName);
        }

        protected void LeaveButton_Click(object sender, EventArgs e) {
            m_chatter.Leave(m_chat);
            updateAll();
        }

        private string[] CheckboxListSelections(System.Web.UI.WebControls.CheckBoxList list) {
            List<String> values = new List<String>();
            for (int counter = 0; counter < list.Items.Count; counter++) {
                if (list.Items[counter].Selected) {
                    values.Add(list.Items[counter].Value);
                }
            }
            return values.ToArray();
        }

        protected void ChatRoomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChatRoomListBox.SelectedIndex >= 0)
                m_chatter.changeRoom(ChatRoomListBox.SelectedIndex);
            updateAll();
        }




    }
}
