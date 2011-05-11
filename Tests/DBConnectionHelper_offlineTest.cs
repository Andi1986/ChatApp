using System;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;

namespace Tests {
    [TestClass]
    public class DBConnectionHelper_offlineTest {

        [TestInitialize]
        public void Setup()
        {
            /*ConfigurationManager.OpenExeConfiguration(_ProjectPath.projectPath + "\\Web.config");
            Thread.Sleep(1000);
            ConfigurationManager.RefreshSection("appSettings");
            foreach (String item in ConfigurationManager.AppSettings.AllKeys) {
                String value =  ConfigurationManager.AppSettings[item];
            }
            */
            DBConnectionHelper.Init(_ProjectPath.projectPath + @"\DB\Database_Test.mdb");
            DBConnectionHelper._columnBuddyBuddy = "CUser";
            DBConnectionHelper._columnBuddyUser = "CBuddy";
            DBConnectionHelper._columnEmail = "CEmail";
            DBConnectionHelper._columnGuid = "CGuid";
            DBConnectionHelper._columnName = "CName";
            DBConnectionHelper._columPasword = "CPassword";
            DBConnectionHelper._tableBuddy = "TBuddies";
            DBConnectionHelper._tableUser = "TUsers";
            DBConnectionHelper.ClearTable(DBConnectionHelper._tableBuddy);
            DBConnectionHelper.ClearTable(DBConnectionHelper._tableUser);
        }

        [TestCleanup]
        public void Teardown() {
            DBConnectionHelper.ClearTable(DBConnectionHelper._tableBuddy);
            DBConnectionHelper.ClearTable(DBConnectionHelper._tableUser);
        }

        [TestMethod]
        public void ExecuteNonQueryTest() {
            string sql = "INSERT INTO TUsers (CName, CPassword, CEmail, CGuid) VALUES ('Testname', 'Testpassword', 'Testemail', 'Testguid')";
            DBConnectionHelper.ExecuteNonQuery(sql);
            List<Record> list = DBConnectionHelper.ReadUserRecords();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Testname", list[0].Entries[DBConnectionHelper._columnName]);
            Assert.AreEqual("Testpassword", list[0].Entries[DBConnectionHelper._columPasword]);
            Assert.AreEqual("Testemail", list[0].Entries[DBConnectionHelper._columnEmail]);
            Assert.AreEqual("Testguid", list[0].Entries[DBConnectionHelper._columnGuid]);

            sql = "DELETE FROM TUsers WHERE ID=" + list[0].Entries["ID"];
            DBConnectionHelper.ExecuteNonQuery(sql);
            list = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void FriendUsersTest() {

            for (int i = 0; i < 2; i++) {
                DBConnectionHelper.ExecuteNonQuery(DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser, new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                             new String[] {"Username" + i.ToString("00"),
                                "Password"+ i.ToString("00"),
                                "email"+ i.ToString("00")+"@mail.de",
                               Guid.NewGuid().ToString()}));
            }
            Thread.Sleep(1000);

            List<Record> list = DBConnectionHelper.ReadUserRecords();
            int userID1 = Convert.ToInt32(list[0].Entries["ID"]);
            int userID2 = Convert.ToInt32(list[1].Entries["ID"]);
            bool re = DBConnectionHelper.FriendUsers(userID1, userID2);
            Assert.AreEqual(true, re);
            List<int> actual = DBConnectionHelper.ReadBuddiesFromUser(userID1);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(userID2, actual[0]);

            actual = DBConnectionHelper.ReadBuddiesFromUser(userID2);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(userID1, actual[0]);
        }


        [TestMethod]
        public void MakeSQLInsertQueryTest() {
            string table = "TUsers";
            string[] columns = { "Name", "Password", "Email" };
            string[] values = { "Testname", "Testpassword", "Testemail" };
            string expected = "INSERT INTO TUsers (Name, Password, Email) VALUES ('Testname', 'Testpassword', 'Testemail')";
            string actual;
            actual = DBConnectionHelper.MakeSQLInsertQuery(table, columns, values);
            Assert.AreEqual(expected, actual);
            table = "TUsers";
            columns = new string[] { "Name" };
            values = new string[] { "Testname" };
            expected = "INSERT INTO TUsers (Name) VALUES ('Testname')";
            actual = DBConnectionHelper.MakeSQLInsertQuery(table, columns, values);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadBuddiesFromUserTest() {
            int id = 1;
            int expected = 0;
            List<int> actual;
            actual = DBConnectionHelper.ReadBuddiesFromUser(id);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Count);

            int count = 3;
            for (int i = 0; i < count; i++) {
                DBConnectionHelper.ExecuteNonQuery(DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser, new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                             new String[] {"Username" + i.ToString("00"),
                                "Password"+ i.ToString("00"),
                                "email"+ i.ToString("00")+"@mail.de",
                               Guid.NewGuid().ToString()}));
            }
            Thread.Sleep(1000);

            List<Record> list = DBConnectionHelper.ReadUserRecords();
            for (int i = 0; i < count - 1; i++) {
                DBConnectionHelper.FriendUsers(Convert.ToInt32(list[0].Entries["ID"]),
                               Convert.ToInt32(list[i + 1].Entries["ID"]));
            }


