using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Collections.Generic;
using static sieu_thi_mini.View.Employees;

namespace UnitTestProject
{
    [TestClass]
    public class SearchEmployeeTest
    {
        //private string connectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLySieuThi;Integrated Security=True;";

        [TestMethod]
        public void TestSearchEmployee_ExistingEmployee_Success()
        {
            var searchTest = new SearchEmployeeTests();

            // Search for an existing employee
            List<string> results = searchTest.btSearch_Click("Nguyễn Đức Anh");

            // Assert that 'Trần Duy Bim' is found in the database
            Assert.IsTrue(results.Contains("Nguyễn Đức Anh"), "Expected to find 'Nguyễn Đức Anh' in the database.");
        }

        [TestMethod]
        public void TestSearchEmployee_ExistingEmployee_Lower()
        {
            var searchTest = new SearchEmployeeTests();

            // Search for an existing employee
            List<string> results = searchTest.btSearch_Click("nguyễn đức anh");

            // Assert that 'Trần Duy Bim' is found in the database
            Assert.IsTrue(results.Contains("Nguyễn Đức Anh"), "Expected to find 'Nguyễn Đức Anh' in the database.");
        }

        [TestMethod]
        public void TestSearchEmployee_ExistingEmployee_Upper()
        {
            var searchTest = new SearchEmployeeTests();

            // Search for an existing employee
            List<string> results = searchTest.btSearch_Click("NGUYỄN ĐỨC ANH");

            // Assert that 'Trần Duy Bim' is found in the database
            Assert.IsTrue(results.Contains("Nguyễn Đức Anh"), "Expected to find 'Nguyễn Đức Anh' in the database.");
        }

        [TestMethod]
        public void TestSearchEmployee_ExistingEmployee_NotFound()
        {
            var searchTest = new SearchEmployeeTests();

            // Search for a non-existent employee
            List<string> results = searchTest.btSearch_Click("nonexistent");

            // Assert that no results are found
            Assert.AreEqual(0, results.Count, "Expected to find no matching results in the database.");
        }

        [TestMethod]
        public void TestSearchEmployee_ExistingEmployee_MultipleResults()
        {
            var searchTest = new SearchEmployeeTests();

            // Search for a common name to test multiple results
            List<string> results = searchTest.btSearch_Click("Nguyen");

            // Assert that all results contain 'Nguyen'
            foreach (string result in results)
            {
                Assert.IsTrue(result.Contains("Nguyen"), "Expected all results to contain 'Nguyen'.");
            }
        }

        [TestMethod]
        public void TestSearchEmployee_NoResults_EmptyString()
        {
            var searchTest = new SearchEmployeeTests();

            // Search with an empty string
            List<string> results = searchTest.btSearch_Click("");

            // Assert that no results are found
            Assert.AreEqual(0, results.Count, "Expected to find no matching results in the database.");
        }

        [TestMethod]
        public void TestSearchEmployee_NoResults_NonexistentString()
        {
            var searchTest = new SearchEmployeeTests();

            // Search for a non-existent string
            List<string> results = searchTest.btSearch_Click("nonexistent");

            // Assert that no results are found
            Assert.AreEqual(0, results.Count, "Expected to find no matching results in the database.");
        }

        [TestMethod]
        public void TestSearchEmployee_SqlInjection()
        {
            var searchTest = new SearchEmployeeTests();

            // Search with a string that could be used for SQL injection
            List<string> results = searchTest.btSearch_Click("'; DROP TABLE tblNhanVien; --");

            // Assert that no results are found and database is not affected
            Assert.AreEqual(0, results.Count, "Expected to find no matching results in the database.");
            // Additional assertion to ensure table tblNhanVien is not dropped
            // You may need to implement this based on your database setup
        }

        [TestMethod]
        public void TestSearchEmployee_NullSearchString()
        {
            var searchTest = new SearchEmployeeTests();

            // Search with null search string
            List<string> results = searchTest.btSearch_Click(null);

            // Assert that no results are found
            Assert.AreEqual(0, results.Count, "Expected to find no matching results in the database.");
        }

        [TestMethod]
        public void TestSearchEmployee_SpecialCharacters()
        {
            var searchTest = new SearchEmployeeTests();

            // Search with special characters
            List<string> results = searchTest.btSearch_Click("@#$%");

            // Assert that all results contain the special characters
            foreach (string result in results)
            {
                Assert.IsTrue(result.Contains("@#$%"), "Expected all results to contain '@#$%'.");
            }
        }


    }
}