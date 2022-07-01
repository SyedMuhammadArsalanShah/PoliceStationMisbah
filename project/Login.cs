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

namespace project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DLBFHJF;Initial Catalog=policestation;Integrated Security=True");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-1SQ72LC;Initial Catalog=policestation;Integrated Security=True");


        public static string OffName;
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            {
                if (RoleCb.SelectedIndex == -1)
                {

                    MessageBox.Show("Select a Role !!!");
                }
                else if (RoleCb.SelectedIndex == 0)
                {
                    //admin selected
                    if (UnameTb.Text == "" || PasswordTb.Text == "")
                    {
                        MessageBox.Show("Enter both admin name and password");
                    }

                    else if (UnameTb.Text == "Admin" && PasswordTb.Text == "Password")
                    {

                        Polices Obj = new Polices();

                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong admin name or password!!!");
                        UnameTb.Text = "";
                        PasswordTb.Text = "";
                    }
                }

                else
                {
                    Con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from policetb1 where EmpName ='" + UnameTb.Text + "' and EmpPass='" + PasswordTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        OffName = UnameTb.Text;
                        Criminals obj = new Criminals();
                        obj.Show();
                        this.Hide();
                        Con.Close();
                    }
                   
                    else
                    {
                        MessageBox.Show("Wrong Officer name or password");
                        UnameTb.Text = "";
                        PasswordTb.Text = "";
                    }
                    Con.Close();
                }

            }
        }
    }
    }
