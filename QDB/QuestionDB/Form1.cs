using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace QuestionDB
{
    public partial class Form1 : Form
    {

        private SQLiteConnection connection;
        private string connectionString = "Data Source=C:\\Users\\Vidusha\\Downloads\\DPA\\Who Wants To Be A Millionaire\\questionsDatabase.db;Version=3;";
        public Form1()
        {
            InitializeComponent();
            connection = new SQLiteConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM Question", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Question (Question,OptionA,OptionB,OptionC,OptionD,Answer,TRIAL372) VALUES (@value1, @value2,@value3,@value4,@value5,@value6,'T')", connection))
            {
                command.Parameters.AddWithValue("@value1", textBox1.Text);
                command.Parameters.AddWithValue("@value2", textBox2.Text);
                command.Parameters.AddWithValue("@value3", textBox3.Text);
                command.Parameters.AddWithValue("@value4", textBox4.Text);
                command.Parameters.AddWithValue("@value5", textBox5.Text);
                command.Parameters.AddWithValue("@value6", textBox6.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

            using (SQLiteCommand command = new SQLiteCommand("UPDATE mytable SET column1 = @value1, column2 = @value2 WHERE id = @id", connection))
            {
                command.Parameters.AddWithValue("@value1", textBox1.Text);
                command.Parameters.AddWithValue("@value2", textBox2.Text);
                command.Parameters.AddWithValue("@id", selectedRow.Cells["id"].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

            using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Question WHERE id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", selectedRow.Cells["id"].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