            actual = DBConnectionHelper.ReadBuddiesFromUser(Convert.ToInt32(list[0].Entries["ID"]));
            for (int i = 0; i < count - 1; i++) {
                Assert.IsTrue(actual.Contains(Convert.ToInt32(list[i + 1].Entries["ID"])), "Expected ID " + list[i + 1].Entries["ID"] + " not found");
            }

            Assert.AreEqual(count - 1, actual.Count);
        }

        [TestMethod]
        public void ReadUserRecordsTest() {
            int expected = 0; // 
            List<Record> actual;
            actual = DBConnectionHelper.ReadUserRecords();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Count);

            int count = 3;
            for (int i = 0; i < count; i++) {
                DBConnectionHelper.ExecuteNonQuery(DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser, new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                             new String[] {"Username" + i.ToString("00"),
                                "Password"+ i.ToString("00"),
                                "email"+ i.ToString("00")+"@mail.de",
                               Guid.NewGuid().ToString()}));
            }
            Thread.Sleep(1000);
            actual = DBConnectionHelper.ReadUserRecords();
            Assert.IsNotNull(actual);
            Assert.AreEqual(count, actual.Count);

            for (int i = 0; i < count; i++) {
                Record record = actual[i];

                Assert.AreEqual("Username" + i.ToString("00"), record.Entries[DBConnectionHelper._columnName]);
                Assert.AreEqual("Password" + i.ToString("00"), record.Entries[DBConnectionHelper._columPasword]);
                Assert.AreEqual("email" + i.ToString("00") + "@mail.de", record.Entries[DBConnectionHelper._columnEmail]);
            }


        }

        [TestMethod]
        public void MakeSQLDeleteQueryTest() {
            string table = "Users";
            string[] key = { "CUsers", "CBuddy" };
            string[] value = { "20", "21" };
            string expected = "DELETE FROM Users WHERE CUsers=20 AND CBuddy=21";
            string actual;
            actual = DBConnectionHelper.MakeSQLDeleteQuery(table, key, value);
            Assert.AreEqual(expected, actual);

            table = "Users";
            key = new string[] { "CUsers" };
            value = new string[] { "20" };
            expected = "DELETE FROM Users WHERE CUsers=20";
            actual = DBConnectionHelper.MakeSQLDeleteQuery(table, key, value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnfriendUsersTest() {
            FriendUsersTest();
            List<Record> list = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(2, list.Count);

            int userID1 = Convert.ToInt32(list[0].Entries["ID"]);
            int userID2 = Convert.ToInt32(list[1].Entries["ID"]);

            bool actual = DBConnectionHelper.UnfriendUsers(userID1, userID2);
            Assert.AreEqual(true, actual);

            list = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(2, list.Count);

            List<int> buddies = DBConnectionHelper.ReadBuddiesFromUser(userID1);
            Assert.AreEqual(0, buddies.Count);
            buddies = DBConnectionHelper.ReadBuddiesFromUser(userID2);
            Assert.AreEqual(0, buddies.Count);

        }


        [TestMethod]
        public void ClearTableTest() {
            DBConnectionHelper.Init(_ProjectPath.projectPath + @"\DB\Database_Test.mdb");
            string table = DBConnectionHelper._tableBuddy;
            DBConnectionHelper.ClearTable(table);
            Thread.Sleep(1000);
            List<Record> list = DBConnectionHelper.ReadUserRecords();
            int before = list.Count;
            if (before == 0) {
                DBConnectionHelper.ExecuteNonQuery(DBConnectionHelper.MakeSQLInsertQuery(DBConnectionHelper._tableUser, new String[]{DBConnectionHelper._columnName,
                                DBConnectionHelper._columPasword,
                                DBConnectionHelper._columnEmail,
                                DBConnectionHelper._columnGuid},
                                new String[] {"Username",
                                "Password",
                                "email@mail.de",
                               Guid.NewGuid().ToString()}));
                Thread.Sleep(1000);
                before = (list = DBConnectionHelper.ReadUserRecords()).Count;
            }
            Assert.IsTrue(before > 0, "No entries in table");

            table = DBConnectionHelper._tableUser;
            DBConnectionHelper.ClearTable(table);
            Thread.Sleep(1000);
            int after = (list = DBConnectionHelper.ReadUserRecords()).Count;
            Assert.AreEqual(0, after);
        }



        [TestMethod]
        public void DeleteUserTest() {
            FriendUsersTest();
            List<Record> list = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(2, list.Count);

            int id = Convert.ToInt32(list[0].Entries["ID"]);
            bool actual = DBConnectionHelper.DeleteUser(id);
            Assert.AreEqual(true, actual);
            list = DBConnectionHelper.ReadUserRecords();
            Assert.AreEqual(1, list.Count);

            id = Convert.ToInt32(list[0].Entries["ID"]);
            List<int> buddies = DBConnectionHelper.ReadBuddiesFromUser(id);
            Assert.AreEqual(0, buddies.Count);
        }
    }
}
