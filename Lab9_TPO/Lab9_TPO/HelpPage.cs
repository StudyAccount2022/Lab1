using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab9_TPO;

public class HelpPage
{
    private readonly WebDriverWait _driverWait;

    private readonly IWebDriver _webDriver;

    private readonly Actions _actions;
    
    
    public HelpPage(IWebDriver webDriver, WebDriverWait driverWait)
    {
        _webDriver = webDriver;
        _driverWait = driverWait;
        _actions = new Actions(_webDriver);
    }

    [Test]
    public void OpenDeliveryInfo()
    {
        var delivery =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//a[contains(@href, 'https://www.reebok.pl/pomoc?hcid=HCID_DELIVERY')]")));

        _actions.ScrollToElement(delivery);
        
        _actions.Click(delivery);
        _actions.Perform();
    }
    
    [Test]
    public void OpenHelpArticle()
    {
        _webDriver.Navigate().GoToUrl("https://www.reebok.pl/pomoc/dlaczego-moje-zam%C3%B3wienie-nie-mo%C5%BCe-zosta%C4%87-nadane.html");
    }
    
    [Test]
    public void AddFeedback()
    {
        var feedback =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//*[@id='content']/div/div/div[2]/div[2]/div[2]/div/div/div[1]/a[1]")));
        
        _actions.Click(feedback);
        _actions.Perform();
    }
}