using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;


namespace UnDosTres_automation
{
    class rechargePhone
    {
        public void Recharge(IWebDriver driver) {


            // Recarga celular
            string rechargefill = "//a[@class='list mobile']";
            string inputPhone = "//*[@id='col-sm-12']/form/div/div[1]/div[1]/div[2]/ul/li[1]/div/div/input";
            string inputCompany = "//*[@id='col-sm-12']/form/div/div[1]/div[1]/div[2]/ul/li[2]/div/div/input";
            string inputsaldo = "//*[@id='col-sm-12']/form/div/div[1]/div[1]/div[2]/ul/li[3]/div/div/input";
            string phone = "8465433546";

            Console.WriteLine("Recarga Iniciada");
            IWebElement xpathRecarga = driver.FindElement(By.XPath(rechargefill));
            xpathRecarga.Click();

            //Rellenar inputs
            IWebElement phoneNumber = driver.FindElement(By.XPath(inputPhone));
            phoneNumber.SendKeys(phone);
            Console.WriteLine("Telefono" + phone);

            IWebElement pathCompany = driver.FindElement(By.XPath(inputCompany));
            pathCompany.Click();

            IWebElement selectCompany = driver.
                FindElement(By.XPath("//*[@id='col-sm-12']/form/div/div[1]/div[1]/div[2]/ul/li[2]/div/div/div"));
            IList<IWebElement> listcompany = selectCompany.
                FindElement(By.TagName("ul")).FindElements(By.TagName("li"));

            if (listcompany.Count > 0)
            {
                listcompany[0].Click();
            }


            IWebElement pathSaldo = driver.FindElement(By.XPath(inputsaldo));
            pathSaldo.Click();


            IWebElement selectSaldo = driver.
                FindElement(By.XPath("//*[@id='col-sm-12']/form/div/div[1]/div[1]/div[2]/ul/li[3]/div/div/div"));
            IList<IWebElement> listSaldo = selectSaldo.
                FindElement(By.TagName("ul")).FindElements(By.TagName("li"));

            if (listSaldo.Count > 0)
            {
                listSaldo[0].Click();
            }

            Thread.Sleep(TimeSpan.FromSeconds(3));

            IWebElement classButton = driver.FindElement(By.ClassName("next"));
            IReadOnlyList<IWebElement> btnNext = classButton.
                FindElements(By.TagName("button"));
            if (btnNext.Count > 0)
            {
                btnNext[0].Click();
                Console.WriteLine("Redirigue al proceso de pago");
            }
           
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }
}
