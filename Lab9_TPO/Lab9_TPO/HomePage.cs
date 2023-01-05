using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab9_TPO;

public class HomePage
{
    private readonly WebDriverWait _driverWait;

    private readonly IWebDriver _webDriver;

    private readonly Actions _actions;
    
    private const string AppUrl = "https://www.reebok.pl/";

    private const string RootElementId = "app";
    
    private const string ProductCardPath = "//div[contains(@class, 'glass-product-card__wishlist')][1]";
    
    
    public HomePage(IWebDriver webDriver, WebDriverWait driverWait)
    {
        _webDriver = webDriver;
        _driverWait = driverWait;
        _actions = new Actions(_webDriver);
    }


    [Test]
    public void OpenHomePage()
    {
        _webDriver.Manage().Window.Maximize();
        _webDriver.Navigate().GoToUrl(AppUrl);
    }

    [Test]
    public void AddToFavorite()
    {
        var boots = _driverWait.Until(webDriver => webDriver.FindElement(By.XPath(ProductCardPath)));
        
        _actions.Click(boots);
        _actions.Perform();
    }

    [Test]
    public void GoToTopOfSite()
    {
        var body = _driverWait.Until(webDriver => webDriver.FindElement(By.Id(RootElementId)));
        
        var jsExecute = (IJavaScriptExecutor)_webDriver;
        
        const string jsScrollScript = "arguments[0].scrollIntoView();";
        
        jsExecute.ExecuteScript(jsScrollScript, body);
    }

    [Test]
    public void OpenWishList()
    {
        var wishList =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//div[contains(@class, 'wishlist_button___3YwBh')]")));

        _actions.Click(wishList);
        _actions.Perform();
    }

    [Test]
    public void CloseCookiePopUp()
    {
        var popUp =_driverWait.Until(webDriver => webDriver
            .FindElement(By.Id("glass-gdpr-default-consent-accept-button")));
        
        _actions.Click(popUp);
        _actions.Perform();
    }

    [Test]
    public void CloseWindow()
    {
        _webDriver.Close();
    }

    [Test]
    public void GoToMenCategory()
    {
        var manCategory =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//a[contains(@href, '/mezczyzni-outlet')]")));

        _actions.ScrollToElement(manCategory);
        _actions.Perform();
        _actions.Click(manCategory);
        _actions.Perform();
    }
    
    [Test]
    public void GoToWomenCategory()
    {
        var womanCategory =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//a[contains(@href, '/kobiety-outlet')]")));

        _actions.ScrollToElement(womanCategory);
        _actions.Perform();
        _actions.Click(womanCategory);
        _actions.Perform();
    }
    
    [Test]
    public void Search()
    {
        var searchInput =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//input[contains(@class, 'searchinput___19uW0')]")));
        searchInput.SendKeys("Reebok Royal Glide Ripple Clip");
        _actions.Click(searchInput);
        _actions.Perform();
    }
    
    [Test]
    public void OpenSearchedProduct()
    {
        var product =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//a[contains(@href, '/buty-reebok-royal-glide-ripple-clip/FY4639.html')]")));
        _actions.Click(product);
        _actions.Perform();
    }

    [Test]
    public void OpenBlogPage()
    {
        var blog =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//a[contains(@href, '/blog')]")));
        
        _actions.Click(blog);
        _actions.Perform();
        
        var article =_driverWait.Until(webDriver => webDriver
            .FindElement(By.XPath("//a[contains(@href, '/blog/735996-kolekcja-ktora-porwie-cie-do-dzialania')]")));
        
        _actions.Click(article);
        _actions.Perform();
    }

    [Test]
    public void OpenHelpPage()
    {
        try
        {
            var help =_driverWait.Until(webDriver => webDriver
                .FindElement(By.XPath("//a[contains(@href, '/pomoc')]")));
        
            _actions.Click(help);
            _actions.Perform();
        }
        catch (Exception e)
        {
            _webDriver.Navigate().GoToUrl("https://www.reebok.pl/pomoc");
        }
    }
}