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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            total_amount();
            sellercount();
            sellingcount();
            productcount();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datelbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }

        private void total_amount()
        {
            Con.Open();
            string query = "select SUM(TotAmt) from BillTbl where BillDate='" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            lbl_total_amount.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();
        }

        private void sellercount()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select Count(SellerId)From SellerTbl";

                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                lbl_sellers.Text = rows_count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void productcount()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select Count(ProdId)From ProductTbl";

                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                lbl_products.Text = rows_count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sellingcount()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select Count(BillId)From BillTbl where BillDate='" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + "'";

                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                lbl_orders.Text = rows_count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellerForm seller = new SellerForm();
            seller.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            total_amount();
            sellercount();
            sellingcount();
            productcount();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            total_amount();
            sellercount();
            sellingcount();
            productcount();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReportForm report = new ReportForm();
            report.Show();
            this.Hide();
        }
    }
}
