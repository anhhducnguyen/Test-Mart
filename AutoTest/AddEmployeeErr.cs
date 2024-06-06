using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;
using System;

namespace AutoTest
{
    [TestClass]
    public class AddEmployeeErr
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
        public void AddEmployeeIDErr()
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

            // Tìm nút thêm và nhấn nút
            var editButton = driver.FindElementById("btAdd");
            Assert.IsNotNull(editButton, "Không tìm thấy nút thêm nhân viên.");
            editButton.Click();

            // Tìm ô nhập số điện thoại và thay đổi giá trị
            var nameField = driver.FindElementById("txtTenNhanVien");
            Assert.IsNotNull(nameField, "Không tìm thấy ô nhập tên.");
            nameField.Clear();
            nameField.SendKeys("Nguyễn Văn A");

            // Tìm ô nhập giới tính và thay đổi giá trị
            var sexField = driver.FindElementById("txtGioiTinh");
            Assert.IsNotNull(sexField, "Không tìm thấy ô nhập giới tính.");
            sexField.Clear();
            sexField.SendKeys("Nam");

            // Tìm ô nhập tên đăng nhập và thay đổi giá trị
            var accountField = driver.FindElementById("txtTenDangNhap");
            Assert.IsNotNull(accountField, "Không tìm thấy ô nhập tên đn.");
            accountField.Clear();
            accountField.SendKeys("kien");

            // Tìm ô nhập ngày sinh và thay đổi giá trị
            var birthdayField = driver.FindElementById("txtNgaySinh");
            Assert.IsNotNull(birthdayField, "Không tìm thấy ô nhập số điện thoại.");
            birthdayField.Clear();
            birthdayField.SendKeys("01/01/2003");

            // Tìm ô nhập số điện thoại và thay đổi giá trị
            var phoneNumberField = driver.FindElementById("txtSoDienThoai");
            Assert.IsNotNull(phoneNumberField, "Không tìm thấy ô nhập số điện thoại.");
            phoneNumberField.Clear();
            phoneNumberField.SendKeys("0123456789");

            // Tìm ô nhập số điện thoại và thay đổi giá trị
            var addField = driver.FindElementById("txtDiaChi");
            Assert.IsNotNull(addField, "Không tìm thấy ô nhập địa chỉ.");
            addField.Clear();
            addField.SendKeys("Hà Nội");

            // Tìm ô nhập email và thay đổi giá trị
            var emailField = driver.FindElementById("txtEmail");
            Assert.IsNotNull(emailField, "Không tìm thấy ô nhập email.");
            emailField.Clear();
            emailField.SendKeys("kien@gmail.com");

            // Tìm ô nhập pass và thay đổi giá trị
            var pwField = driver.FindElementById("txtMatKhau");
            Assert.IsNotNull(pwField, "Không tìm thấy ô nhập pass.");
            pwField.Clear();
            pwField.SendKeys("1234");

            // Tìm nút lưu và nhấn nút
            var saveButton = driver.FindElementById("btSave");
            Assert.IsNotNull(saveButton, "Không tìm thấy nút lưu.");
            saveButton.Click();


            // Đợi để kiểm tra kết quả lưu
            //System.Threading.Thread.Sleep(1000);
        }
    }
}
