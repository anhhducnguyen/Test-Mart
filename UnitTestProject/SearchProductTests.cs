﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using sieu_thi_mini.View;
using static sieu_thi_mini.View.Products;
using System.Collections.ObjectModel;

namespace UnitTestProject
{
//|---------|-------------------------------------------------------------|
//|stt      |Name TestCase                                                |
//|---------|-------------------------------------------------------------|
//|1        |Search_WithEmptySearchString_ShouldDoNothing                 |
//|---------|-------------------------------------------------------------|
//|2        |Search_WithMatchingSearchString_ShouldReturnResults          |
//|---------|-------------------------------------------------------------|
//|3        |Search_WithNonMatchingSearchString_ShouldReturnNoResults     |
//|---------|-------------------------------------------------------------|
//|4        |Search_WithMultipleMatchingResults_ShouldReturnAllResults    |
//|---------|-------------------------------------------------------------|
//|5        |Search_WithCaseInsensitiveSearchString_ShouldReturnResults   |
//|---------|-------------------------------------------------------------|
//|6        |Search_WithSpecialCharacters_ShouldHandleGracefully          |
//|---------|-------------------------------------------------------------|
//|7        |Search_WithPartialMatchingSearchString_ShouldReturnResults   |
//|---------|-------------------------------------------------------------|
//|8        |Search_WithException_ShouldHandleGracefully                  |
//|---------|-------------------------------------------------------------|

 
    [TestClass]
    public class SearchProductTests
    {
        [TestMethod]
        public void Search_WithEmptySearchString_ShouldDoNothing()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems.Add(new MenuItem { Name = "Apple" });
            string search = "";

            // Act
            productService.Search(search, viewModel);

            // Assert
            Assert.AreEqual(5, viewModel.FoodItems.Count);
            //Assert.AreEqual("BIm Bim", viewModel.FoodItems[0].Name);
        }

        [TestMethod]
        public void Search_WithMatchingSearchString_ShouldReturnResults()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems.Add(new MenuItem { Name = "Apple" });
            viewModel.FoodItems.Add(new MenuItem { Name = "Banana" });
            string search = "Apple";

            // Act
            productService.Search(search, viewModel);

            // Assert
            Assert.AreEqual(1, viewModel.FoodItems.Count);
            Assert.AreEqual("Apple", viewModel.FoodItems[0].Name);
        }

        [TestMethod]
        public void Search_WithNonMatchingSearchString_ShouldReturnNoResults()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems.Add(new MenuItem { Name = "Apple" });
            viewModel.FoodItems.Add(new MenuItem { Name = "Banana" });
            string search = "Orange";

            // Act
            productService.Search(search, viewModel);

            // Assert
            Assert.AreEqual(0, viewModel.FoodItems.Count);
        }

        [TestMethod]
        public void Search_WithMultipleMatchingResults_ShouldReturnAllResults()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems.Add(new MenuItem { Name = "Apple" });
            viewModel.FoodItems.Add(new MenuItem { Name = "Green Apple" });
            viewModel.FoodItems.Add(new MenuItem { Name = "Banana" });
            string search = "Apple";

            // Act
            productService.Search(search, viewModel);

            // Assert
            Assert.AreEqual(2, viewModel.FoodItems.Count);
            Assert.AreEqual("Apple", viewModel.FoodItems[0].Name);
            Assert.AreEqual("Green Apple", viewModel.FoodItems[1].Name);
        }

        [TestMethod]
        public void Search_WithCaseInsensitiveSearchString_ShouldReturnResults()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems.Clear();
            viewModel.FoodItems.Add(new MenuItem { Name = "Apple" });
            viewModel.FoodItems.Add(new MenuItem { Name = "Banana" });
            string search = "apple";
            //string search = "APPLE";

            // Act
            productService.Search(search, viewModel);

            // Assert
            Assert.AreEqual(1, viewModel.FoodItems.Count);
            Assert.AreEqual("Apple", viewModel.FoodItems[0].Name);
        }

        [TestMethod]
        public void Search_WithSpecialCharacters_ShouldHandleGracefully()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems.Clear();
            viewModel.FoodItems.Add(new MenuItem { Name = "Apple" });
            viewModel.FoodItems.Add(new MenuItem { Name = "Banana" });
            string search = "@#!";

            // Act
            productService.Search(search, viewModel);

            // Assert
            Assert.AreEqual(0, viewModel.FoodItems.Count);
        }

        [TestMethod]
        public void Search_WithPartialMatchingSearchString_ShouldReturnResults()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems.Clear();
            viewModel.FoodItems.Add(new MenuItem { Name = "Apple" });
            viewModel.FoodItems.Add(new MenuItem { Name = "Banana" });
            string search = "App";

            // Act
            productService.Search(search, viewModel);

            // Assert
            Assert.AreEqual(1, viewModel.FoodItems.Count);
            Assert.AreEqual("Apple", viewModel.FoodItems[0].Name);
        }

        [TestMethod]
        public void Search_WithException_ShouldHandleGracefully()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems = null; // This will cause a NullReferenceException
            string search = "Apple";

            // Act & Assert
            try
            {
                productService.Search(search, viewModel);
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (NullReferenceException)
            {
                // Exception was thrown as expected
            }
        }
        [TestMethod]
        public void Search_WithMatchingSearchString_ShouldReturnResul()
        {
            // Arrange
            var productService = new ProductService(new ObservableCollection<ThongTinMatHang>());
            var viewModel = new MenuViewModel();
            viewModel.FoodItems.Add(new MenuItem { Name = "Apple" });
            viewModel.FoodItems.Add(new MenuItem { Name = "Banana" });
            string search = " Apple ";

            // Act
            productService.Search(search, viewModel);

            // Assert
            Assert.AreEqual(1, viewModel.FoodItems.Count);
            Assert.AreEqual("Apple", viewModel.FoodItems[0].Name);
        }
    }
}
