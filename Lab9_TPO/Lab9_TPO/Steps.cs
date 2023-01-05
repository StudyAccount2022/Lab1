using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab9_TPO;

public class TestReebokPages
{
    private const string AppUrl = "https://www.reebok.pl/";

    private const string RootElementId = "app";
    
    private const string ProductCardPath = "//div[contains(@class, 'glass-product-card__wishlist')][1]";

    private readonly HomePage _homePage;
    private WishListPage _wishPage;
    private readonly MenCategoryPage _manPage;
    private readonly ProductPage _productPage;
    private readonly HelpPage _helpPage;
    private readonly WomanCategoryPage _womanPage;
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public TestReebokPages()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(200));
        _homePage = new HomePage(_driver, _wait);
        _wishPage = new WishListPage(_driver, _wait);
        _manPage = new MenCategoryPage(_driver, _wait);
        _womanPage = new WomanCategoryPage(_driver, _wait);
        _productPage = new ProductPage(_driver, _wait);
        _helpPage = new HelpPage(_driver, _wait);
    }
    

    [Test]
    public void AddToWishList()
    {
        
        _homePage.OpenHomePage();
        _homePage.CloseCookiePopUp();
        Thread.Sleep(1000);
        _homePage.AddToFavorite();
        Thread.Sleep(1000);
        _homePage.GoToTopOfSite();
        Thread.Sleep(1000);
        _homePage.OpenWishList();
        Thread.Sleep(1000);
        _wishPage.ClosePopup();
        Thread.Sleep(1000);
        _homePage.CloseWindow();
    }

    public void NotifyWhenSizeAppear()
    {
        _homePage.OpenHomePage();
        _homePage.CloseCookiePopUp();
        _homePage.GoToMenCategory();
        _manPage.ClosePopup();
        _manPage.OpenProductCard();
        _manPage.SelectUnavailableSize();
        _manPage.SelectUnavailableSizeInPopUp();
        _manPage.InputEmail();
        _manPage.ProveAges();
        _manPage.SubmitNotify();
        _homePage.CloseWindow();
    }

    public void AddToCart()
    {
        _homePage.OpenHomePage();
        _homePage.CloseCookiePopUp();
        _homePage.GoToMenCategory();
        _manPage.ClosePopup();
        _manPage.OpenProductCard();
        _manPage.SelectAvailableSize();
        _manPage.AddToCart();
        _manPage.OpenCart();
        _homePage.CloseWindow();
    }

    public void FilterCost()
    {
        _homePage.OpenHomePage();
        _homePage.CloseCookiePopUp();
        _homePage.GoToWomenCategory();
        _womanPage.ClosePopup();
        _womanPage.OpenFilters();
        _womanPage.EnableCostFilter();
        _womanPage.CloseFilters();
        _womanPage.OpenProductCard();
        _womanPage.SelectUnavailableSize();
        _homePage.CloseWindow();
    }

    public void SearchProduct()
    {
        _homePage.OpenHomePage();
        _homePage.CloseCookiePopUp();
        _homePage.Search();
        _homePage.OpenSearchedProduct();
        _womanPage.ClosePopup();
        _productPage.OpenComments();
        _productPage.FilterStars();
        _homePage.CloseWindow();
    }
    
    public void OpenBlog()
    {
        _homePage.OpenHomePage();
        _homePage.CloseCookiePopUp();
        Thread.Sleep(1000);
        _homePage.OpenBlogPage();
        _homePage.CloseWindow();
    }

    public void OpenRecommendations()
    {
        _homePage.OpenHomePage();
        _homePage.CloseCookiePopUp();
        _homePage.GoToMenCategory();
        _manPage.ClosePopup();
        _manPage.OpenProductCard();
        _manPage.SelectAvailableSize();
        _productPage.OpenRecommendationsAboutSize();
        _homePage.CloseWindow();
    }

    public void AddFeedBack()
    {
        _homePage.OpenHomePage();
        _homePage.CloseCookiePopUp();
        _homePage.OpenHelpPage();
        _helpPage.OpenDeliveryInfo();
        _helpPage.OpenHelpArticle();
        _helpPage.AddFeedback();
        _homePage.CloseWindow();
    }
}