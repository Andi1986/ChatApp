using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {
    public partial class _Register : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            DBConnectionHelper.Init(Server.MapPath("DB/Database.mdb"));
            ErrorLabel.Visible = false;
        }


        protected void EnterButton_Click(object sender, EventArgs e) {
            if (!ValidateData()) {
                ErrorLabelUpdatePanel.Update();
                return;
            }

            String username = UsernameBox.Text;
            String email = EmailBox.Text;
            String pw1 = PasswordBox1.Text;

            List<Record> list = DBConnectionHelper.ReadUserRecords();
            foreach (Record record in list) {
                if (record.Entries[DBConnectionHelper._columnName].ToLower() == username.ToLower()) {
                    ErrorLabel.Text = "Username not available";
                    ErrorLabel.Visible = true;
                    ErrorLabelUpdatePanel.Update();
                    return;
                }
            }

            String pwHash = FormsAuthentication.HashPasswordForStoringInConfigFile(pw1, "md5");
            Guid guid = Guid.NewGuid();

            String sql = DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser,
                            new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                                new String[] {username,
                                pwHash,
                                email,
                                guid.ToString()});

            DBConnectionHelper.ExecuteNonQuery(sql);

            Thread.Sleep(1000);

            list = DBConnectionHelper.ReadUserRecords();
            Record userRecord = null;
            foreach (Record record in list) {
                if (record.Entries[DBConnectionHelper._columnName] == username) {
                    userRecord = record;
                    break;
                }
            }
            //Guid guid = Guid.NewGuid();
            Session["Username"] = userRecord.Entries[DBConnectionHelper._columnName];
            Session["Guid"] = guid;
            List<Chatter> chatters = ((List<Chatter>)Application.Get("Chatters"));
            Chatter chatter = new Chatter(guid, userRecord.Entries[DBConnectionHelper._columnName]);
            chatter.intId = Convert.ToInt32(userRecord.Entries["ID"]);
            chatter.email = userRecord.Entries[DBConnectionHelper._columnEmail];
            chatter.buddyList = DBConnectionHelper.ReadBuddiesFromUser(chatter.intId);
            foreach (int i in chatter.buddyList) {
                foreach (Record record in list) {
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
            chatter.Join(Chat.ActiveChats()[0]);
            Application.Add("Chatters", chatters);

            Response.Redirect("Chat.aspx");

        }

        private bool ValidateData() {
            String username = UsernameBox.Text;
            String email = EmailBox.Text;
            String pw1 = PasswordBox1.Text;
            String pw2 = PasswordBox2.Text;

            if (String.IsNullOrWhiteSpace(username) ||
                String.IsNullOrWhiteSpace(email) ||
                String.IsNullOrWhiteSpace(pw1) ||
                String.IsNullOrWhiteSpace(pw2)) {

                ErrorLabel.Text = "You have to fill out every field!";
                ErrorLabel.Visible = true;
                return false;
            }

            if (username.Length < 3) {
                ErrorLabel.Text = "Username must have at least 3 characters";
                ErrorLabel.Visible = true;
                return false;
            }

            if (pw1 != pw2) {
                ErrorLabel.Text = "Passwords do not match!";
                ErrorLabel.Visible = true;
                return false;
            }

            ErrorLabel.Visible = false;
            return true;
        }

    }
}