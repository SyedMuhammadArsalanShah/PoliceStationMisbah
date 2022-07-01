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
    public partial class Cases : Form
    {
        public Cases()
        {
            InitializeComponent();
            ShowCases();
            GetCriminals();
           
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DLBFHJF;Initial Catalog=policestation;Integrated Security=True");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-1SQ72LC;Initial Catalog=policestation;Integrated Security=True");

        private void ShowCases()
        {
            Con.Open();
            string Query = "Select * from casetb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CasesDVG.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void GetCriminalName()
        {
            Con.Open();
            string Query = "select * from criminaltb1 where CrCode = " + CriminalCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CrimNameTb.Text = dr["CrName"].ToString();

            }
            Con.Close();


        }
        private void GetCriminals()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select * from criminaltb1", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CrCode", typeof(int));
            dt.Load(Rdr);
            CriminalCb.ValueMember = "CrCode";
            CriminalCb.DataSource = dt;
            Con.Close();

        }
        private void Reset()
        {
            CaseheadTb.Text = "";
            CasedetailsTb.Text = "";
            TypeCb.SelectedIndex = -1;
            PlaceTb.Text = "";
            CrimNameTb.Text = "";
            Key = 0;
        }
        private void RecordBtn_Click(object sender, EventArgs e)
        {
            if (CaseheadTb.Text == "" || CasedetailsTb.Text == "" || TypeCb.SelectedIndex == -1 || PlaceTb.Text == "" || CrimNameTb.Text == "")
            {
                MessageBox.Show("Missing information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into casetb1(Ctype,Cheading,CDetail,Cplace,CDate,Cperson,CpersonName,polname)values(@CT,@CH,@CD,@CP,@CDa,@CPer,@CPerN,@poln)", Con);
                    cmd.Parameters.AddWithValue("@CT", TypeCb.Text);
                    cmd.Parameters.AddWithValue("@CH", CaseheadTb.Text);
                    cmd.Parameters.AddWithValue("@CD", CasedetailsTb.Text);
                    cmd.Parameters.AddWithValue("@CP", PlaceTb.Text);
                    cmd.Parameters.AddWithValue("@CDa", Date.Value.Date);
                    cmd.Parameters.AddWithValue("@CPer", CriminalCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CPerN", CrimNameTb.Text);
                    cmd.Parameters.AddWithValue("@poln", OffNameTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Case Recorded");
                    Con.Close();
                    ShowCases();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void CriminalCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCriminalName();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CaseheadTb.Text == "" || CasedetailsTb.Text == "" || TypeCb.SelectedIndex == -1 || PlaceTb.Text == "" || CrimNameTb.Text == "")
            {
                MessageBox.Show("Missing information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update casetb1 Set Ctype =@CT,Cheading=@CH,CDetail=@CD,Cplace=@CP,CDate=@CDa,Cperson=@CPer,CpersonName=@CPerN,polname=@poln where CNum = @CKey", Con);
                    cmd.Parameters.AddWithValue("@CT", TypeCb.Text);
                    cmd.Parameters.AddWithValue("@CH", CaseheadTb.Text);
                    cmd.Parameters.AddWithValue("@CD", CasedetailsTb.Text);
                    cmd.Parameters.AddWithValue("@CP", PlaceTb.Text);
                    cmd.Parameters.AddWithValue("@CDa", Date.Value.Date);
                    cmd.Parameters.AddWithValue("@CPer", CriminalCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CPerN", CrimNameTb.Text);
                    cmd.Parameters.AddWithValue("@poln", OffNameTb.Text);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Case Updated");
                    Con.Close();
                    ShowCases();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void CasesDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TypeCb.SelectedItem = CasesDVG.SelectedRows[0].Cells[1].Value.ToString();
            CaseheadTb.Text = CasesDVG.SelectedRows[0].Cells[2].Value.ToString();
            CasedetailsTb.Text = CasesDVG.SelectedRows[0].Cells[3].Value.ToString();
            PlaceTb.Text = CasesDVG.SelectedRows[0].Cells[4].Value.ToString();
            Date.Text = CasesDVG.SelectedRows[0].Cells[5].Value.ToString();
            CriminalCb.Text = CasesDVG.SelectedRows[0].Cells[6].Value.ToString();
            CrimNameTb.Text = CasesDVG.SelectedRows[0].Cells[7].Value.ToString();

            if (CaseheadTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CasesDVG.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Case!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from casetb1 where CNum = @CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Case deleted");
                    Con.Close();
                    ShowCases();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Cases obj = new Cases();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Charges obj = new Charges();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Criminals obj = new Criminals();
            obj.Show();
            this.Hide();
        }
    }
}