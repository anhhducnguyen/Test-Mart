﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;
using System;

namespace AutoTest
{
    [TestClass]
    public class LoginTest
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
        public void TestLoginFunctionality()
        {
            // Kiểm tra xem driver đã được khởi động thành công hay chưa
            Assert.IsNotNull(driver, "Không thể khởi động ứng dụng.");

            // Tìm ô nhập tên người dùng và nhập tên
            var usernameField = driver.FindElementById("txtUser");
            Assert.IsNotNull(usernameField, "Không tìm thấy ô nhập tên người dùng.");
            usernameField.SendKeys("kien");

            // Tìm ô nhập mật khẩu và nhập mật khẩu
            var passwordField = driver.FindElementById("pwbPassWord");
            Assert.IsNotNull(passwordField, "Không tìm thấy ô nhập mật khẩu.");
            passwordField.SendKeys("1234");

            // Tìm nút đăng nhập và nhấn nút
            var loginButton = driver.FindElementById("btnLogin");
            Assert.IsNotNull(loginButton, "Không tìm thấy nút đăng nhập.");
            loginButton.Click();

            // Đợi để kiểm tra kết quả đăng nhập
            System.Threading.Thread.Sleep(2000);

        }


    }
}