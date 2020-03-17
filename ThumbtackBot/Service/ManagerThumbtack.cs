using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThumbtackBot.Service
{
    public class ManagerThumbtack
    {
        private IWebDriver driver = null;
        private bool IsStart { get; set; }
        private string login = "";
        private string psw = "";
        private string message = "";
        private string estimate = "";

        private async void WorkRefreshThumbtack()
        {
            await Task.Run(async () =>
            {
                while(IsStart)
                {
                    try
                    {
                        Thread.Sleep(2000);
                        driver.Navigate().GoToUrl("https://www.thumbtack.com/pro-leads/opportunities");
                        Thread.Sleep(1000);
                        CheckEstimate();
                    }
                    catch(Exception e)
                    {
                        if(isOpenPage)
                        {
                            driver.Navigate().GoToUrl("https://www.thumbtack.com/pro-leads/opportunities");
                            isOpenPage = false;
                        }
                    }
                }
            });
        }

        bool isOpenPage = false;
        private void CheckEstimate()
        {
            IWebElement theHiddenFields = driver.FindElements(By.ClassName("_3nbLX8RQ6YfnF8skKyAMn6"))[0];
            IWebElement webElement = theHiddenFields.FindElement(By.ClassName("tp-body-3"));
            IWebElement webElement1 = theHiddenFields.FindElement(By.ClassName("_2CiDoK_ev_l6bQ7p3GC2fA"));
            string timeAgo = webElement.Text.Remove(webElement.Text.IndexOf(" • "));
            if (timeAgo.Contains('h') || timeAgo.Contains('s'))
            {
                theHiddenFields.FindElement(By.TagName("a")).Click();
                isOpenPage = true;
                Thread.Sleep(2000);
                IWebElement textarea = driver.FindElement(By.TagName("textarea"));
                textarea.SendKeys(message);
                IWebElement input = driver.FindElements(By.ClassName("Flex")).FirstOrDefault(b => b.Displayed).FindElement(By.TagName("input"));
                input.SendKeys(estimate);
                var btn = driver.FindElements(By.ClassName("Button")).FirstOrDefault(b => b.Displayed);
                btn.Click();
            }
            driver.Navigate().GoToUrl("https://www.thumbtack.com/pro-leads/opportunities");
        }   

        public void StartBot(string miles, string login, string psw, string message, string estimate)
        {
            this.login = login;
            this.psw = psw;
            this.message = message;
            this.estimate = estimate;
            try
            {
                if (!IsStart)
                {
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl("https://www.thumbtack.com/login");
                    IWebElement theHiddenField = driver.FindElement(By.Id("login-page-email"));

                    theHiddenField.Click();
                    theHiddenField.SendKeys(login);
                    theHiddenField.Click();

                    theHiddenField = driver.FindElement(By.Id("login-page-password"));
                    theHiddenField.Click();
                    theHiddenField.SendKeys(psw);
                    theHiddenField.Click();

                    driver.FindElements(By.TagName("button")).FirstOrDefault(b => b.Text == "Log In").Click();
                    driver.Navigate().GoToUrl("https://www.thumbtack.com/pro-leads/opportunities");

                    Thread.Sleep(2000);

                    SelectMiles(miles);

                    IsStart = true;
                    WorkRefreshThumbtack();
                }
            }
            catch(Exception e) 
            {

            }
        }

        private void SelectMiles(string miles)
        {
            IWebElement select = driver.FindElements(By.TagName("select"))[0];
            select.Click();
            List<IWebElement> opt = select.FindElements(By.TagName("option")).ToList();
            switch (miles)
            {
                case "5 Miles": opt[0].Click(); break;
                case "25 Miles": opt[1].Click(); break;
                case "50 Miles": opt[2].Click(); break;
                case "100 Miles": opt[3].Click(); break;
                case "150 Miles": opt[4].Click(); break;
            }
        }

        public void StopBot()
        {
            try
            {
                if (IsStart)
                {
                    IsStart = false;
                    driver.Close();
                    driver = null;
                }
            }
            catch { }
        }
    }
}