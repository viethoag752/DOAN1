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
    public partial class HoaDon : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=QuanLySach;Integrated Security=True;Encrypt=False");
        private SqlDataAdapter adapter;
        private DataTable dt;
        public HoaDon()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM HoaDon", conn);
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
                string query = "INSERT INTO HoaDon (MaHD, MaThe, DonGia) VALUES (@MaHD, @MaThe, @DonGia)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaThe", txtMaThe.Text);
                cmd.Parameters.AddWithValue("@DonGia", txtDonGia.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadData();
                }
                else MessageBox.Show("Thêm thất bại!");

            }
            catch (System.Data.SqlClient.SqlException ex) { MessageBox.Show("Vui lòng nhập lại","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally
            {
                conn.Close();
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE HoaDon SET MaThe = @MaThe, DonGia = @DonGia WHERE MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaThe", txtMaThe.Text);
                cmd.Parameters.AddWithValue("@DonGia", txtDonGia.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    LoadData();
                }
                else MessageBox.Show("Sửa thất bại!");
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
                string query = "DELETE FROM HoaDon WHERE MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.ExecuteNonQuery();
                
                 MessageBox.Show("Xóa thành công!");
                    LoadData();
                
                
            }catch(System.Data.SqlClient.SqlException ex) { MessageBox.Show("Vui lòng xóa chi tiết hóa đơn trước", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                txtMaHD.Text = row.Cells["mahd"].Value.ToString();
                txtMaThe.Text = row.Cells["mathe"].Value.ToString();
                txtDonGia.Text = row.Cells["dongia"].Value.ToString();

            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM HoaDon WHERE MaHD LIKE '%' + @MaHD + '%'";
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

        private void HoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
