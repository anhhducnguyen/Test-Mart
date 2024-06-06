using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;
using System;

namespace AutoTest
{
    [TestClass]
    public class ForgetPW
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
        public void TestFordetPw()
        {
            // Kiểm tra xem driver đã được khởi động thành công hay chưa
            Assert.IsNotNull(driver, "Không thể khởi động ứng dụng.");

            // Tìm nút quên mật khẩu và nhấn nút
            var forgetbtn = driver.FindElementById("lblForgetPassword");
            Assert.IsNotNull(forgetbtn, "Không tìm thấy nút đăng nhập.");
            forgetbtn.Click();

            // Tìm ô nhập email và nhập tên
            var emailField = driver.FindElementById("txtEmail");
            Assert.IsNotNull(emailField, "Không tìm thấy ô nhập tên người dùng.");
            emailField.SendKeys("kien@gmail.com");

            // Tìm nút lấy lại mk và nhấn nút
            var btconfirm = driver.FindElementById("btconfirm");
            Assert.IsNotNull(forgetbtn, "Không tìm thấy nút lấy lại mk.");
            btconfirm.Click();

            System.Threading.Thread.Sleep(1000);


        }
    }

}
