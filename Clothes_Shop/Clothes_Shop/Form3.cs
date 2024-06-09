using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Clothes_Shop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1object = new Form1();
            form1object.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String name = textBox1.Text;
                String phonenumber = textBox2.Text;
                String address = textBox3.Text;
                var query = "INSERT INTO tbl_Customers (Name,Phonenumber,Address)" +
                    " VALUES (N'" + name + "','" + phonenumber + "',N'" + address + "')";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");
                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("انجام شد");
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                    refresh();
                }

                else
                {
                    MessageBox.Show("انجام نشد");
                }

                sc.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erorr" + ex.Message);
            }


           

        }
        void refresh()
        {

            try
            {
                comboBox1.Items.Clear();

                var query = "SELECT * FROM tbl_Customers";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Id"] + ". نام: " + dr["Name"] + " | شماره تماس: " + dr["Phonenumber"] + " | آدرس: " + dr["Address"]);
                }

                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            refresh();

            button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf("."));

            try
            {
                var query = "DELETE FROM tbl_Customers WHERE Id='" + id + "'";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("حذف انجام شد");
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                    refresh();
                }
                else
                {
                    MessageBox.Show("حذف انجام نشد");
                }


                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf("."));

            try
            {
                var query = "SELECT * FROM tbl_Customers WHERE Id='" + id + "'";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                var dr = cmd.ExecuteReader();

                dr.Read();
                textBox1.Text = dr["Name"].ToString();
                textBox2.Text = dr["Phonenumber"].ToString();
                textBox3.Text = dr["Address"].ToString();
                button3.Enabled = false;
                button4.Enabled = true;

                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf("."));

            try
            {
                string name = textBox1.Text;
                string phonenumbere = textBox2.Text;
                string address = textBox3.Text;
                var query = "UPDATE tbl_Customers SET Name=N'" + name + "',Phonenumber='" + phonenumbere + "',Address='" + address + "' WHERE Id='" + id + "'";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("انجام شد");
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                    refresh();
                }
                else
                {
                    MessageBox.Show("انجام نشد");
                }


                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }


    }
}








