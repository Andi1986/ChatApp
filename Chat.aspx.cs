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

        protected void Page_Load(object sender, EventArgs e) {
            Guid guid = new Guid();
            if (Session["Guid"] != null) {
                guid = (Guid)Session["Guid"];
                try { m_chatter = Chatter.ActiveChatters()[guid]; } catch { Response.Redirect("Default.aspx"); }
                m_chat = m_chatter.MainChat;
                _UpdateChatterList();
                _UpdateChatMessageList();
            } else
                Response.Redirect("Default.aspx");
        }

        private void updateAll() {
            m_chat = m_chatter.MainChat;
            _UpdateChatterList();
            _UpdateChatMessageList();
            _UpdateAllChatter();

            ChatUpdatePanel.Update();
            NewMessageTextBox.Focus();
        }

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

        private void _UpdateAllChatter() {
            List<string> chatters = new List<string>();
            foreach (Chatter chatter in Chatter.ActiveChatters().Values) {
               //  if (!chatter.Name.Equals(m_chatter.Name))
               //      chatters.Add(chatter.Name);
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

        private void _UpdateChatMessageList() {
            ChatMessageList.DataSource = m_chat.Messages;
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
            if (m_chat.newUpdates(m_chatter))
                updateAll();
        }

        protected void ChangeButton_Click(object sender, EventArgs e) {
            m_chatter.changeRoom();
            updateAll();
        }

        protected void NewChatButton_Click(object sender, EventArgs e) {
            string nickName = ddlAllBuddys.SelectedValue;
            if (!nickName.Equals(""))
                m_chatter.createNewChatWith(nickName);
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




    }
}
