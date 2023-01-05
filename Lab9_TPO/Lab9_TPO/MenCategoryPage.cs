using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab9_TPO;

public class MenCategoryPage
{
    private readonly WebDriverWait _driverWait;

    private readonly IWebDriver _webDriver;

    private readonly Actions _actions;
    
    
    public MenCategoryPage(IWebDriver webDriver, WebDriverWait driverWait)
    {
        _webDriver = webDriver;
        _driverWait = driverWait;
        _actions = new Actions(_webDriver);
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
    public void SelectUnavailableSizeInPopUp()
    {
        var size = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//button[contains(@class, 'gl-square-list__element')][1]")));
        
        _actions.Click(size);
        _actions.Perform();
    }
    
    [Test]
    public void InputEmail()
    {
        var emailInput = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//input[contains(@id, 'cs-input-email')]")));
        
        emailInput.SendKeys("test@gmail.com");
    }
    
    [Test]
    public void ProveAges()
    {
        var agesCheckbox = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//input[contains(@name, 'minimumAge')]")));
        
        _actions.Click(agesCheckbox);
        _actions.Perform();
    }
    
    [Test]
    public void SubmitNotify()
    {
        var button = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//*[@id='modal-root']/div/div/div/div[2]/div/div/form/ol/li[4]/button")));
        
        _actions.Click(button);
        _actions.Perform();
    }
    
    [Test]
    public void SelectAvailableSize()
    {
        var size = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//button[contains(@class, 'gl-label size___2lbev')][5]")));
        
        _actions.Click(size);
        _actions.Perform();
    }
    
    [Test]
    public void AddToCart()
    {
        var button = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//*[@id='add-to-bag']/button")));
        
        _actions.Click(button);
        _actions.Perform();
    }

    [Test]
    public void OpenCart()
    {
        var button = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//a[contains(@href, '/cart')]")));
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