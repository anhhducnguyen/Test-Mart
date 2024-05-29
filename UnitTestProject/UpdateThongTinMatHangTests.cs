using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using sieu_thi_mini.View;
using static sieu_thi_mini.View.Products;

namespace UnitTestProject
{
    [TestClass]
    public class UpdateThongTinMatHangTests
    {
        [TestMethod]
        public void Test_UpdateThongTinMatHang_ValidUpdate()
        {
            // Arrange
            ObservableCollection<ThongTinMatHang> listFood = new ObservableCollection<ThongTinMatHang>();
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 1", soLuong = 1, donGia = 100 });
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 2", soLuong = 10, donGia = 200 });
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 3", soLuong = 10, donGia = 300 });

            ProductService productService = new ProductService(listFood);

            // Act
            productService.UpdateThongTinMatHang("Product 1", 2); // Update the quantity for Product 1
            productService.UpdateThongTinMatHang("Product 2", 20);
            productService.UpdateThongTinMatHang("Product 3", 30);

            // Assert for Product 1
            ThongTinMatHang updatedProduct1 = listFood[0];
            Assert.AreEqual(2, updatedProduct1.soLuong); // Ensure the quantity for Product 1 is updated correctly
            Assert.AreEqual(200, updatedProduct1.thanhTien);

            // Assert for Product 2
            ThongTinMatHang updatedProduct2 = listFood[1];
            Assert.AreEqual(20, updatedProduct2.soLuong); // Ensure the quantity for Product 2 is updated correctly
            Assert.AreEqual(4000, updatedProduct2.thanhTien);

            // Assert for Product 3
            ThongTinMatHang updatedProduct3 = listFood[2];
            Assert.AreEqual(30, updatedProduct3.soLuong); // Ensure the quantity for Product 3 is updated correctly
            Assert.AreEqual(9000, updatedProduct3.thanhTien);
        }

        
    }
}
