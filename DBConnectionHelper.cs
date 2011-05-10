using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace WebApplication1 {
    public static class DBConnectionHelper {

        private static bool initialized = false;
        private static string connectionString = "";
        public static string _tableUser = "";
        public static string _columnName = "";
        public static string _columPasword = "";
        public static string _columnEmail = "";
        public static string _columnGuid = "";
        public static string _tableBuddy = "";
        public static string _columnBuddyUser = "";
        public static string _columnBuddyBuddy = "";

        public static void Init(String dbPath) {
            if (initialized)
                return;

            ConfigurationManager.RefreshSection("appSettings");
            _tableUser = ConfigurationManager.AppSettings["Table_Users"];
            _columnName = ConfigurationManager.AppSettings["Table_Users_Colum_Name"];
            _columPasword = ConfigurationManager.AppSettings["Table_Users_Colum_Password"];
            _columnEmail = ConfigurationManager.AppSettings["Table_Users_Colum_Email"];
            _columnGuid = ConfigurationManager.AppSettings["Table_Users_Colum_Guid"];
            _tableBuddy = ConfigurationManager.AppSettings["Table_Buddies"];
            _columnBuddyUser = ConfigurationManager.AppSettings["Table_Buddies_Colum_User"];
            _columnBuddyBuddy = ConfigurationManager.AppSettings["Table_Buddies_Colum_Buddy"];

            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + dbPath;

            initialized = true;
        }

        public static List<Record> ReadUserRecords() {
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            List<Record> records = new List<Record>();
            try {
                conn = new OleDbConnection(connectionString);
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("Select * FROM " + _tableUser, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Record tmp = new Record();
                    tmp.Entries.Add(reader.GetName(0), reader["ID"].ToString());
                    tmp.Entries.Add(reader.GetName(1), reader[_columnName].ToString());
                    tmp.Entries.Add(reader.GetName(2), reader[_columPasword].ToString());
                    tmp.Entries.Add(reader.GetName(3), reader[_columnEmail].ToString());
                    tmp.Entries.Add(reader.GetName(4), reader[_columnGuid].ToString());
                    records.Add(tmp);
                }

            }
                //        catch (Exception e)
                //        {
                //            Response.Write(e.Message);
                //            Response.End();
                //        }
            finally {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }
            return records;
        }

        public static List<int> ReadBuddiesFromUser(int id) {
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            List<int> buddies = new List<int>();
            try {
                conn = new OleDbConnection(connectionString);
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("Select * FROM " + _tableBuddy + " WHERE " + _columnBuddyUser + "=" + id, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    buddies.Add(Convert.ToInt32(reader[_columnBuddyBuddy]));
                }

            }
                //        catch (Exception e)
                //        {
                //            Response.Write(e.Message);
                //            Response.End();
                //        }
            finally {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }
            return buddies;
        }

        public static void ExecuteNonQuery(string sql) {
            OleDbConnection conn = null;
            try {
                conn = new OleDbConnection(connectionString);
                conn.Open();


                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
                //  catch (Exception e)
                //  {
                //      Response.Write(e.Message);
                //      Response.End();
                //  }
            finally {
                if (conn != null) conn.Close();
            }
        }

        public static bool FriendUsers(int userID1, int userID2) {
            OleDbConnection conn = null;
            bool ret = true;
            try {

                List<Record> recordList = ReadUserRecords();
                bool found1 = false;
                bool found2 = false;
                foreach (Record r in recordList) {
                    if (Convert.ToInt32(r.Entries["ID"]) == userID1)
                        found1 = true;
                    if (Convert.ToInt32(r.Entries["ID"]) == userID2)
                        found2 = true;
                }

                if (!(found1 && found2))
                    return false;

                conn = new OleDbConnection(connectionString);
                conn.Open();

                String sql = MakeSQLInsertQuery(_tableBuddy, new String[] { _columnBuddyUser, _columnBuddyBuddy }, new String[] { userID1.ToString(), userID2.ToString() });
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = MakeSQLInsertQuery(_tableBuddy, new String[] { _columnBuddyUser, _columnBuddyBuddy }, new String[] { userID2.ToString(), userID1.ToString() });
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            } catch (Exception e) {
                ret = false;
            } finally {
                if (conn != null) conn.Close();
            }
            return ret;
        }

        public static bool UnfriendUsers(int userID1, int userID2) {
            OleDbConnection conn = null;
            bool ret = true;
            try {
                List<Record> recordList = ReadUserRecords();
                bool found1 = false;
                bool found2 = false;
                foreach (Record r in recordList) {
                    if (Convert.ToInt32(r.Entries["ID"]) == userID1)
                        found1 = true;
                    if (Convert.ToInt32(r.Entries["ID"]) == userID2)
                        found2 = true;
                }

                if (!found1 || !found2)
                   return false;

                conn = new OleDbConnection(connectionString);
                conn.Open();


                String sql = MakeSQLDeleteQuery(_tableBuddy, new String[] { _columnBuddyUser, _columnBuddyBuddy }, new String[] { userID1.ToString(), userID2.ToString() });
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = MakeSQLDeleteQuery(_tableBuddy, new String[] { _columnBuddyUser, _columnBuddyBuddy }, new String[] { userID2.ToString(), userID1.ToString() });
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            } catch (Exception e) {
                ret = false;
            } finally {
                if (conn != null) conn.Close();
            }
            return ret;
        }

        public static bool DeleteUser(int id) {
            OleDbConnection conn = null;
            bool ret = true;
            try {
                List<int> recordList = ReadBuddiesFromUser(id);
                foreach (int i in recordList) {
                    UnfriendUsers(id, i);
                }

                String sql = MakeSQLDeleteQuery(_tableUser, new string[] { "ID" }, new string[] { id.ToString() });
                ExecuteNonQuery(sql);
            } catch (Exception e) {
                ret = false;
            } finally {
                if (conn != null) conn.Close();
            }
            return ret;
        }

        public static String MakeSQLInsertQuery(String table, String[] columns, String[] values) {
            String query = "INSERT INTO " + table + " (";
            for (int i = 0; i < columns.Length; i++) {
                query += columns[i];
                if (i < columns.Length - 1)
                    query += ", ";
            }
            query += ") VALUES (";
            for (int i = 0; i < values.Length; i++) {
                query += "\'" + values[i] + "\'";
                if (i < values.Length - 1)
                    query += ", ";
            }
            query += ")";

            return query;
        }

        public static String MakeSQLDeleteQuery(String table, String[] key, String[] value) {
            if (String.IsNullOrWhiteSpace(table) || key == null || key.Length == 0 || value == null || value.Length == 0)
                return null;
            if (key.Length != value.Length)
                return null;

            String query = "DELETE FROM " + table + " WHERE ";
            for (int i = 0; i < key.Length; i++) {
                if (i > 0)
                    query += " AND ";

                query += key[i] + "=" + value[i];
            }

            return query;
        }

        public static void ClearTable(String table) {
            String query = "DELETE * FROM " + table;
            ExecuteNonQuery(query);
        }
    }
}