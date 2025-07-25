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
    public partial class ChiTietHoaDon : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=QuanLySach;Integrated Security=True;Encrypt=False");

        private SqlDataAdapter adapter;
        private DataTable dt;
        public ChiTietHoaDon()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                
                adapter = new SqlDataAdapter("SELECT * FROM ChiTiet_HoaDon", conn);
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
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO ChiTiet_HoaDon (MaHD, MaSach, NgayLap, MaCB) VALUES (@MaHD, @MaSach, @NgayLap, @MaCB)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@NgayLap", txtNgayLap.Text);
                cmd.Parameters.AddWithValue("@MaCB", txtMaCB.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
                else MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch(System.Data.SqlClient.SqlException) { MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                string query = "UPDATE ChiTiet_HoaDon SET MaSach = @MaSach, NgayLap = @NgayLap, MaCB = @MaCB WHERE MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@NgayLap", txtNgayLap.Text);
                cmd.Parameters.AddWithValue("@MaCB", txtMaCB.Text);

                if (cmd.ExecuteNonQuery()>0) { 
                    MessageBox.Show("Sửa thành công!");
                    LoadData();
                }else MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch( System.Data.SqlClient.SqlException) { MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                string query = "DELETE FROM ChiTiet_HoaDon WHERE MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
                LoadData();
            }
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
                string query = "SELECT * FROM ChiTiet_HoaDon WHERE MaHD LIKE '%' + @MaHD + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", txtTimKiem.Text);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["mahd"].Value.ToString();
                txtMaSach.Text = row.Cells["masach"].Value.ToString();
                txtNgayLap.Text = row.Cells["ngaylap"].Value.ToString();
                txtMaCB.Text = row.Cells["MaCB"].Value.ToString();
            }

        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
