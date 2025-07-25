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
    public partial class Sach : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=QuanLySach;Integrated Security=True;Encrypt=False");

        private SqlDataAdapter adapter;
        private DataTable dt;
        public Sach()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                
                adapter = new SqlDataAdapter("SELECT * FROM Sach", conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            finally
            {
                conn.Close();
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
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
                string query = "INSERT INTO Sach (MaSach,TenSach, GiaBan, NhaXB, TacGia, TheLoai) VALUES (@MaSach,@TenSach, @GiaBan, @NhaXB, @TacGia, @TheLoai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                cmd.Parameters.AddWithValue("@GiaBan", txtGiaBan.Text);
                cmd.Parameters.AddWithValue("@NhaXB", txtNhaXB.Text);
                cmd.Parameters.AddWithValue("@TacGia", txtTacGia.Text);
                cmd.Parameters.AddWithValue("@TheLoai", txtTheLoai.Text);
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
                string query = "UPDATE Sach SET GiaBan = @GiaBan, NhaXB = @NhaXB, TacGia = @TacGia, TheLoai = @TheLoai WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@GiaBan", txtGiaBan.Text);
                cmd.Parameters.AddWithValue("@NhaXB", txtNhaXB.Text);
                cmd.Parameters.AddWithValue("@TacGia", txtTacGia.Text);
                cmd.Parameters.AddWithValue("@TheLoai", txtTheLoai.Text);
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
                string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
                        
                SqlCommand cmd = new SqlCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                if (cmd.ExecuteNonQuery() > 0 )
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch(System.Data.SqlClient.SqlException ẽx) { MessageBox.Show("Vui lòng xóa kho sách và chi tiết hóa đơn trước", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }

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
                string query = "SELECT * FROM Sach WHERE MaSach LIKE '%' + @MaSach + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", txtTimKiem.Text);
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
                txtGiaBan.Text = row.Cells["giaban"].Value.ToString();
                txtNhaXB.Text = row.Cells["nhaxb"].Value.ToString();
                txtTacGia.Text = row.Cells["tacgia"].Value.ToString();
                txtTheLoai.Text = row.Cells["theloai"].Value.ToString();
            }

        }

        private void Sach_Load(object sender, EventArgs e)
        {

        }
    }
}
