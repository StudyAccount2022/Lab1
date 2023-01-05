using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab9_TPO;

public class WomanCategoryPage
{
    private readonly WebDriverWait _driverWait;

    private readonly IWebDriver _webDriver;

    private readonly Actions _actions;
    
    
    public WomanCategoryPage(IWebDriver webDriver, WebDriverWait driverWait)
    {
        _webDriver = webDriver;
        _driverWait = driverWait;
        _actions = new Actions(_webDriver);
    }
    
    
    [Test]
    public void OpenFilters()
    {
        var filter =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//*[@id='main-content']/div/div[2]/div/div/div[1]/div/div[2]/div/button")));

        _actions.Click(filter);
        _actions.Perform();
    }
    
    [Test]
    public void EnableCostFilter()
    {
        var filter =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//li[contains(text(), 'Cena (od najwyższej)')]")));

        _actions.Click(filter);
        _actions.Perform();
    }
    
    [Test]
    public void CloseFilters()
    {
        var filter =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//button[contains(@aria-label, 'Zastosuj')]")));

        _actions.Click(filter);
        _actions.Perform();
    }
    
    [Test]
    public void OpenProductCard()
    {
        var productCard = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//div[contains(@class, 'glass-product-card')][1]")));
        
        _actions.Click(productCard);
        _actions.Perform();
    }
    
    [Test]
    public void SelectUnavailableSize()
    {
        var size = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//button[contains(@class, 'size-selector__size--unavailable___1EibR')][1]")));
        
        _actions.Click(size);
        _actions.Perform();
    }
    
    [Test]
    public void ClosePopup()
    {
        var closePopup = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//button[contains(@class, 'gl-modal__close')]")));

        _actions.Click(closePopup);
        _actions.Perform();
    }
}