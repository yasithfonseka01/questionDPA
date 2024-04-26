using System;
using System.IO;
using System.Windows.Forms;

namespace Who_Wants_To_Be_A_Millionaire
{
    public partial class UserID : Form
    {
        public int uid { get; set; }
        int userid;
        public UserID()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            String idn = id.Text;
            uid = Convert.ToInt32(idn);

            StreamWriter ws = new StreamWriter("uid.txt");
            ws.WriteLine(id.Text);
            ws.Close();

            DatabaseHelper obj = new DatabaseHelper();
            MainWindow usrId = new MainWindow();
            obj.usrId = uid;
            usrId.uid = int.Parse(id.Text);
            usrId.Show();
            this.Dispose();

        }
    }
}
