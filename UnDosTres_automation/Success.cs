using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace UnDosTres_automation
{
    class Success
    {
        public void successScreen(IWebDriver driver) {

            IWebElement notallow = driver.FindElement(By.Id("wzrk-confirm"));
            notallow.Click();

            IWebElement successRecharge = driver.FindElement(By.ClassName("visual-message"));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recarga exitosa");
        

        }

        public void logOut(IWebDriver driver) {
            IWebElement logOut = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div/div[2]/div[2]/div[5]"));
            logOut.Click();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cerrando sesión");
        
        }
    }
}
