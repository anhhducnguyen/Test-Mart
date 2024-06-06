using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using sieu_thi_mini;
using System;
using System.Windows.Controls;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestCreatePDFInvoice()
        {
            // Arrange
            OrderDetail orderDetail = new OrderDetail("HD001", "NV001", DateTime.Now, TimeSpan.FromHours(10), 1000000, "Completed");
            DataGrid dataGrid = new DataGrid();

            // Add columns
            dataGrid.Columns.Add(new DataGridTextColumn { Header = "maHD", Binding = new System.Windows.Data.Binding("maHD") });
            dataGrid.Columns.Add(new DataGridTextColumn { Header = "maSP", Binding = new System.Windows.Data.Binding("maSP") });
            dataGrid.Columns.Add(new DataGridTextColumn { Header = "tenSP", Binding = new System.Windows.Data.Binding("tenSP") });
            dataGrid.Columns.Add(new DataGridTextColumn { Header = "soL", Binding = new System.Windows.Data.Binding("soL") });
            dataGrid.Columns.Add(new DataGridTextColumn { Header = "donG", Binding = new System.Windows.Data.Binding("donG") });
            dataGrid.Columns.Add(new DataGridTextColumn { Header = "thanhT", Binding = new System.Windows.Data.Binding("thanhT") });

            // Add rows
            dataGrid.Items.Add(new MatHang { maHD = "HD001", maSP = "SP001", tenSP = "Product 1", soL = 2, donG = 50000, thanhT = 100000 });

            string pdfPath = @"E:\2ndSemester3rdYear\testt\TestMart\sieu_thi_mini\FilePDF\HD001.pdf";

            // Act
            orderDetail.CreatePDFInvoice1("HD001", "NV001", "01/01/2021", "10:00:00", "1000000đ", dataGrid);

            // Assert
            Assert.IsTrue(File.Exists(pdfPath), "PDF file should be created.");

            // Clean up
            //if (File.Exists(pdfPath))
            //{
            //    File.Delete(pdfPath);
            //}
        }
    }
}
