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

namespace QuanLyBanSach
{
    public partial class TheKH : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=QuanLySach;Integrated Security=True;Encrypt=False");
        private SqlDataAdapter adapter;
        private DataTable dt;
        public TheKH()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
               
                adapter = new SqlDataAdapter("SELECT * FROM TheKhachHang", conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            finally
            {
                conn.Close();
            }
        }


        private void TheKH_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO TheKhachHang (MaThe, NgayLap) VALUES (@MaThe, @NgayLap)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThe", txtMaThe.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                if (cmd.ExecuteNonQuery() > 0) { MessageBox.Show("Thêm thành công!"); }
                else MessageBox.Show("Thêm thất bại !");
                LoadData();
            }
            catch (System.Data.SqlClient.SqlException ex) { MessageBox.Show("Vui lòng nhập chính xác và không trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE TheKhachHang SET NgayLap = @NgayLap WHERE MaThe = @MaThe";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThe", txtMaThe.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                if(cmd.ExecuteNonQuery() > 0) { MessageBox.Show("Sửa thành công!"); }
                else MessageBox.Show("Sửa thất bại ");
                LoadData();
            }
            finally
            {
                conn.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM TheKhachHang WHERE MaThe = @MaThe";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThe", txtMaThe.Text);
                if (cmd.ExecuteNonQuery() > 0) { MessageBox.Show("Xóa thành công!"); }
                
                else MessageBox.Show("Xóa  thất bại ");
                LoadData();
            } catch(System.Data.SqlClient.SqlException ex) { MessageBox.Show("Vui lòng xóa khách hàng trước", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally 
            {
                conn.Close();
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM TheKhachHang WHERE MaThe LIKE '%' + @MaThe + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThe", txtTimKiem.Text);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            finally
            {
                conn.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaThe.Text = row.Cells["MaThe"].Value.ToString();
                dtpNgayLap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);
            }

        }
    }
}
