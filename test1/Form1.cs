using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;


namespace test1
{
    public partial class Form1 : Form
    {
        public struct User
        {
            public string name;
            public int age;

            public User(string name, int age)
            {
                this.name = name;
                this.age = age;

            }
        }
        List <User> users =new List <User>();


        public struct NewUser
        {
            public string name;
            public int age;

            public NewUser(string name, int age)
            {
                this.name = name;
                this.age = age;

            }
        }
        List<NewUser> newusers = new List<NewUser>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            users.Add(new User("alex", 13));
            users.Add(new User("misha", 12));
            users.Add(new User("arsen", 9));
            users.Add(new User("ferz", 14));
            users.Add(new User("rus", 5));
            users.Add(new User("zsheka", 12));
            users.Add(new User("rail", 7));
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("age", typeof(int));
            for (int i = 0; i < users.Count; i++)
            {
                dataTable.Rows.Add(users[i].name, users[i].age);
            }
            dataGridView1.DataSource = dataTable;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                newusers.Add(new NewUser(dataGridView1[0,i].Value.ToString(),Convert.ToInt32(dataGridView1[1,i].Value.ToString())));
            }
            FileStream fs = new FileStream("input.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for(int i=0; i < newusers.Count; i++)
            {
                sw.WriteLine(newusers[i].name + " " + newusers[i].age);
            }
            sw.Close();
        }
        
    }
}
