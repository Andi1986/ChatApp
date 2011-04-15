using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EnterButton_Click(object sender, EventArgs e) {
            String user = TextBox1.Text;
            Guid guid  = Guid.NewGuid();
            Session["Username"] = user;
            Session["Guid"] = guid;
            List<Chatter> chatters = ((List<Chatter>)Application.Get("Chatters"));
            Chatter chatter = new Chatter(guid, user);
            chatters.Add(chatter);
            chatter.Join(Chat.ActiveChats()[0]);
            Application.Add("Chatters",chatters);
            Chat.ActiveChats()[0].SendMessage("User " + chatter.Name + " has joined the Chat");

            Response.Redirect("Chat.aspx");
        }
    }
}