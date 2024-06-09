using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothes_Shop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1object = new Form1();
            form1object.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string count = textBox3.Text;
                string price = textBox4.Text;
                var query = "INSERT INTO tbl_Prodoct (Name,Count,Price)" +
                    " VALUES (N'" + name + "','" + count + "','" + price + "')";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();

                if (i>0)
                {
                    MessageBox.Show("انجام شد");
                    textBox1.Text = textBox3.Text = textBox4.Text = "";
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
                MessageBox.Show("Error "+ex.Message);
            }
        }

        void refresh()
        {
            try
            {
                comboBox1.Items.Clear();    
                var query = "SELECT * FROM tbl_Prodoct";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (int.Parse(dr["Discount"].ToString()) > 0)
                    {

                    comboBox1.Items.Add(dr["Id"] + ". نام: " + dr["Name"] + " | تعداد: " + dr["Count"] + " | قیمت: " + dr["Price"]+ " | "+dr["Discount"]+" %");
                    }
                    else
                    {
                        comboBox1.Items.Add(dr["Id"] + ". نام: " + dr["Name"] + " | تعداد: " + dr["Count"] + " | قیمت: " + dr["Price"] );

                    }
                }

                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          refresh();
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string id= comboBox1.SelectedItem.ToString();
            id=id.Substring(0,id.IndexOf("."));

            try
            {
                var query = "DELETE FROM tbl_prodoct WHERE Id='" + id + "'";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("حذف انجام شد");
                    textBox1.Text = textBox3.Text = textBox4.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf("."));

            try
            {
                var query = "SELECT * FROM tbl_Prodoct WHERE Id='" + id + "'";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                var dr = cmd.ExecuteReader();

                dr.Read();
                textBox1.Text = dr["Name"].ToString();
                textBox3.Text = dr["Count"].ToString();
                textBox4.Text = dr["Price"].ToString();
                button4.Enabled = false;
                button3.Enabled = true;

                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf("."));

            try
            {
                string name = textBox1.Text;
                string count = textBox3.Text;
                string price = textBox4.Text;
                var query = "UPDATE tbl_Prodoct SET Name=N'" + name + "',Count='" + count + "',Price='" + price + "' WHERE Id='"+id+"'";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("انجام شد");
                    textBox1.Text = textBox3.Text = textBox4.Text = "";
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
