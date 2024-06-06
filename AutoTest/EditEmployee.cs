using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;
using System;

namespace AutoTest
{
    [TestClass]
    public class EditEmployee
    {
        private WiniumDriver driver;

        [TestInitialize]
        public void Setup()
        {
            DesktopOptions options = new DesktopOptions();
            options.ApplicationPath = @"E:\2ndSemester3rdYear\testt\TestMart\sieu_thi_mini\bin\Debug\sieu_thi_mini.exe"; // Đường dẫn đầy đủ tới ứng dụng của bạn

            // Khởi động Winium driver
            driver = new WiniumDriver(@"C:\Users\Admin\Desktop\", options);

            // Đợi một thời gian ngắn để driver khởi động và ứng dụng mở ra
            System.Threading.Thread.Sleep(5000);
        }

        [TestCleanup]
        public void Teardown()
        {
            // Đóng ứng dụng sau khi kiểm thử xong
            driver?.Quit();
        }

        [TestMethod]
        public void TestEditPhoneNumberAndSave()
        {
            // Tìm ô nhập tên người dùng và nhập tên
            var usernameField = driver.FindElementById("txtUser");
            Assert.IsNotNull(usernameField, "Không tìm thấy ô nhập tên người dùng.");
            usernameField.SendKeys("admin");

            // Tìm ô nhập mật khẩu và nhập mật khẩu
            var passwordField = driver.FindElementById("pwbPassWord");
            Assert.IsNotNull(passwordField, "Không tìm thấy ô nhập mật khẩu.");
            passwordField.SendKeys("1234");

            // Tìm nút đăng nhập và nhấn nút
            var loginButton = driver.FindElementById("btnLogin");
            Assert.IsNotNull(loginButton, "Không tìm thấy nút đăng nhập.");
            loginButton.Click();


            // Chuyển qua tab nhân viên
            var employeeButton = driver.FindElementById("btnEmployee");
            Assert.IsNotNull(employeeButton, "Không tìm thấy nút sản phẩm.");
            employeeButton.Click();

            System.Threading.Thread.Sleep(5000);

            //Employees employeesView = new Employees(); // Tạo một thể hiện mới của Employees UserControl

            //// Act
            //employeesView.AssignRowIds(); // Gọi phương thức SelectFirstRow









            // Tìm nút sửa và nhấn nút
            var editButton = driver.FindElementById("btEdit");
            Assert.IsNotNull(editButton, "Không tìm thấy nút sản phẩm.");
            editButton.Click();
            // Tìm ô nhập số điện thoại và thay đổi giá trị
            var phoneNumberField = driver.FindElementById("txtSoDienThoai");
            Assert.IsNotNull(phoneNumberField, "Không tìm thấy ô nhập số điện thoại.");
            phoneNumberField.Clear();
            phoneNumberField.SendKeys("0123456789");

            // Tìm nút lưu và nhấn nút
            var saveButton = driver.FindElementById("btSave");
            Assert.IsNotNull(saveButton, "Không tìm thấy nút lưu.");
            saveButton.Click();

            // Đợi để kiểm tra kết quả lưu
            System.Threading.Thread.Sleep(2000);

        }
    }
}
