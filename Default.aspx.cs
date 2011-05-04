using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {
    public partial class _Default : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            DBConnectionHelper.Init(Server.MapPath("DB/Database.mdb"));
            ErrorLabel.Visible = false;
        }

        protected void EnterButton_Click(object sender, EventArgs e) {

            String user = TextBox1.Text;
            String password = TextBox2.Text;
            if (String.IsNullOrWhiteSpace(user) || String.IsNullOrWhiteSpace(password)) {
                ErrorLabel.Text = "Please enter your username and password";
                ErrorLabel.Visible = true;
                ErrorLabelUpdatePanel.Update();
                return;
            }


            List<Record> userList = DBConnectionHelper.ReadUserRecords();
            Record userRecord = null;
            bool found = false;
            foreach (Record record in userList) {
                if (record.Entries[DBConnectionHelper._columnName].ToLower() == user.ToLower()) {
                    found = true;
                    userRecord = record;
                    break;
                }
            }

            if (!found) {
                ErrorLabel.Text = "Username not found. Please create a new user";
                ErrorLabel.Visible = true;
                ErrorLabelUpdatePanel.Update();
                return;
            }
            // ReadRecords();
            if (userRecord.Entries[DBConnectionHelper._columPasword] != FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5")) {
                ErrorLabel.Text = "Username and password do not match";
                ErrorLabel.Visible = true;
                ErrorLabelUpdatePanel.Update();
                return;
            }

            //Guid guid = Guid.NewGuid();
            Guid guid = new Guid(userRecord.Entries[DBConnectionHelper._columnGuid]);
            Session["Username"] = userRecord.Entries[DBConnectionHelper._columnName];
            Session["Guid"] = guid;
            List<Chatter> chatters = ((List<Chatter>)Application.Get("Chatters"));
            Chatter chatter = new Chatter(guid, userRecord.Entries[DBConnectionHelper._columnName]);
            chatter.intId = Convert.ToInt32(userRecord.Entries["ID"]);
            chatter.email = userRecord.Entries[DBConnectionHelper._columnEmail];
            chatter.buddyList = DBConnectionHelper.ReadBuddiesFromUser(chatter.intId);
            foreach (int i in chatter.buddyList) {
                foreach (Record record in userList) {
                    if (Convert.ToInt32(record.Entries["ID"]) == i) {
                        //Guid g = new Guid(record.Entries[DBConnectionHelper._columnGuid]);
                        foreach (Chatter c in chatters) {
                            //if (c.Id.Equals(g)) {
                            if (c.intId == Convert.ToInt32(record.Entries["ID"])) {
                                chatter.myBuddies.Add(c);
                                goto CONT;
                            }
                        }
                    }
                }
            CONT:
                continue;
            }
            chatters.Add(chatter);
            try {
                //TODO: throws exception after logging in and leaving for 2 times... 
                ReadOnlyCollection<Chat> tmp = Chat.ActiveChats();
                chatter.Join(tmp[0]);
            } catch (ArgumentOutOfRangeException x) {

            }

            Application.Add("Chatters", chatters);

            Response.Redirect("Chat.aspx");
        }

    }


}