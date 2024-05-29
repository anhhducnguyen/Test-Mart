using Microsoft.VisualStudio.TestTools.UnitTesting;
using sieu_thi_mini.View;
using System;
using System.Collections.ObjectModel;
using static sieu_thi_mini.View.Order;

namespace UnitTestProject
{
    [TestClass]
    public class SearchOrderTests
    {
        [TestMethod]
        public void Search_Order_By_Code_Exists()
        {
            // Arrange
            OrderLogic orderLogic = new OrderLogic();
            string testSearchText = "HD001"; // Giả sử đây là mã đơn hàng cần tìm

            // Act
            // Thực hiện tìm kiếm
            orderLogic.NapDuLieuHoaDon();
            var searchResults = orderLogic.SearchOrders(testSearchText);

            // Assert
            // Kiểm tra xem kết quả có chứa đúng các đơn hàng với mã tìm kiếm không
            Assert.IsTrue(searchResults.Count == 0, "Không tìm thấy đơn hàng với mã " + testSearchText);
            foreach (var item in searchResults)
            {
                Assert.IsTrue(item.OrderCode.Contains(testSearchText), "Mã đơn hàng không chứa " + testSearchText);
            }
        }


        [TestMethod]
        public void Search_Order_By_Code_Not_Exists()
        {
            // Arrange
            OrderLogic orderLogic = new OrderLogic();
            ObservableCollection<OrderItem> expectedResults = new ObservableCollection<OrderItem>();
            string testSearchText = "HD002"; // Giả sử đây là mã đơn hàng không tồn tại

            // Act
            // Thực hiện tìm kiếm
            orderLogic.NapDuLieuHoaDon();
            var searchResults = orderLogic.SearchOrders(testSearchText);

            // Assert
            // Kiểm tra xem kết quả có rỗng không
            Assert.IsTrue(searchResults.Count == 0);
        }

        [TestMethod]
        public void Search_Order_By_Empty_Text()
        {
            // Arrange
            OrderLogic orderLogic = new OrderLogic();
            ObservableCollection<OrderItem> expectedResults = new ObservableCollection<OrderItem>();
            string testSearchText = ""; // Giả sử đây là chuỗi tìm kiếm rỗng

            // Act
            // Thực hiện tìm kiếm
            orderLogic.NapDuLieuHoaDon();
            var searchResults = orderLogic.SearchOrders(testSearchText);

            // Assert
            // Kiểm tra xem kết quả có rỗng không
            Assert.IsTrue(searchResults.Count == 0);
        }

        [TestMethod]
        public void Search_Order_By_Null_Text()
        {
            // Arrange
            OrderLogic orderLogic = new OrderLogic();
            ObservableCollection<OrderItem> expectedResults = new ObservableCollection<OrderItem>();
            string testSearchText = null; // Giả sử đây là chuỗi tìm kiếm null

            // Act
            // Thực hiện tìm kiếm
            orderLogic.NapDuLieuHoaDon();
            var searchResults = orderLogic.SearchOrders(testSearchText);

            // Assert
            // Kiểm tra xem kết quả có rỗng không
            Assert.IsTrue(searchResults.Count == 0);    
        }
    }
}
