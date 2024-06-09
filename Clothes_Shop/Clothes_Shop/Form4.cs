using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Clothes_Shop
{
    public partial class Form4 : Form
    {
        int price;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1object = new Form1();
            form1object.Show();
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
                    comboBox1.Items.Add(dr["Id"] + ". نام: " + dr["Name"] + " | تعداد: " + dr["Count"] + " | قیمت: " + dr["Price"]);
                }

                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf("."));

            try
            {
                var query = "UPDATE tbl_prodoct SET Discount='0' WHERE Id='" + id + "'";

                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("تخفیف برداشته شد");
                    textBox2.Text = textBox3.Text = "";
                    refresh();
                }
                else
                {
                    MessageBox.Show("حذف تخفیف انجام نشد");
                }


                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int off = int.Parse(textBox3.Text);
            int finalPrice=price- ((off * price) / 100);
            string id = comboBox1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf("."));

            try
            {
                var query = "UPDATE tbl_Prodoct SET Discount='"+off+"' ,Price='" + finalPrice + "' WHERE Id='" + id + "'";
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KATANA\\Desktop\\Clothes_Shop\\Clothes_Shop\\Database1.mdf;Integrated Security=True");

                sc.Open();

                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("تخفیف اعمال شد");
                    textBox2.Text = textBox3.Text = "";
                    refresh();
                }
                else
                {
                    MessageBox.Show("تخفیف اعمال نشد");
                }


                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                textBox2.Text = dr["Name"].ToString();
                textBox3.Text = dr["Discount"].ToString();
                price = int.Parse(dr["Price"].ToString());

                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}         
