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

namespace Student_Management
{
    public partial class QuanLySinhVien : Form
    {
        string chuoi = @"Data Source=MINHHANG\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";
        SqlConnection con;

        private void KetNoiCSDL()
        {
            try
            {
                con = new SqlConnection(chuoi);
                //Mo ket noi
                con.Open();
                //Tao chuoi ket noi
                string sql = "select * from Student"; //lay het du lieu trong bang Student
                SqlCommand com = new SqlCommand(sql, con);//bat dau truy van dl
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);//van chuyen du lieu ve
                DataTable dt = new DataTable();
                //Tao kho ao de luu du lieu
                da.Fill(dt);//do du lieu vao kho
                //dong ket noi
                con.Close();

                // dataGridView1.DataSource = dt;
                dataList.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Lỗi Kết Nối!", "Thông Báo");
            }
        }

        public QuanLySinhVien()
        {
            InitializeComponent();
        }


        private void QuanLySinhVien_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            txtMaSV.DataBindings.Clear();//Xoa du lieu co san trong textbox
            txtMaSV.DataBindings.Add("Text", dataList.DataSource, "MaSV");
            txtMaLop.DataBindings.Clear();
            txtMaLop.DataBindings.Add("Text", dataList.DataSource, "MaLop");
            txtDiem.DataBindings.Clear();
            txtDiem.DataBindings.Add("Text", dataList.DataSource, "DiemTB");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dataList.DataSource, "HoTen");
            cboGioiTinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Add("Text", dataList.DataSource, "GioiTinh");
            dateTime.DataBindings.Clear();
            dateTime.DataBindings.Add("Text", dataList.DataSource, "NgaySinh");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            KetNoiCSDL();
            LoadData();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            //   SqlConnection con = new SqlConnection(@"Data Source=MINHHANG\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True");
            con = new SqlConnection(chuoi);
            con.Open();
            // Make command to use

            //*************** code here for all ****************************
            string masv = txtMaSV.Text;
            string Delete = "delete from Student where MaSV='" + masv + "'";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = Delete;
            DialogResult h = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa sinh viên có mã " + masv + "!", "Thông Báo");
                KetNoiCSDL();
                LoadData();
            }
            con.Close();
            //***********************

            // Closed Connect
            /*con.Dispose();
            cmd.Dispose();*/
            // clearn textbox;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }
    }
}
