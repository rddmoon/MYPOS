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
namespace MYPOS
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void ReportForm_Load(object sender, EventArgs e)
        {
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datelbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }
        
        private void ReportDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void radioDaily_CheckedChanged(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS No, b.BillId, b.SellerName, b.BillDate, b.TotAmt from BillTbl as b where BillDate='" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ReportDGV.DataSource = ds.Tables[0];
            Con.Close();
            total_daily();
        }

        private void total_daily()
        {
            Con.Open();
            string query = "select SUM(TotAmt) from BillTbl where BillDate='" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Amtlbl.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();
        }

        private void radioWeekly_CheckedChanged(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS No, b.BillId, b.SellerName, b.BillDate, b.TotAmt from BillTbl as b where DATEDIFF(ww, PARSE(BillDate as date USING 'AR-LB'), GETDATE()) = 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ReportDGV.DataSource = ds.Tables[0];
            Con.Close();
            total_weekly();
        }

        private void total_weekly()
        {
            Con.Open();
            string query = "select SUM(TotAmt) from BillTbl where DATEDIFF(ww, PARSE(BillDate as date USING 'AR-LB'), GETDATE()) = 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Amtlbl.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();
        }

        private void radioMonthly_CheckedChanged(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS No, b.BillId, b.SellerName, b.BillDate, b.TotAmt from BillTbl as b where DATEDIFF(mm, PARSE(BillDate as date USING 'AR-LB'), GETDATE()) = 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ReportDGV.DataSource = ds.Tables[0];
            Con.Close();
            total_monthly();
        }

        private void total_monthly()
        {
            Con.Open();
            string query = "select SUM(TotAmt) from BillTbl where DATEDIFF(mm, PARSE(BillDate as date USING 'AR-LB'), GETDATE()) = 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Amtlbl.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();
        }

        private void radioYearly_CheckedChanged(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS No, b.BillId, b.SellerName, b.BillDate, b.TotAmt from BillTbl as b where DATEDIFF(yy, PARSE(BillDate as date USING 'AR-LB'), GETDATE()) = 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ReportDGV.DataSource = ds.Tables[0];
            Con.Close();
            total_yearly();
        }

        private void total_yearly()
        {
            Con.Open();
            string query = "select SUM(TotAmt) from BillTbl where DATEDIFF(yy, PARSE(BillDate as date USING 'AR-LB'), GETDATE()) = 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Amtlbl.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SellerForm seller = new SellerForm();
            seller.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm product = new ProductForm();
            product.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
