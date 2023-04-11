using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proxy.Class1;

namespace Proxy
{
    public partial class Form1 : Form
    {
        private User _user;
        private IDatabase _database;
        private TextBox txtData;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ініціалізація користувача та бази даних
            _user = new User("username", "password");
            _database = new DatabaseProxy(_user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // отримання даних з бази даних та відображення їх у текстовому полі
                List<string> data = _database.GetData();
                txtData.Text = string.Join(", ", data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // збереження даних у базу даних
                _database.SaveData(txtData.Text);
                MessageBox.Show("Data saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

