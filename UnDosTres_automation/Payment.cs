using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UnDosTres_automation
{
    class Payment
    {
        public void paymentCard(IWebDriver driver) {
            //Payment
            string cardNumber = "4111111111111111";
            string month = "11";
            string date = "25";
            string cvv = "111";
            string email = "test@test.com";
            string emailLogin = "automationUDT1@gmail.com";
            string pass = "automationUDT123";
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            //Select payment method 
            Thread.Sleep(TimeSpan.FromSeconds(3));
            IWebElement selectPayment = driver.FindElement(By.XPath("/html/body/div[34]/div[1]/div[3]/div/div[1]"));
            IList<IWebElement> selectCard = selectPayment.FindElements(By.TagName("a"));
            if (selectCard.Count > 0)
            {
                selectCard[1].Click();
                Console.WriteLine("Se a seleccionado el metodo de pago Tarjeta");
            }

            //Select new card 
            IWebElement selectNewCard = driver.FindElement(By.XPath("//*[@id='default_panel']/div/div[1]/table"));
            List<IWebElement> lstTrNewCard = new List<IWebElement>(selectNewCard.FindElements(By.TagName("tr")));
            string strRowData = "";

            foreach (var elemTr in lstTrNewCard) {
                List<IWebElement> lstTdNewCard = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdNewCard.Count > 0)
                {
                    foreach (var elemTd in lstTdNewCard)
                    {
                        strRowData = strRowData + elemTd.Text + "\t\t";

                    }

                    lstTrNewCard[0].Click();
                }
                else {
                    Console.WriteLine("This is Header Row");
                    Console.WriteLine(lstTrNewCard[0].Text.Replace(" ", "\t\t"));
                }

                Console.WriteLine(strRowData);
                strRowData = String.Empty;

               

            }

            Thread.Sleep(TimeSpan.FromSeconds(3));

            //Inputs NewCard
            IWebElement inputNewCard = driver.FindElement(By.Id("cardnumberunique")) ;
            inputNewCard.SendKeys(cardNumber);

            IWebElement inputMonth = driver.FindElement(By.XPath("//*[@id='payment-form']/div[3]/div[1]/div/div[1]/input"));
            inputMonth.SendKeys(month);

            IWebElement inputYear = driver.FindElement(By.XPath("//*[@id='payment-form']/div[3]/div[1]/div/div[3]/input"));
            inputYear.SendKeys(date);

            IWebElement inputCvv = driver.FindElement(By.XPath("//*[@id='payment-form']/div[3]/div[2]/div/input"));
            inputCvv.SendKeys(cvv);

            IWebElement inputMail = driver.FindElement(By.XPath("//*[@id='payment-form']/div[4]/div/div/input"));
            inputMail.SendKeys(email);


            IWebElement btnPay = driver.FindElement(By.Id("paylimit"));
            btnPay.Click();

            //Input Usr 
            Thread.Sleep(TimeSpan.FromSeconds(3));
            IWebElement inputUsr = driver.FindElement(By.XPath("//*[@id='usrname']"));
            inputUsr.SendKeys(emailLogin);

            IWebElement inputPass = driver.FindElement(By.Id("psw"));
            inputPass.SendKeys(pass);

            Thread.Sleep(TimeSpan.FromSeconds(3));

            //Select Captcha 
            customWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@title='reCAPTCHA']")));
            var check = driver.FindElement(By.Id("recaptcha-anchor"));
            check.Click();

            //
            customWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[5]/div/div/div[2]/div[2]/table/tbody/tr/td/div/div[1]/form/button")));
            var btnUsr = driver.FindElement(By.Id("loginBtn"));
            btnUsr.Click();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");


            Thread.Sleep(TimeSpan.FromSeconds(120));


        }

    }
}
