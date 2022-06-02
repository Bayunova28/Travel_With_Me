using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace UAS
{
    public partial class Form1 : Form
    {
        public TextBox Hitung { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        void ClearInput()
        {
            TxtIdCustomer.Clear();
            TxtNama.Clear();
            TxtTujuan.Clear();
            TxtJenisAirlane.Clear();
            TxtJumlah.Clear();
            TxtHarga.Clear();
            TxtPayment.Clear();
            TxtJenisTiket.Clear();
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info = False; Initial Catalog = TravelWithMe; Data Source = MSI\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO CUSTOMER(Customer_ID, Nama, Tujuan, Jenis_Airlane, Jenis_Tiket, Jumlah, Harga, Payment) VALUES(@Customer_ID, @Nama, @Tujuan, @Jenis_Airlane, @Jenis_Tiket, @Jumlah, @Harga, @Payment)", conn);
            sqlCommand.Parameters.AddWithValue("@Customer_ID", TxtIdCustomer.Text);
            sqlCommand.Parameters.AddWithValue("@Nama", TxtNama.Text);
            sqlCommand.Parameters.AddWithValue("@Tujuan", TxtTujuan.Text);
            sqlCommand.Parameters.AddWithValue("@Jenis_Airlane", TxtJenisAirlane.Text);
            sqlCommand.Parameters.AddWithValue("@Jenis_Tiket", TxtJenisTiket.Text);
            sqlCommand.Parameters.AddWithValue("@Jumlah", TxtJumlah.Text);
            sqlCommand.Parameters.AddWithValue("@Harga", TxtHarga.Text);
            sqlCommand.Parameters.AddWithValue("@Payment", TxtPayment.Text);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diinput");
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnHitung_Click(object sender, EventArgs e)
        {
            double jumlah, harga, Hitung;

            jumlah = Convert.ToDouble(TxtJumlah.Text);
            harga = Convert.ToDouble(TxtHarga.Text);
            Hitung = jumlah * harga;
            TxtHitung.Text = Hitung.ToString();

        }

        private void BtnViewDatabase_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            string connString = "Integrated Security=SSPI;Persist Security Info = False; Initial Catalog = TravelWithMe; Data Source = MSI\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CUSTOMER", conn);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                conn.Open();
                dataAdapter.Fill(dataSet, "Customer");

                dataGridView1.DataSource = dataSet.Tables["Customer"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Data Error");
            }
            finally
            {
                conn.Close();
            }
        }

        static string Read()
        {
            FileStream fs = new FileStream("C:\\Users\\bayu\\Dropbox\\My PC (MSI)\\Documents\\Customer.sql", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            return (sr.ReadToEnd());
        }

        static void Write(string word)
        {
            FileStream fs = new FileStream("C:\\Users\\bayu\\Dropbox\\My PC (MSI)\\Documents\\Customer.sql", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(word);
            sw.Close();
            fs.Close();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            BtnGenerate.Text = Read();
            MessageBox.Show(BtnGenerate.Text);
        }

        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            CrystalReport1 vcr = new CrystalReport1();
            vcr.SetParameterValue("Customer", BtnViewReport.Text);
            crystalReportViewer1.ReportSource = vcr;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info = False; Initial Catalog = TravelWithMe; Data Source = MSI\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("UPDATE CUSTOMER SET Nama = @Nama, Tujuan = @Tujuan, Jenis_Airlane = @Jenis_Airlane, Jenis_Tiket = @Jenis_Tiket, Jumlah = @Jumlah, Harga = @Harga, Payment = @Payment WHERE Customer_ID = @Customer_ID", conn);
            sqlCommand.Parameters.AddWithValue("@Customer_ID", TxtIdCustomer.Text);
            sqlCommand.Parameters.AddWithValue("@Nama", TxtNama.Text);
            sqlCommand.Parameters.AddWithValue("@Tujuan", TxtTujuan.Text);
            sqlCommand.Parameters.AddWithValue("@Jenis_Airlane", TxtJenisAirlane.Text);
            sqlCommand.Parameters.AddWithValue("@Jenis_Tiket", TxtJenisTiket.Text);
            sqlCommand.Parameters.AddWithValue("@Jumlah", TxtJumlah.Text);
            sqlCommand.Parameters.AddWithValue("@Harga", TxtHarga.Text);
            sqlCommand.Parameters.AddWithValue("@Payment", TxtPayment.Text);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate");
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info = False; Initial Catalog = TravelWithMe; Data Source = MSI\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM CUSTOMER WHERE Customer_ID = @Customer_ID", conn);
            sqlCommand.Parameters.AddWithValue("@Customer_ID", TxtIdCustomer.Text);
            sqlCommand.Parameters.AddWithValue("@Nama", TxtNama.Text);
            sqlCommand.Parameters.AddWithValue("@Tujuan", TxtTujuan.Text);
            sqlCommand.Parameters.AddWithValue("@Jenis_Airlane", TxtJenisAirlane.Text);
            sqlCommand.Parameters.AddWithValue("@Jenis_Tiket", TxtJenisTiket.Text);
            sqlCommand.Parameters.AddWithValue("@Jumlah", TxtJumlah.Text);
            sqlCommand.Parameters.AddWithValue("@Harga", TxtHarga.Text);
            sqlCommand.Parameters.AddWithValue("@Payment", TxtPayment.Text);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
