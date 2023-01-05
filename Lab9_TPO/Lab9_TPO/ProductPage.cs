using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab9_TPO;

public class ProductPage
{
    private readonly WebDriverWait _driverWait;

    private readonly IWebDriver _webDriver;

    private readonly Actions _actions;
    
    
    public ProductPage(IWebDriver webDriver, WebDriverWait driverWait)
    {
        _webDriver = webDriver;
        _driverWait = driverWait;
        _actions = new Actions(_webDriver);
    }

    [Test]
    public void OpenComments()
    {
        var comments = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//*[@id='navigation-target-reviews']/div/button")));

        _actions.ScrollToElement(comments);
        _actions.Perform();
        
        _actions.Click(comments);
        _actions.Perform();
    }

    [Test]
    public void FilterStars()
    {
        var comments = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//*[@id='navigation-target-reviews']/div/div/div/div/div[1]/div[5]/div[2]/button[1]")));

        _actions.ScrollToElement(comments);
        _actions.Perform();
        
        _actions.Click(comments);
        _actions.Perform();
    }

    [Test]
    public void OpenRecommendationsAboutSize()
    {
        var recommendations =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//span[contains(text(), 'Wskazówki dotyczące rozmiarów')]")));

        _actions.Click(recommendations);
        _actions.Perform();
    }
}