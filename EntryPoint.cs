
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class EntryPoint
    {
        static IWebDriver driver = new ChromeDriver(@"C:\Users\sandeep\.nuget\packages\selenium.chrome.webdriver\2.45.0\driver");
        static IWebElement textBoxUsername;
        static IWebElement textBoxPassword;
        static void Main()
        {
            string url = "https://app.perkpayroll.com/Login.aspx?ReturnUrl=%2fEmployeeTimeEntries.aspx";
        
            driver.Navigate().GoToUrl(url);

            textBoxUsername = driver.FindElement(By.Name("Login1$UserName"));
            textBoxPassword = driver.FindElement(By.Name("Login1$Password"));

            textBoxUsername.SendKeys("sandeep.r@madoxservices.in");
            textBoxPassword.SendKeys("1234");

            IWebElement element = driver.FindElement(By.Id("Login1_LoginButton"));
            Thread.Sleep(5000);
            element.Click();
            
            //string csspathMyInfo = "#ctl00_Menu_menuContainer > li.sprite-shortcuts > a > span";
            //IWebElement csspathMyInfoElement = driver.FindElement(By.CssSelector(csspathMyInfo));
            //Thread.Sleep(3000);
            //csspathMyInfoElement.Click();

            

            //string csspathTimeEntry = "#ctl00_Menu_menuContainer > li.sprite-shortcuts > ul > ul > li.active > a";
            //IWebElement csspathTimeEntryElement = driver.FindElement(By.CssSelector(csspathTimeEntry));
            //Thread.Sleep(3000);
            //csspathTimeEntryElement.Click();

            IWebElement Detailelement = driver.FindElement(By.Id("ctl00_cplMain_grvEmpTimeEntries_ctl02_imgbtnDetails"));
            Thread.Sleep(5000);
            Detailelement.Click();
            Thread.Sleep(3000);


            IWebElement Editelement = driver.FindElement(By.Id("ctl00_cplMain_btnUpdate"));
            Thread.Sleep(5000);
            Editelement.Click();
            Thread.Sleep(7000);

            IWebElement FromCalElement = driver.FindElement(By.CssSelector("#dvTimeEntries > div:nth-child(2) > div:nth-child(1) > div.input-field.col.m2.s2.l1 > span"));
            Thread.Sleep(5000);
            FromCalElement.Click();

            Thread.Sleep(3000);

            driver.Quit();
        }

}

