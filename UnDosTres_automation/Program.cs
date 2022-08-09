using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UnDosTres_automation
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
           // IWebDriver driverf = new FirefoxDriver();
            string url = "http://sanbox.undostres.com.mx";

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();


            Console.WriteLine("Url abierta" + url);

            try {

                rechargePhone rechargePhone = new rechargePhone();
                rechargePhone.Recharge(driver);

                Payment payment = new Payment();
                payment.paymentCard(driver);

                Success success = new Success();
                success.successScreen(driver);
                success.logOut(driver);

            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
            }


            Thread.Sleep(TimeSpan.FromSeconds(3));

            driver.Quit();
        }
    }
}
