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

        [TestMethod]
        public void Test_UpdateThongTinMatHang_ProductNotFound()
        {
            // Arrange
            ObservableCollection<ThongTinMatHang> listFood = new ObservableCollection<ThongTinMatHang>();
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 1", soLuong = 1, donGia = 100 });
            ProductService productService = new ProductService(listFood);

            // Act
            productService.UpdateThongTinMatHang("Product 2", 5); // Product 3 does not exist in the list

            // Assert
            Assert.AreEqual(1, listFood.Count); // Ensure no new product is added
            Assert.AreEqual(1, listFood[0].soLuong); // Ensure quantities of existing products remain unchanged
        }

        [TestMethod]
        public void Test_UpdateThongTinMatHang_ZeroQuantity()
        {
            // Arrange
            ObservableCollection<ThongTinMatHang> listFood = new ObservableCollection<ThongTinMatHang>();
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 1", soLuong = 1, donGia = 100 });
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 2", soLuong = 10, donGia = 200 });

            ProductService productService = new ProductService(listFood);

            // Act
            productService.UpdateThongTinMatHang("Product 1", 0); // Set quantity to zero

            // Assert
            ThongTinMatHang updatedProduct1 = listFood[0];
            Assert.AreEqual(0, updatedProduct1.soLuong); // Ensure the quantity is updated to zero
            Assert.AreEqual(0, updatedProduct1.thanhTien); // Total price should also be zero
        }

        [TestMethod]
        public void Test_UpdateThongTinMatHang_NegativeQuantity()
        {
            // Arrange
            ObservableCollection<ThongTinMatHang> listFood = new ObservableCollection<ThongTinMatHang>();
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 1", soLuong = 1, donGia = 100 });
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 2", soLuong = 10, donGia = 200 });

            ProductService productService = new ProductService(listFood);

            // Act
            productService.UpdateThongTinMatHang("Product 1", -5); // Attempt to set a negative quantity

            // Assert
            ThongTinMatHang updatedProduct1 = listFood[0];
            Assert.AreEqual(1, updatedProduct1.soLuong); // Ensure the quantity is unchanged
            Assert.AreEqual(100, updatedProduct1.thanhTien); // Total price should remain unchanged
        }

        [TestMethod]
        public void Test_UpdateThongTinMatHang_LargeQuantity()
        {
            // Arrange
            ObservableCollection<ThongTinMatHang> listFood = new ObservableCollection<ThongTinMatHang>();
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 1", soLuong = 1, donGia = 100 });
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 2", soLuong = 10, donGia = 200 });

            ProductService productService = new ProductService(listFood);

            // Act
            productService.UpdateThongTinMatHang("Product 2", 1000); // Update to a very large quantity

            // Assert
            ThongTinMatHang updatedProduct2 = listFood[1];
            Assert.AreEqual(1000, updatedProduct2.soLuong); // Ensure the quantity is updated correctly
            Assert.AreEqual(200000, updatedProduct2.thanhTien); // Ensure the total price is updated correctly
        }

        [TestMethod]
        public void Test_UpdateThongTinMatHang_DuplicateUpdate()
        {
            // Arrange
            ObservableCollection<ThongTinMatHang> listFood = new ObservableCollection<ThongTinMatHang>();
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 1", soLuong = 1, donGia = 100 });
            listFood.Add(new ThongTinMatHang { tenSanPham = "Product 2", soLuong = 10, donGia = 200 });

            ProductService productService = new ProductService(listFood);

            // Act
            productService.UpdateThongTinMatHang("Product 1", 5); // First update
            productService.UpdateThongTinMatHang("Product 1", 10); // Second update

            // Assert
            ThongTinMatHang updatedProduct1 = listFood[0];
            Assert.AreEqual(10, updatedProduct1.soLuong); // Ensure the quantity reflects the last update
            Assert.AreEqual(1000, updatedProduct1.thanhTien); // Ensure the total price reflects the last update
        }

    }
}
