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
    public partial class Charges : Form
    {
        public Charges()
        {
            InitializeComponent();
            ShowCharges();
            GetCase();
        }

        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DLBFHJF;Initial Catalog=policestation;Integrated Security=True");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-1SQ72LC;Initial Catalog=policestation;Integrated Security=True");
        private void ShowCharges()
        {
            Con.Open();
            string Query = "Select * from chargetb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ChargeDVG.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void GetCaseName()
        {
            Con.Open();
            string Query = "select * from casetb1 where CNum = " + CaseCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CaseheadingTb.Text = dr["CHeading"].ToString();

            }
            Con.Close();


        }
        private void GetCase()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select * from casetb1", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CrNum", typeof(int));
            dt.Load(Rdr);
            CaseCb.ValueMember = "CNum";
            CaseCb.DataSource = dt;
            Con.Close();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CaseCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCaseName();
        }
        private void Reset()

        {
            CaseheadingTb.Text = "";
            ChargesheetTb.Text = "";
            RemarkTb.Text = "";
            CaseCb.SelectedIndex = -1;
            Key = 0;


        }

        private void RecordBtn_Click(object sender, EventArgs e)
        {
            if (CaseheadingTb.Text == "" || ChargesheetTb.Text == "" || RemarkTb.Text == "")
            {
                MessageBox.Show("Missing information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into chargetb1(CaseCode,CaseHeading,ChargeSheet,Remarks,polname)values(@CC,@CH,@CS,@CRem,@polN)", Con);
                    cmd.Parameters.AddWithValue("@CC", CaseCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CH", CaseheadingTb.Text);
                    cmd.Parameters.AddWithValue("@CS", ChargesheetTb.Text);
                    cmd.Parameters.AddWithValue("@CRem", RemarkTb.Text);
                    cmd.Parameters.AddWithValue("@polN", OffnameLb1.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Charge Recorded");
                    Con.Close();
                    ShowCharges();
                    //  Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void ChargeDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CaseCb.SelectedValue = ChargeDVG.SelectedRows[0].Cells[1].Value.ToString();
            CaseheadingTb.Text = ChargeDVG.SelectedRows[0].Cells[2].Value.ToString();
            ChargesheetTb.Text = ChargeDVG.SelectedRows[0].Cells[3].Value.ToString();
            RemarkTb.Text = ChargeDVG.SelectedRows[0].Cells[4].Value.ToString();
            if (CaseheadingTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ChargeDVG.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CaseheadingTb.Text == "" || ChargesheetTb.Text == "" || RemarkTb.Text == "")
            {
                MessageBox.Show("Missing information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update chargetb1 Set CaseCode=@CC,CaseHeading=@CH,ChargeSheet=@CS,Remarks=@CRem,polname=@polN where CrNum = @CrKey", Con);
                    cmd.Parameters.AddWithValue("@CC", CaseCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CH", CaseheadingTb.Text);
                    cmd.Parameters.AddWithValue("@CS", ChargesheetTb.Text);
                    cmd.Parameters.AddWithValue("@CRem", RemarkTb.Text);
                    cmd.Parameters.AddWithValue("@polN", OffnameLb1.Text);
                    cmd.Parameters.AddWithValue("@CrKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Charge Updated!!!!");
                    Con.Close();
                    ShowCharges();
                    //  Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
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
                    SqlCommand cmd = new SqlCommand("delete from chargetb1 where CrNum = @CrKey", Con);
                    cmd.Parameters.AddWithValue("@CrKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Criminal deleted");
                    Con.Close();
                    ShowCharges();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void Charges_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Cases obj = new Cases();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Charges obj = new Charges() ;
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
