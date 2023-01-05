using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab9_TPO;

public class WishListPage
{
    private readonly WebDriverWait _driverWait;

    private readonly IWebDriver _webDriver;

    private readonly Actions _actions;
    
    
    public WishListPage(IWebDriver webDriver, WebDriverWait driverWait)
    {
        _webDriver = webDriver;
        _driverWait = driverWait;
        _actions = new Actions(_webDriver);
    }


    public void ClosePopup()
    {
        var closePopup = _driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//button[contains(@class, 'gl-modal__close')]")));

        _actions.Click(closePopup);
        _actions.Perform();
    }
}