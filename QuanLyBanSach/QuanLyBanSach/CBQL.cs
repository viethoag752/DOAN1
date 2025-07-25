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
    public partial class CBQL : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=QuanLySach;Integrated Security=True;Encrypt=False");

        private SqlDataAdapter adapter;
        private DataTable dt;
        public CBQL()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                
                adapter = new SqlDataAdapter("SELECT * FROM CBQL", conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            finally
            {
                conn.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtDiaChi.Clear();
            txtMaCB.Clear();
            txtTenCB.Clear();
            txtThongTinLL.Clear();
            LoadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO CBQL (MaCB, TenCB, DiaChi, ThongTinLL, NgaySinh) VALUES (@MaCB, @TenCB, @DiaChi, @ThongTinLL, @NgaySinh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCB", txtMaCB.Text);
                cmd.Parameters.AddWithValue("@TenCB", txtTenCB.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@ThongTinLL", txtThongTinLL.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
                else MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.SqlClient.SqlException) { MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                conn.Close();
            }

            txtDiaChi.Clear();
            txtMaCB.Clear();
            txtTenCB.Clear();
            txtThongTinLL.Clear();

        }

        private void CBQL_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE CBQL SET TenCB = @TenCB, DiaChi = @DiaChi, ThongTinLL = @ThongTinLL, NgaySinh = @NgaySinh WHERE MaCB = @MaCB";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCB", txtMaCB.Text);
                cmd.Parameters.AddWithValue("@TenCB", txtTenCB.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@ThongTinLL", txtThongTinLL.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    LoadData();
                }
                else MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.SqlClient.SqlException) { MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                conn.Close();
            }

            txtDiaChi.Clear();
            txtMaCB.Clear();
            txtTenCB.Clear();
            txtThongTinLL.Clear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaCB.Text = row.Cells["macb"].Value.ToString();
                txtTenCB.Text = row.Cells["hoten"].Value.ToString();
                txtDiaChi.Text = row.Cells["diachi"].Value.ToString();
                txtThongTinLL.Text = row.Cells["ttll"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["ngaysinh"].Value);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM CBQL WHERE MaCB = @MaCB";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCB", txtMaCB.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
            catch (System.Data.SqlClient.SqlException ẽx) { MessageBox.Show("Vui lòng xóa chi tiết hóa đơn trước", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                string query = "SELECT * FROM CBQL WHERE MaCB LIKE '%' + @MaCB + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCB", txtTimKiem.Text);
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

        public static implicit operator CBQL(Form1 v)
        {
            throw new NotImplementedException();
        }
    }
}
