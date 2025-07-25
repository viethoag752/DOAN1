using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanSach
{

    public partial class KhoSach : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=QuanLySach;Integrated Security=True;Encrypt=False");

        private SqlDataAdapter adapter;
        private DataTable dt;
        public KhoSach()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {

                adapter = new SqlDataAdapter("SELECT * FROM KhoSach", conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            finally
            {
                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KhoSach_Load(object sender, EventArgs e)
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
                string query = "INSERT INTO KhoSach (MaLo,MaSach,NgayNhap,NgayXuat, SoLuong) VALUES (@MaLo,@MaSach,@NgayNhap,@NgayXuat, @SoLuong)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLo", txtMaLo.Text);
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@SoLuong", txtSL.Text);
                cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                cmd.Parameters.AddWithValue("@NgayXuat", dtpNgayXuat.Value);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
                else MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.SqlClient.SqlException ex) { MessageBox.Show("Vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                string query = "UPDATE KhoSach SET  MaSach= @MaSach,NgayNhap = @NgayNhap,NgayXuat = @NgayXuat, SoLuong =@SoLuong  WHERE MaLo = @MaLo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLo", txtMaLo.Text);
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@SoLuong", txtSL.Text);
                cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                cmd.Parameters.AddWithValue("@NgayXuat", dtpNgayXuat.Value);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    LoadData();
                }
                else MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.SqlClient.SqlException ex) { MessageBox.Show("Vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                string query = "DELETE FROM KhoSach WHERE MaLo = @MaLo";
               
                SqlCommand cmd = new SqlCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@MaLo", txtMaLo.Text);
                if (cmd.ExecuteNonQuery() > 0) {
                MessageBox.Show("Xóa thành công!");
                LoadData();
                }else MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                string query = "SELECT * FROM KhoSach WHERE MaLo LIKE '%' + @MaLo + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLo", txtTimKiem.Text);
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
                txtMaSach.Text = row.Cells["masach"].Value.ToString();
                txtSL.Text = row.Cells["soluong"].Value.ToString();
                txtMaLo.Text = row.Cells["malo"].Value.ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["ngaynhap"].Value);
                dtpNgayXuat.Value = Convert.ToDateTime(row.Cells["NgayXuat"].Value);


            }

        }
    }
}
