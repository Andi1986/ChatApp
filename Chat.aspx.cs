using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Chat : System.Web.UI.Page
    {
        private Chat m_chat = Chat.ActiveChats()[0];
        private Chatter m_chatter = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid guid = new Guid();
            if (Session["Guid"] != null)
            {
                guid = (Guid)Session["Guid"];
                try { m_chatter = Chatter.ActiveChatters()[guid]; }
                catch { Response.Redirect("Default.aspx"); }
                _UpdateChatterList();
                _UpdateChatMessageList();
            }
            else
                Response.Redirect("Default.aspx");
        }

        private void _UpdateChatterList()
        {
            List<string> chatters = new List<string>();
            foreach (Chatter chatter in m_chat.Chatters)
            {
                if (!chatter.Name.Equals(m_chatter.Name))
                    chatters.Add(chatter.Name);
            }


            ChattersBulletedList.DataSource = chatters.DefaultIfEmpty("You're alone here!");
            ChattersBulletedList.DataBind();

            /*
            ChattersBulletedList.DataSource = m_chat.Chatters;
            ChattersBulletedList.DataTextField = "Name";
            ChattersBulletedList.DataBind();*/
        }

        private void _UpdateChatMessageList()
        {
            ChatMessageList.DataSource = m_chat.Messages;
            ChatMessageList.DataBind();
        }


        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NewMessageTextBox.Text))
            {
                string messageSent = m_chat.SendMessage(m_chatter, NewMessageTextBox.Text);
            }
            NewMessageTextBox.Text = "";
            TextBoxUpdatePanel.Update();
            _UpdateChatterList();
            _UpdateChatMessageList();
        }

        protected void LeaveButton_Click(object sender, EventArgs e)
        {
            List<Chatter> chatters = (List<Chatter>)Application.Get("Chatters");
            Chat chat = Chat.ActiveChats()[0];
            Guid guid = (Guid)Session["Guid"];
            Chatter chatter = null;
            foreach (Chatter _chatter in chatters)
            {
                if (_chatter.Id.Equals(guid))
                    chatter = _chatter;
            }
            if (chatter != null)
            {
                chatters.Remove(chatter);
                chatter.Leave(chat);
            }
            Application.Add("Chatters", chatters);

            chat.SendMessage("User " + chatter.Name + " left the Chat Room");

            Response.Redirect("Default.aspx");
        }


    }
}
