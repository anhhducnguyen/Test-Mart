using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using sieu_thi_mini;
using static sieu_thi_mini.Login;

namespace UnitTestProject
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Test_ValidateLogin_Success()
        {
            // Test case: Correct username and password
            // Arrange
            var login = new login();
            string username = "bim";
            string password = "1234"; // Ensure this matches the encoded password in the database for the test

            // Acts
            bool result = login.ValidateLogin(username, password);

            // Asserts
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_ValidateLogin_Failure()
        {
            // Test case: Incorrect username and password
            // Arrange
            var login = new login();
            string username = "wrongUser";
            string password = "wrongPassword";

            // Acts
            bool result = login.ValidateLogin(username, password);

            // Asserts
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_ValidateLogin_NonExistentUser()
        {
            // Test case: Non-existent username
            // Arrange
            var login = new login();
            string username = "nonExistentUser";
            string password = "anyPassword";

            // Act
            bool result = login.ValidateLogin(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_ValidateLogin_WrongPassword()
        {
            // Test case: Correct username but incorrect password
            // Arranges
            var login = new login();
            string username = "bim";
            string password = "wrongPassword";

            // Act
            bool result = login.ValidateLogin(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_ValidateLogin_EmptyUsername()
        {
            // Test case: Empty username
            // Arrange
            var login = new login();
            string username = "";
            string password = "1234";

            // Act
            bool result = login.ValidateLogin(username, password);

            // Assert
            Assert.IsFalse(result);
        }
      
        [TestMethod]
        public void Test_ValidateLogin_EmptyPassword()
        {
            // Test case: Empty password
            // Arrange
            var login = new login();
            string username = "bim";
            string password = "";

            // Act
            bool result = login.ValidateLogin(username, password);

            // Assert
            Assert.IsFalse(result);
        }
        
    }
}


