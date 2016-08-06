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

    //   private int MaSV_update = 0;

        private void LoadData()
        {
            txtMaSV.DataBindings.Clear();//Xoa du lieu co san trong textbox
            txtMaSV.DataBindings.Add("Text", dataList.DataSource, "MaSV");
       //     MaSV_update = Int32.Parse(txtMaSV.Text);////////////////////////////////////////////////////////////////
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

        private void Edit(string HoTen, string MaLop, int MaSV, float DiemTB, DateTime NgaySinh, string GioiTinh)
        {
            try
            {

                string sql = "update Student set HoTen=@HoTen,MaLop=@MaLop,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,DiemTB=@DiemTB where MaSV='" + txtMaSV.Text + "'";
                con = new SqlConnection(chuoi);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                cmd.Parameters["@HoTen"].Value = txtTen.Text;
                cmd.Parameters.Add("@MaSV", SqlDbType.Int);
                cmd.Parameters["@MaSV"].Value = txtMaSV.Text;
                cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar);
                cmd.Parameters["@MaLop"].Value = txtMaLop.Text;
                cmd.Parameters.Add("@DiemTB", SqlDbType.Float);
                cmd.Parameters["@DiemTB"].Value = txtDiem.Text;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date);
                cmd.Parameters["@NgaySinh"].Value = dateTime.Text;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar);
                cmd.Parameters["@GioiTinh"].Value = cboGioiTinh.Text;

              /*  cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Int)).Value = MaSV;
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Int)).Value = MaSV;
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Int)).Value = MaSV;
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Int)).Value = MaSV;
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Int)).Value = MaSV;
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Int)).Value = MaSV;*/
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!", "Thông báo");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            KetNoiCSDL();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            con = new SqlConnection(chuoi);
            con.Open();
            // Make command to use

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

        public void Insert(string HoTen, string MaLop, int MaSV, float DiemTB, DateTime NgaySinh, string GioiTinh)
        {
            //string sql = "insert into Student (MaSV, HoTen, MaLop, NgaySinh,GioiTinh,DiemTB) values (@MaSV, @HoTen,@MaLop,@NgaySinh,@GioiTinh,@DiemTB)";//Truong hop ghi cac truong ko theo thu tu
            try
            {
                string sql = "insert into Student values (@HoTen,@MaSV, @MaLop,@NgaySinh,@GioiTinh,@DiemTB)";
                con = new SqlConnection(chuoi);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
//                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Int)).Value = MaSV;
                cmd.Parameters.Add("@MaSV", SqlDbType.Int);
                cmd.Parameters["@MaSV"].Value = MaSV;
                cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar);
                cmd.Parameters["@MaLop"].Value = MaLop;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                cmd.Parameters["@HoTen"].Value = HoTen;
                cmd.Parameters.Add("@DiemTB", SqlDbType.Float);
                cmd.Parameters["@DiemTB"].Value = DiemTB;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date);
                cmd.Parameters["@NgaySinh"].Value = NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar);
                cmd.Parameters["@GioiTinh"].Value = GioiTinh;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Sinh viên đã tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            Insert(txtTen.Text, txtMaLop.Text, Int32.Parse(txtMaSV.Text), float.Parse(txtDiem.Text), Convert.ToDateTime(dateTime.Text), cboGioiTinh.Text);
            KetNoiCSDL();
            LoadData();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Edit(txtTen.Text, txtMaLop.Text, Int32.Parse(txtMaSV.Text), float.Parse(txtDiem.Text), Convert.ToDateTime(dateTime.Text), cboGioiTinh.Text);
            KetNoiCSDL();
            LoadData();
        }
    }
}
