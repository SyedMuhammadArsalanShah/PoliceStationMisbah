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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountOfficers();
            CountCases();
            CountCriminals();
        }

        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DLBFHJF;Initial Catalog=policestation;Integrated Security=True");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-1SQ72LC;Initial Catalog=policestation;Integrated Security=True");


        private void CountOfficers()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from policetb1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            OffLb1.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountCases()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from casetb1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CaseLb1.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountCriminals()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from criminaltb1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CrimLb1.Text = dt.Rows[0][0].ToString();
            CrLb1.Text = dt.Rows[0][0].ToString()+"Arrested";
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Cases obj = new Cases();
            obj.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void CrimLb1_Click(object sender, EventArgs e)
        {

        }

        private void CaseLb1_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           Criminals obj = new Criminals();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Charges obj = new Charges();
            obj.Show();
            this.Hide();

        }
    }
}
