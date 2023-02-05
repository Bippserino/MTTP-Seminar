using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace mttpp_seminar
{
    public class Tests
    {

        [TestFixture]
        public class FirstTest
        {
            private IWebDriver driver;
            private string DriverPath { get; set; } = @"C:\chromedriver_win32";

            private void SearchOnAmazon(string search)
            {
                driver.Navigate().GoToUrl("https://www.amazon.com");
                driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(search);
                driver.FindElement(By.Id("nav-search-submit-button")).Click();
            }

            private Product AddFirstProductToCard(int quantity = 1)
            {
                driver.FindElement(By.ClassName("s-image")).Click();

                string title = driver.FindElement(By.Id("productTitle")).Text;
                string price = driver.FindElement(By.ClassName("a-offscreen")).Text;

                Product product = new Product(title, price);
                if (quantity != 1) ChangeQuantity(quantity);

                driver.FindElement(By.Id("add-to-cart-button")).Click();
                return product;
            }

            private void ChangeQuantity(int quantity)
            {
                driver.FindElement(By.ClassName("a-button-inner")).Click();
                driver.FindElement(By.Id("quantity_" + (quantity - 1))).Click();
            }

            [SetUp]
            public void SetUp()
            {
                var options = new ChromeOptions();
                driver = new ChromeDriver(DriverPath, options, TimeSpan.FromSeconds(300));
                driver.Manage().Window.Maximize();
            }

            [Test]
            public void TestCase1_SearchForProduct()
            {
                SearchOnAmazon("Headphones");                
                string title = driver.Title;
                Assert.AreEqual("Amazon.com : Headphones", title);
            }

            [Test]
            public void TestCase2_AddProductToCart()
            {
                SearchOnAmazon("logitech");
                Product product = AddFirstProductToCard();
                string total = driver.FindElement(By.ClassName("a-offscreen")).Text;
                Assert.AreEqual(total, product.Price);
            }
            [Test]
            public void TestCase3_AddMultipleProductToCart()
            {
                SearchOnAmazon("logitech");
                Product product = AddFirstProductToCard(3);
                string total = driver.FindElement(By.ClassName("a-offscreen")).Text;
                Assert.AreEqual(total, product.Price);
            }

            [Test]
            public void TestCase4_GoToCart()
            {
                driver.Navigate().GoToUrl("https://www.amazon.com/");
                driver.FindElement(By.Id("nav-cart")).Click();
                string title = driver.Title;
                Assert.AreEqual("Amazon.com Shopping Cart", title);
            }

            [Test]
            public void TestCase5_UpdateQuantityInCart()
            {
                SearchOnAmazon("logitech");
                Product product = AddFirstProductToCard();
                driver.Navigate().GoToUrl("https://www.amazon.com/cart");

                string previousPrice = driver.FindElement(By.ClassName("sc-price")).Text;

                driver.FindElement(By.ClassName("a-dropdown-label")).Click();
                driver.FindElement(By.Id("quantity_3")).Click();
                Thread.Sleep(4000);

                string currentPrice = driver.FindElement(By.ClassName("sc-price")).Text;
                Assert.AreNotEqual(currentPrice, previousPrice);
            }

            [Test]
            public void TestCase6_ProceedToCheckout()
            {
                SearchOnAmazon("logitech");
                Product product = AddFirstProductToCard();
                Thread.Sleep(4000);
                driver.Navigate().GoToUrl("https://www.amazon.com/cart");
                Thread.Sleep(4000);
                driver.FindElement(By.ClassName("a-button-inner")).Click();
                string title = driver.Title;
                Assert.AreEqual("Amazon Sign-In", title);
            }

            [TearDown]
            public void TearDown()
            {
                driver.Quit();
            }
        }

    }
}

