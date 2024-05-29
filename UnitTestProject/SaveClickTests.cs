using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using sieu_thi_mini.View;
using static sieu_thi_mini.View.Products;

namespace UnitTestProject
{
    [TestClass]
    public class SaveClickTests
    {
        private string testConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLySieuThi;Integrated Security=True;";

        [TestMethod]
        public void SaveOrder_WithValidData_SavesSuccessfully()
        {
            // Arrange
            var productService = new ProductService(testConnectionString);
            string maHoaDon = "HD001";
            string manv = "NV001";
            double totalPrice = 1000;
            var listFood = new ObservableCollection<ThongTinMatHang>
            {
                new ThongTinMatHang
                {
                    maSanPham = "SP001",
                    tenSanPham = "Product 1",
                    soLuong = 1,
                    donGia = 1000,
                    thanhTien = 1000
                }
            };

            // Act
            string result = productService.SaveOrder(maHoaDon, manv, totalPrice, listFood);

            // Assert
            Assert.IsNull(result, "Expected no error message");
        }

        [TestMethod]
        public void SaveOrder_WhenProductQuantityIsInsufficient_ReturnsErrorMessage()
        {
            // Arrange
            var productService = new ProductService(testConnectionString);
            string maHoaDon = "HD002";
            string manv = "NV001";
            double totalPrice = 300000;
            var listFood = new ObservableCollection<ThongTinMatHang>
            {
                new ThongTinMatHang
                {
                    maSanPham = "SP004",
                    tenSanPham = "Bánh mì",
                    soLuong = 20, // Set to a high value to simulate insufficient quantity
                    donGia = 15000,
                    thanhTien = 300000
                }
            };

            // Act
            string result = productService.SaveOrder(maHoaDon, manv, totalPrice, listFood);

            // Assert
            //Assert.IsNotNull(result, "Expected an error message");
            Assert.AreEqual($"Sản phẩm 'Product 2' đã hết hàng hoặc không đủ số lượng.", result);
        }

        [TestMethod]
        public void SaveOrder_WhenProductDoesNotExist_ReturnsErrorMessage()
        {
            // Arrange
            var productService = new ProductService(testConnectionString);
            string maHoaDon = "HD001";
            string manv = "NV001";
            double totalPrice = 1200;
            var listFood = new ObservableCollection<ThongTinMatHang>
            {
                new ThongTinMatHang
                {
                    maSanPham = "SP099", // Non-existent product ID
                    tenSanPham = "Nước ngọt",
                    soLuong = 1,
                    donGia = 1200,
                    thanhTien = 1200
                }
            };

            // Act
            string result = productService.SaveOrder(maHoaDon, manv, totalPrice, listFood);

            // Assert
            Assert.IsNotNull(result, "Expected an error message");
            Assert.AreEqual("Sản phẩm 'Non-existent product' không tồn tại.", result);
        }

        [TestMethod]
        public void SaveOrder_WhenDatabaseConnectionFails_ReturnsErrorMessage()
        {
            // Arrange
            var invalidConnectionString = @"Data Source=INVALID;Initial Catalog=QuanLySieuThi;Integrated Security=True;";
            //var invalidConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLySieuThi;Integrated Security=True;";
            //var productService = new ProductService(testConnectionString);
            var productService = new ProductService(invalidConnectionString);
            string maHoaDon = "HD004";
            string manv = "NV001";
            double totalPrice = 1000;
            var listFood = new ObservableCollection<ThongTinMatHang>
            {
                new ThongTinMatHang
                {
                    maSanPham = "SP001",
                    tenSanPham = "Product 1",
                    soLuong = 1,
                    donGia = 1000,
                    thanhTien = 1000
                }
            };

            // Act
            string result = productService.SaveOrder(maHoaDon, manv, totalPrice, listFood);

            // Assert
            Assert.IsNotNull(result, "Expected an error message");
            Assert.AreEqual("Không thể kết nối tới cơ sở dữ liệu.", result);
        }

        [TestMethod]
        public void SaveOrder_WithEmptyOrderDetails_ShouldFail()
        {
            // Arrange
            var productService = new ProductService(testConnectionString);
            string maHoaDon = "HD001";
            string manv = "NV001";
            double totalPrice = 0;
            var listFood = new ObservableCollection<ThongTinMatHang>(); // Empty order details

            // Act
            string result = productService.SaveOrder(maHoaDon, manv, totalPrice, listFood);

            // Assert
            Assert.IsNotNull(result, "Expected an error message due to empty order details");
            Assert.AreEqual("Order must contain at least one product.", result);
        }


    }
}
