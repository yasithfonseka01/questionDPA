using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace Who_Wants_To_Be_A_Millionaire
{
    public class DatabaseHelper
    {
        //private int uid;
        public int usrId { get; set; }
        private OleDbConnection connection = null;
        int userid;

        public DatabaseHelper()
        {
         

        }

        // Open Connection
        private SQLiteConnection connect()
        {
            // Create a new database connection:
            SQLiteConnection connection = new SQLiteConnection("Data Source=questionsDatabase.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return connection;
        }


        // Import N number of question from database
        public SQLiteDataReader importNQuestions(int n)
        {
            StreamReader ws = new StreamReader("uid.txt");
            String line = ws.ReadToEnd();
            usrId = Convert.ToInt32(line);
            ws.Close();
            // Connect to database & create command
            SQLiteConnection connection = connect();
            SQLiteCommand command = connection.CreateCommand();
            //Manually 
            //int num = 2;
            //command.CommandText = "SELECT * FROM Question WHERE UID='" + num + "'";
            // Set Query and execute
            command.CommandText = "SELECT * FROM Question WHERE UID='"+ usrId + "' AND ID IN (SELECT ID FROM Question ORDER BY RANDOM())";
            //command.CommandText = "SELECT * FROM Question WHERE ID IN (SELECT ID FROM Question ORDER BY RANDOM() LIMIT " + n + ")";
            SQLiteDataReader dataReader = command.ExecuteReader();
            
            //Disconnect and return data from database
            disconnect();
            return dataReader;

        }

        public void pass()
        {
            QuestionBank tt = new QuestionBank();
            tt.usrIdl = usrId;
        }


        // If Connection Is Not Open
        private void disconnect()
        {
            if (connection != null && connection.State == ConnectionState.Open) connection.Close();
        }
    }
}