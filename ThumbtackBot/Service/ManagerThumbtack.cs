using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        private async void WorkRefreshThumbtack()
        {
            await Task.Run(async () =>
            {
                while(IsStart)
                {
                    try
                    {
                        Thread.Sleep(500);
                        driver.Navigate().Refresh();
                        Thread.Sleep(500);
                        CheckEstimate();
                    }
                    catch(Exception e)
                    { }
                }
            });
        }

        private void CheckEstimate()
        {
            IWebElement theHiddenFields = driver.FindElements(By.ClassName("_3nbLX8RQ6YfnF8skKyAMn6"))[9];
            IWebElement webElement = theHiddenFields.FindElement(By.ClassName("tp-body-3"));
            IWebElement webElement1 = theHiddenFields.FindElement(By.ClassName("_2CiDoK_ev_l6bQ7p3GC2fA"));
            string timeAgo = webElement.Text.Remove(webElement.Text.IndexOf(" • "));
            if (timeAgo.Contains('m') || timeAgo.Contains('s'))
            {
                theHiddenFields.FindElement(By.TagName("a")).Click();
                IWebElement input = driver.FindElements(By.ClassName("Flex"))[1].FindElement(By.TagName("input"));
                input.SendKeys("1");
                IWebElement textarea = driver.FindElement(By.TagName("textarea"));
                textarea.SendKeys("We can do free estimate!");
                var btn = driver.FindElements(By.ClassName("Button")).FirstOrDefault(b => b.Displayed);
                btn.Click();
            }
            driver.Navigate().Back();
        }

        public void StartBot(string miles)
        {
            try
            {
                if (!IsStart)
                {
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl("https://www.thumbtack.com/login");
                    IWebElement theHiddenField = driver.FindElement(By.Id("login-page-email"));

                    theHiddenField.Click();
                    theHiddenField.SendKeys("sibplastik@gmail.com");
                    theHiddenField.Click();

                    theHiddenField = driver.FindElement(By.Id("login-page-password"));
                    theHiddenField.Click();
                    theHiddenField.SendKeys("Maksim1");
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