using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace sieu_thi_mini
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        private static int stt = 1;
        private static int snh = 1;
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = App.ConnectionString;
        string MaNhapHang = "";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                string sql = "SELECT TOP 1 MaNhapHang FROM tblNhapHang ORDER BY MaNhapHang DESC";
                SqlCommand cmd = new SqlCommand(sql, Conn);
                string lastMaNhapHang = (string)cmd.ExecuteScalar();
                if (lastMaNhapHang != null)
                {
                    int lastSnh = int.Parse(lastMaNhapHang.Substring(2));
                    snh = lastSnh + 1;
                }
                MaNhapHang = "NH" + snh.ToString("D3");

                string sql1 = "SELECT TOP 1 MaSanPham FROM tblSanPham ORDER BY MaSanPham DESC";
                SqlCommand cmd1 = new SqlCommand(sql1, Conn);
                string lastMaDonHang = (string)cmd1.ExecuteScalar();
                if (lastMaDonHang != null)
                {
                    int lastStt = int.Parse(lastMaDonHang.Substring(2));
                    stt = lastStt + 1;
                }
                txtMaSanPham.Text = "SP" + stt.ToString("D3");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void defaulApp()
        {
            txtMaSanPham.Text = txtMaSanPham.Text;
            txtTenSanPham.Text = "";
            txtPhanLoai.Text = "";
            txtDonVi.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            dpNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dpHSD.Text = "";
            img.Source = null;
        }

        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }

        private void upImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (.png;.jpeg)|*.png;*.jpeg|All files (.)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                using (FileStream stream = new FileStream(imagePath, FileMode.Open))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    img.Source = image;
                }
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            defaulApp();

        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            //Chuyển đổi ảnh sang mảng byte
            BitmapImage image = img.Source as BitmapImage;
            byte[] imageData;
            using (MemoryStream ms = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(ms);
                imageData = ms.ToArray();
            }

            string insertSanPhamQuery = "INSERT INTO tblSanPham (MaSanPham, TenSanPham, PhanLoai, DonVi, SoLuong, GiaBan, HSD, Img) " +
            "VALUES (@MaSanPham, @TenSanPham, @PhanLoai, @DonVi, @SoLuong, @GiaBan, @HSD, @Img)";

            using (SqlCommand cmdSanPham = new SqlCommand(insertSanPhamQuery, Conn))
            {
                cmdSanPham.Parameters.AddWithValue("@MaSanPham", txtMaSanPham.Text);
                cmdSanPham.Parameters.AddWithValue("@TenSanPham", txtTenSanPham.Text);
                cmdSanPham.Parameters.AddWithValue("@PhanLoai", txtPhanLoai.Text);
                cmdSanPham.Parameters.AddWithValue("@DonVi", txtDonVi.Text);
                cmdSanPham.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                cmdSanPham.Parameters.AddWithValue("@GiaBan", float.Parse(txtGiaBan.Text));
                cmdSanPham.Parameters.AddWithValue("@HSD", toDate(dpHSD.Text));
                cmdSanPham.Parameters.Add("@Img", SqlDbType.Image, imageData.Length).Value = imageData;
                cmdSanPham.ExecuteNonQuery();
            }

            // Thực hiện truy vấn SQL INSERT cho bảng tblNhapHang
            string insertNhapHangQuery = "INSERT INTO tblNhapHang (MaNhapHang,MaSanPham, TenSanPham, SoLuongNhap, GiaNhap, NgayNhap, HanSuDung) " +
                "VALUES (@MaNhapHang, @MaSanPham, @TenSanPham, @SoLuongNhap, @GiaNhap, @NgayNhap, @HSD)";

            using (SqlCommand cmdNhapHang = new SqlCommand(insertNhapHangQuery, Conn))
            {
                cmdNhapHang.Parameters.AddWithValue("@MaNhapHang", MaNhapHang);
                cmdNhapHang.Parameters.AddWithValue("@MaSanPham", txtMaSanPham.Text);
                cmdNhapHang.Parameters.AddWithValue("@TenSanPham", txtTenSanPham.Text);
                cmdNhapHang.Parameters.AddWithValue("@SoLuongNhap", int.Parse(txtSoLuong.Text)); // Sử dụng cùng giá trị với SoLuong
                cmdNhapHang.Parameters.AddWithValue("@GiaNhap", float.Parse(txtGiaNhap.Text));
                cmdNhapHang.Parameters.AddWithValue("@NgayNhap", toDate(dpNgayNhap.Text));
                cmdNhapHang.Parameters.AddWithValue("@HSD", toDate(dpHSD.Text));

                cmdNhapHang.ExecuteNonQuery();
            }

            string sql = "SELECT TOP 1 MaNhapHang FROM tblNhapHang ORDER BY MaNhapHang DESC";
            SqlCommand cmd = new SqlCommand(sql, Conn);
            string lastMaNhapHang = (string)cmd.ExecuteScalar();
            if (lastMaNhapHang != null)
            {
                int lastSnh = int.Parse(lastMaNhapHang.Substring(2));
                snh = lastSnh + 1;
            }
            MaNhapHang = "NH" + snh.ToString("D3");

            string sql1 = "SELECT TOP 1 MaSanPham FROM tblSanPham ORDER BY MaSanPham DESC";
            SqlCommand cmd1 = new SqlCommand(sql1, Conn);
            string lastMaDonHang = (string)cmd1.ExecuteScalar();
            if (lastMaDonHang != null)
            {
                int lastStt = int.Parse(lastMaDonHang.Substring(2));
                stt = lastStt + 1;
            }
            txtMaSanPham.Text = "SP" + stt.ToString("D3");
            defaulApp();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public class AddProductTests
        {
            public void btSave_Click(
                        string maSanPham,
                        string tenSanPham,
                        string phanLoai,
                        string donVi,
                        int soLuong,
                        float giaBan,
                        DateTime hsd,
                        BitmapImage image,
                        float giaNhap,
                        DateTime ngayNhap,
                        SqlConnection conn)
            {
                // Chuyển đổi ảnh sang mảng byte
                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    encoder.Save(ms);
                    imageData = ms.ToArray();
                }

                string insertSanPhamQuery = "INSERT INTO tblSanPham (MaSanPham, TenSanPham, PhanLoai, DonVi, SoLuong, GiaBan, HSD, Img) " +
                "VALUES (@MaSanPham, @TenSanPham, @PhanLoai, @DonVi, @SoLuong, @GiaBan, @HSD, @Img)";

                using (SqlCommand cmdSanPham = new SqlCommand(insertSanPhamQuery, conn))
                {
                    cmdSanPham.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    cmdSanPham.Parameters.AddWithValue("@TenSanPham", tenSanPham);
                    cmdSanPham.Parameters.AddWithValue("@PhanLoai", phanLoai);
                    cmdSanPham.Parameters.AddWithValue("@DonVi", donVi);
                    cmdSanPham.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdSanPham.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmdSanPham.Parameters.AddWithValue("@HSD", hsd);
                    cmdSanPham.Parameters.Add("@Img", SqlDbType.Image, imageData.Length).Value = imageData;
                    cmdSanPham.ExecuteNonQuery();
                }

                // Thực hiện truy vấn SQL INSERT cho bảng tblNhapHang
                string insertNhapHangQuery = "INSERT INTO tblNhapHang (MaNhapHang, MaSanPham, TenSanPham, SoLuongNhap, GiaNhap, NgayNhap, HanSuDung) " +
                    "VALUES (@MaNhapHang, @MaSanPham, @TenSanPham, @SoLuongNhap, @GiaNhap, @NgayNhap, @HSD)";

                string maNhapHang = GenerateNewMaNhapHang(conn);

                using (SqlCommand cmdNhapHang = new SqlCommand(insertNhapHangQuery, conn))
                {
                    cmdNhapHang.Parameters.AddWithValue("@MaNhapHang", maNhapHang);
                    cmdNhapHang.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    cmdNhapHang.Parameters.AddWithValue("@TenSanPham", tenSanPham);
                    cmdNhapHang.Parameters.AddWithValue("@SoLuongNhap", soLuong);
                    cmdNhapHang.Parameters.AddWithValue("@GiaNhap", giaNhap);
                    cmdNhapHang.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                    cmdNhapHang.Parameters.AddWithValue("@HSD", hsd);
                    cmdNhapHang.ExecuteNonQuery();
                }

                string newMaSanPham = GenerateNewMaSanPham(conn);
                // This would ideally update the relevant TextBox or return this value to the calling method
                // Example: txtMaSanPham.Text = newMaSanPham;

                // Assuming defaulApp() resets form fields or similar, ensure it is called as needed in your context
                // defaulApp();
            }

            private string GenerateNewMaNhapHang(SqlConnection conn)
            {
                string sql = "SELECT TOP 1 MaNhapHang FROM tblNhapHang ORDER BY MaNhapHang DESC";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string lastMaNhapHang = (string)cmd.ExecuteScalar();
                    if (lastMaNhapHang != null)
                    {
                        int lastSnh = int.Parse(lastMaNhapHang.Substring(2));
                        int newSnh = lastSnh + 1;
                        return "NH" + newSnh.ToString("D3");
                    }
                    else
                    {
                        return "NH001"; // Default value if no records exist
                    }
                }
            }

            private string GenerateNewMaSanPham(SqlConnection conn)
            {
                string sql1 = "SELECT TOP 1 MaSanPham FROM tblSanPham ORDER BY MaSanPham DESC";
                using (SqlCommand cmd1 = new SqlCommand(sql1, conn))
                {
                    string lastMaSanPham = (string)cmd1.ExecuteScalar();
                    if (lastMaSanPham != null)
                    {
                        int lastStt = int.Parse(lastMaSanPham.Substring(2));
                        int newStt = lastStt + 1;
                        return "SP" + newStt.ToString("D3");
                    }
                    else
                    {
                        return "SP001"; // Default value if no records exist
                    }
                }
            }

        }
    }
}
