﻿
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

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
            Thread.Sleep(3000);
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

            int i, j=1, w=0;

            
            for(i=1; i<=Thisday.Day; i++) //THE MAIN LOOP
            {
                j=i;
                switch(i)
                {
                    case 13:
                            j = 1;
                            break;
                    case 14:
                            j = 2;
                            break;
                    case 15:
                            j = 3;
                            break;
                    case 16:
                            j = 4;
                            break;
                    case 17:
                            j = 5;
                            break;
                    case 18:
                            j = 6;
                            break;
                    case 19:
                            j = 7;
                            break;
                    case 20:
                            j = 8;
                            break;
                    case 21:
                            j = 9;
                            break;
                    case 22:
                            j = 10;
                            break;
                    case 23:
                            j = 11;
                            break;
                    case 24:
                            j = 12;
                            break;
                    case 25:
                            j = 1;
                            break;
                    case 26:
                            j = 2;
                            break;
                    case 27:
                            j = 3;
                            break;
                    case 28:
                            j = 4;
                            break;
                    case 29:
                            j = 5;
                            break;
                    case 30:
                            j = 6;
                            break;
                    case 31:
                            j = 7;
                            break;
                }

                if((i==13)||(i==25))
                {
                
                    IWebElement SecondPageElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_divPayRollGrid > div.row.zero-margin-bottom.margin-left-30 > div > div > ul > li:nth-child(3) > a > i"));
                    Thread.Sleep(5000);
                    IWebElement PageElement = driver.FindElement(By.CssSelector("body"));
                    PageElement.SendKeys(Keys.PageUp);
                    Thread.Sleep(5000);
                    
                    Actions actions = new Actions(driver);
                    actions.Click(SecondPageElement);
                    actions.Perform();
                    Thread.Sleep(5000);
                    /* try
                    {   
                        IWebElement SecondPageElementSub = driver.FindElement(By.CssSelector("#ctl00_cplMain_divPayRollGrid > div.row.zero-margin-bottom.margin-left-30 > div > div > ul > li:nth-child(2) > a"));
                        SecondPageElementSub.Click();
                    }
                    catch(StaleElementReferenceException)
                    {
                        IWebElement SecondPageElementSub = driver.FindElement(By.CssSelector("#ctl00_cplMain_divPayRollGrid > div.row.zero-margin-bottom.margin-left-30 > div > div > ul > li:nth-child(2) > a"));
                        SecondPageElementSub.Click();  
                    }*/
                    
                    //SecondPageElement.SendKeys(Keys.Space);
                    Console.WriteLine("SecondPage");
                    
                }
                /* if(i==25)
                {
                    IWebElement ThirdPageElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_divPayRollGrid > div.row.zero-margin-bottom.margin-left-30 > div > div > ul > li:nth-child(3) > a"));
                    Thread.Sleep(5000);
                    ThirdPageElement.Click();
                    Thread.Sleep(5000);
                    ThirdPageElement.SendKeys(Keys.Space);
                    Console.WriteLine("ThirdPage");
                }*/
    
                IWebElement DateElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_grvEmpTimeEntries > tbody > tr:nth-child("+(j)+") > td:nth-child(2)"));
                string datetext = DateElement.Text;
                DateTime dt = DateTime.ParseExact(datetext, "dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture); //convert from string to datetime format
                Console.WriteLine(dt);
                DayOfWeek dow = dt.DayOfWeek;
                Console.WriteLine(dow);
                DayOfWeek Sat = DayOfWeek.Saturday;
                DayOfWeek Sun = DayOfWeek.Sunday;       //Weekend logic

                if(dow==Sat)
                {
                        w = w+1;                        //second sat
                }

                if(((dow==Sat)&((w==2)||(w==4)))||(dow==Sun))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Not a Weekend");
                }
                
                
            
            Console.WriteLine(w);
            Thread.Sleep(5000);
            if((i<9)||(i>12))                    //used to get the two digits correctly - detail button ID
            {
                IWebElement Detailelement = driver.FindElement(By.Id("ctl00_cplMain_grvEmpTimeEntries_ctl0"+(1+j)+"_imgbtnDetails"));
                Detailelement.SendKeys(Keys.Space); //keys.space is used because when skipped and returing here, the detail element is not seen on front screen, it has to be scrolled up and so this workaround 
                Thread.Sleep(3000);
            }
            else
            {
                IWebElement Detailelement = driver.FindElement(By.Id("ctl00_cplMain_grvEmpTimeEntries_ctl"+(1+j)+"_imgbtnDetails"));
                Detailelement.SendKeys(Keys.Space);  
                Thread.Sleep(3000);
            }
            
            IWebElement Editelement = driver.FindElement(By.Id("ctl00_cplMain_btnUpdate"));
            Thread.Sleep(7000);
            Editelement.Click();
            Thread.Sleep(7000);

            //FirstCalender FROM

            //IWebElement FromCalElement;
            IWebElement FromDateEnterElement;//try catch block 
            try                         
            {
            //FromCalElement = driver.FindElement(By.CssSelector("#dvTimeEntries > div:nth-child(2) > div:nth-child(1) > div.input-field.col.m2.s2.l1 > span"));
            FromDateEnterElement = driver.FindElement(By.Name("ctl00$cplMain$txtUserCheckIn")); //CalElement was removed as I will directly type the text
            if(FromDateEnterElement.Displayed)
            {
            Thread.Sleep(5000);
            FromDateEnterElement.Click();
            }
            }
            catch(NoSuchElementException)
            {
                continue;           //continue with loop iteration for next detail button
            }
            System.Threading.Thread.Sleep(5000);
            FromDateEnterElement.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            Thread.Sleep(5000);
            FromDateEnterElement.SendKeys(datetext+" 09:00:00 AM");
            Thread.Sleep(3000);

            /* IWebElement FirstDateElement = driver.FindElement(By.CssSelector("#ctl00_cplMain_txtUserCheckIn_table > tbody > tr:nth-child(1) > td:nth-child(3) > div"));
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
            FromOKElement.Click();*/

            //SECOND CALENDER TO

            /*IWebElement ToCalElement = driver.FindElement(By.CssSelector("#dvTimeEntries > div:nth-child(2) > div:nth-child(2) > div.input-field.col.m2.s2.l1 > span"));
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
            ToOKElement.Click();*/


            IWebElement ToDateEnterElement = driver.FindElement(By.Name("ctl00$cplMain$txtUserCheckOut"));
            Thread.Sleep(5000);
            ToDateEnterElement.Click();
            System.Threading.Thread.Sleep(5000);
            ToDateEnterElement.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            Thread.Sleep(5000);
            ToDateEnterElement.SendKeys(datetext+" 06:00:00 PM");
            

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
            }               //Initial for loop close brace
            
            driver.Quit();
        }

}

