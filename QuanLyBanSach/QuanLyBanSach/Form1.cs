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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=QuanLySach;Integrated Security=True;Encrypt=False");

        private SqlDataAdapter adapter;
        private DataTable dt;

        
        public Form1()
        {
            
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                
                adapter = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
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
              string query = "INSERT INTO KhachHang (MaKH, TenKH, DiaChi, ThongTinLL, NgaySinh, MaThe) VALUES (@MaKH, @TenKH, @DiaChi, @ThongTinLL, @NgaySinh, @MaThe)";
              SqlCommand cmd = new SqlCommand(query, conn);
              cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
              cmd.Parameters.AddWithValue("@TenKH", txtHoTen.Text);
              cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
              cmd.Parameters.AddWithValue("@ThongTinLL", txtThongTinLL.Text);
              cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
              cmd.Parameters.AddWithValue("@MaThe", cmbMaThe.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
                else MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.SqlClient.SqlException) { MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {conn.Close();}
            
           
            



        }



        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
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
                string query = "SELECT * FROM KhachHang WHERE MaKH LIKE '%' + @MaKH + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtTimKiem.Text);
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
                txtMaKH.Text = row.Cells["makh"].Value.ToString();
                txtHoTen.Text = row.Cells["hoten"].Value.ToString();
                txtDiaChi.Text = row.Cells["diachi"].Value.ToString();
                txtThongTinLL.Text = row.Cells["ttll"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["ngaysinh"].Value);
                cmbMaThe.Text = row.Cells["mathe"].Value.ToString();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE KhachHang SET TenKH = @TenKH, DiaChi = @DiaChi, ThongTinLL = @ThongTinLL, NgaySinh = @NgaySinh, MaThe = @MaThe WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                cmd.Parameters.AddWithValue("@TenKH", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@ThongTinLL", txtThongTinLL.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@MaThe", cmbMaThe.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!");
                LoadData();
            }catch(System.Data.SqlClient.SqlException ex ) { MessageBox.Show("Vui lòng nhập đúng mã thẻ!"); }
            finally
            {
                conn.Close();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
