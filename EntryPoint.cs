
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class EntryPoint
    {
        static IWebDriver driver = new ChromeDriver(@"C:\Users\sandeep\.nuget\packages\selenium.chrome.webdriver\2.45.0\driver");
        static IWebElement textBoxUsername;
        static IWebElement textBoxPassword;

        static IWebElement FromHrsID;
        static IWebElement FromMinID;

        static IWebElement ToHrsID;
        static IWebElement ToMinID;
        static IWebElement WTSSubmit;
        static void Main()
        {

            driver.Manage().Window.Maximize(); 

            string url = "https://app.perkpayroll.com/Login.aspx?ReturnUrl=%2fEmployeeTimeEntries.aspx";
        
            driver.Navigate().GoToUrl(url);

            textBoxUsername = driver.FindElement(By.Name("Login1$UserName"));
            textBoxPassword = driver.FindElement(By.Name("Login1$Password"));

            textBoxUsername.SendKeys("sandeep.r@madoxservices.in");
            textBoxPassword.SendKeys("1234");

            IWebElement element = driver.FindElement(By.Id("Login1_LoginButton"));
            Thread.Sleep(5000);
            element.Click();
            
            /* string csspathMyInfo = "#ctl00_Menu_menuContainer > li.sprite-shortcuts > a > span";
            IWebElement csspathMyInfoElement = driver.FindElement(By.CssSelector(csspathMyInfo));
            Thread.Sleep(3000);
            csspathMyInfoElement.Click();*/

            

            /* string csspathTimeEntry = "#ctl00_Menu_menuContainer > li.sprite-shortcuts > ul > ul > li.active > a";
            IWebElement csspathTimeEntryElement = driver.FindElement(By.CssSelector(csspathTimeEntry));
            Thread.Sleep(3000);
            csspathTimeEntryElement.Click();*/

            DateTime Thisday = DateTime.Today;
            Console.WriteLine(Thisday.Day);
            Console.WriteLine(Thisday.DayOfWeek);

            int i;
        
            for(i=1; i<=Thisday.Day; i++)
            {
            IWebElement Detailelement = driver.FindElement(By.Id("ctl00_cplMain_grvEmpTimeEntries_ctl0"+(1+i)+"_imgbtnDetails"));
            Thread.Sleep(5000);
            Detailelement.SendKeys(Keys.Space); //because when skipped and returing here, the detail element is not seen on front screen, it has to be scrolled up and so this workaround 
            Thread.Sleep(3000);


            IWebElement Editelement = driver.FindElement(By.Id("ctl00_cplMain_btnUpdate"));
            Thread.Sleep(5000);
            Editelement.Click();
            Thread.Sleep(7000);


            //FirstCalender FROM

            IWebElement FromCalElement;
            try
            {
            FromCalElement = driver.FindElement(By.CssSelector("#dvTimeEntries > div:nth-child(2) > div:nth-child(1) > div.input-field.col.m2.s2.l1 > span"));
            if(FromCalElement.Displayed)
            {
            Thread.Sleep(5000);
            FromCalElement.Click();
            }
            }
            catch(NoSuchElementException)
            {
                continue;           //continue with loop iteration for next detail button
            }

            IWebElement FirstDateElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_txtUserCheckIn_table > tbody > tr:nth-child(1) > td:nth-child(3) > div"));
            Thread.Sleep(5000);
            FirstDateElement.Click();

            FromHrsID = driver.FindElement(By.Id("hrs-box"));
            System.Threading.Thread.Sleep(5000);
            FromHrsID.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            Thread.Sleep(5000);
            FromHrsID.SendKeys("9");
            Thread.Sleep(3000);

            FromMinID = driver.FindElement(By.Id("min-box"));
            System.Threading.Thread.Sleep(5000);
            FromMinID.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            Thread.Sleep(5000);
            FromMinID.SendKeys("0");
            Thread.Sleep(3000);

            IWebElement FromAMElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_txtUserCheckIn_root > div > div > div > div > div.picker__calendar-container > div.time-wrapper > div.DT-btn-wrapper > a.waves-effect.waves-circle.waves-light.btn-flat.AM > span"));
            Thread.Sleep(5000);
            FromAMElement.Click();

            IWebElement FromOKElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_txtUserCheckIn_root > div > div > div > div > div.myPicker__footer > button"));
            Thread.Sleep(5000);
            FromOKElement.Click();

            //SECOND CALENDER TO

            IWebElement ToCalElement = driver.FindElement(By.CssSelector("#dvTimeEntries > div:nth-child(2) > div:nth-child(2) > div.input-field.col.m2.s2.l1 > span"));
            Thread.Sleep(5000);
            ToCalElement.Click();

            IWebElement FirstTODateElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_txtUserCheckOut_table > tbody > tr:nth-child(1) > td:nth-child(3) > div"));
            Thread.Sleep(5000);
            FirstTODateElement.Click();

            ToHrsID = driver.FindElement(By.Id("hrs-box"));
            System.Threading.Thread.Sleep(5000);
            ToHrsID.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            Thread.Sleep(5000);
            ToHrsID.SendKeys("6");
            Thread.Sleep(3000);

            ToMinID = driver.FindElement(By.Id("min-box"));
            System.Threading.Thread.Sleep(5000);
            ToMinID.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            Thread.Sleep(5000);
            ToMinID.SendKeys("0");
            Thread.Sleep(3000);

            IWebElement ToPMElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_txtUserCheckOut_root > div > div > div > div > div.picker__calendar-container > div.time-wrapper > div.DT-btn-wrapper > a.waves-effect.waves-circle.waves-light.btn-flat.PM.active > span"));
            Thread.Sleep(5000);
            ToPMElement.Click();

            IWebElement ToOKElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_txtUserCheckOut_root > div > div > div > div > div.myPicker__footer > button"));
            Thread.Sleep(5000);
            ToOKElement.Click();

            Thread.Sleep(5000);

            //Submit

            WTSSubmit = driver.FindElement(By.Id("ctl00_cplMain_txtRemarks"));
            System.Threading.Thread.Sleep(5000);
            WTSSubmit.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            Thread.Sleep(5000);
            WTSSubmit.SendKeys("MT-ES-1804-014 ABB GISL WTS SUBMITTED");
            Thread.Sleep(3000);

            IWebElement Submitelement = driver.FindElement(By.Id("ctl00_cplMain_Button3"));
            Thread.Sleep(5000);
            Submitelement.Click();
            Thread.Sleep(7000);
            }
                                   //Iniitial for loop close brace
            driver.Quit();
        }

}

