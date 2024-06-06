using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using sieu_thi_mini;
using static sieu_thi_mini.AddProduct;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        
        private SqlConnection conn;


        [TestInitialize]
        public void Setup()
        {
            // Initialize the database connection with a test database connection string
            conn = new SqlConnection(@"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLySieuThi;Integrated Security=True;");
            conn.Open();
        }

        [TestMethod]
        public void TestInsertNewProductAndPurchaseRecordSuccessfully()
        {
            // Arrange
            var maSanPham = "SP0010";
            var tenSanPham = "Product A";
            var phanLoai = "Category 1";
            var donVi = "pcs";
            var soLuong = 10;
            var giaBan = 100.0f;
            var hsd = DateTime.Now.AddDays(30);
            var imageUri = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "E:\\2ndSemester3rdYear\\testt\\TestMart\\sieu_thi_mini\\Images\\logo.png"));
            var image = new BitmapImage(imageUri);
            var giaNhap = 80.0f;
            var ngayNhap = DateTime.Now;

            // Act

            var save_click = new AddProductTests();
            save_click.btSave_Click(maSanPham, tenSanPham, phanLoai, donVi, soLuong, giaBan, hsd, image, giaNhap, ngayNhap, conn);

            // Assert
            // Verify that the product was inserted correctly
            var checkSanPhamCmd = new SqlCommand("SELECT COUNT(*) FROM tblSanPham WHERE MaSanPham = @MaSanPham", conn);
            checkSanPhamCmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
            var sanPhamCount = (int)checkSanPhamCmd.ExecuteScalar();
            Assert.AreEqual(1, sanPhamCount);

            // Verify that the purchase record was inserted correctly
            var checkNhapHangCmd = new SqlCommand("SELECT COUNT(*) FROM tblNhapHang WHERE MaSanPham = @MaSanPham", conn);
            checkNhapHangCmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
            var nhapHangCount = (int)checkNhapHangCmd.ExecuteScalar();
            Assert.AreEqual(1, nhapHangCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHandleNullOrEmptyImage()
        {
            // Arrange
            var maSanPham = "SP002";
            var tenSanPham = "Product B";
            var phanLoai = "Category 2";
            var donVi = "pcs";
            var soLuong = 20;
            var giaBan = 200.0f;
            var hsd = DateTime.Now.AddDays(60);
            BitmapImage image = null; // Null image
            var giaNhap = 150.0f;
            var ngayNhap = DateTime.Now;

            // Act
            var save_click = new AddProductTests();
            save_click.btSave_Click(maSanPham, tenSanPham, phanLoai, donVi, soLuong, giaBan, hsd, image, giaNhap, ngayNhap, conn);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestHandleInvalidInputForSoLuong()
        {
            // Arrange
            var maSanPham = "SP003";
            var tenSanPham = "Product C";
            var phanLoai = "Category 3";
            var donVi = "pcs";
            var hsd = DateTime.Now.AddDays(90);
            var imageUri = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "E:\\2ndSemester3rdYear\\testt\\TestMart\\sieu_thi_mini\\Images\\logo1.png"));
            var image = new BitmapImage(imageUri);
            var ngayNhap = DateTime.Now;

            // Act
            // Act & Assert for invalid soLuong
            var save_click = new AddProductTests();
            save_click.btSave_Click(maSanPham, tenSanPham, phanLoai, donVi, int.Parse("invalid_soLuong"), 300.0f, hsd, image, 250.0f, ngayNhap, conn);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestHandleInvalidInputForGiaBan()
        {
            // Arrange
            var maSanPham = "SP004";
            var tenSanPham = "Product D";
            var phanLoai = "Category 4";
            var donVi = "pcs";
            var soLuong = 30;
            var hsd = DateTime.Now.AddDays(120);
            var imageUri = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "E:\\2ndSemester3rdYear\\testt\\TestMart\\sieu_thi_mini\\Images\\logo2.png"));
            var image = new BitmapImage(imageUri);
            var ngayNhap = DateTime.Now;

            // Act
            // Act & Assert for invalid giaBan
            var save_click = new AddProductTests();
            save_click.btSave_Click(maSanPham, tenSanPham, phanLoai, donVi, soLuong, float.Parse("invalid_giaBan"), hsd, image, 250.0f, ngayNhap, conn);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestHandleInvalidInputForGiaNhap()
        {
            // Arrange
            var maSanPham = "SP005";
            var tenSanPham = "Product E";
            var phanLoai = "Category 5";
            var donVi = "pcs";
            var soLuong = 40;
            var giaBan = 400.0f;
            var hsd = DateTime.Now.AddDays(150);
            var imageUri = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "E:\\2ndSemester3rdYear\\testt\\TestMart\\sieu_thi_mini\\Images\\logo.png"));
            var image = new BitmapImage(imageUri);
            var ngayNhap = DateTime.Now;

            // Act
            // Act & Assert for invalid giaNhap
            var save_click = new AddProductTests();
            save_click.btSave_Click(maSanPham, tenSanPham, phanLoai, donVi, soLuong, giaBan, hsd, image, float.Parse("invalid_giaNhap"), ngayNhap, conn);
        }
        
    }
}
