using EaFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaFramework.Driver
{
    //this is for hold the driver thath you need
    //factory pattern
    public class DriverFixture : IDriverFixture, IDisposable
    {
        private readonly TestSettings _testSettings;

        //driver varible 
        public IWebDriver Driver { get; }

        //Construcotr
        public DriverFixture(TestSettings testSettings)
        {
            _testSettings = testSettings;
            Driver = GetWebDriver();
            Driver.Navigate().GoToUrl(_testSettings.ApplicationUrl);
        }


        public IWebDriver GetWebDriver()
        {
            return _testSettings.BrowserType switch
            {
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Safari => new SafariDriver(),
                _ => new ChromeDriver()
            };
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }

    public enum BrowserType
    {
        Firefox,
        Safari,
        Chrome,
        EdgeChromium
    }
        
}
