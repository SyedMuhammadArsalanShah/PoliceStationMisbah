using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class Criminals : Form
    {
        public Criminals()
        {
            InitializeComponent();
            ShowCriminals();
            OffNameLb1.Text = Login.OffName;
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DLBFHJF;Initial Catalog=policestation;Integrated Security=True");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-1SQ72LC;Initial Catalog=policestation;Integrated Security=True");

        private void ShowCriminals()
        {
            Con.Open();
            string Query = "Select * from criminaltb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CriminalDVG.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RecordBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || AddressTb.Text == "" || ActivityTb.Text == "")
            {
                MessageBox.Show("Missing information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into criminaltb1(CrName,CrAdd,CrActivities)values(@CN,@CA,@CrA)", Con);
                    cmd.Parameters.AddWithValue("@CN", NameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@CrA", ActivityTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Criminal Recorded");
                    Con.Close();
                    ShowCriminals();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void CriminalDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = CriminalDVG.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = CriminalDVG.SelectedRows[0].Cells[2].Value.ToString();
            ActivityTb.Text = CriminalDVG.SelectedRows[0].Cells[3].Value.ToString();

            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CriminalDVG.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || AddressTb.Text == "" || ActivityTb.Text == "")
            {
                MessageBox.Show("Missing information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update criminaltb1 Set CrName=@CN,CrAdd=@CA,CrActivities=@CrA where CrCode = @CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.Parameters.AddWithValue("@CN", NameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@CrA", ActivityTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Criminal Recorded");
                    Con.Close();
                    ShowCriminals();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Reset()
        {
            NameTb.Text = "";
            AddressTb.Text = "";
            ActivityTb.Text = "";
            Key = 0;
            
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Criminal!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from criminaltb1 where CrCode = @CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                  
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Criminal deleted");
                    Con.Close();
                    ShowCriminals();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void Criminals_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Cases obj = new Cases();
            obj.Show();
            this.Hide();
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

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }
    }
}
    

    
