using Microsoft.Playwright;
using PlaywrightAutomation.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightAutomation.Utility;

namespace SpecflowCalculator.specs.Pages
{
    public class LoginPage
    {
        public IPage _page;
        public readonly ILocator _txtusername;
        public readonly ILocator _txtpassword;
        public readonly ILocator _btnsubmit;
        public readonly ILocator _msgconrats;
        public readonly ILocator _txtsuccess;
        public readonly ILocator _txtlogout;
        public readonly ILocator _msginvalid;
        public LoginPage(IPage page)
        {
            _page = page;
            _txtusername = _page.Locator("#username");
            _txtpassword =_page.Locator("#password");
            _btnsubmit = _page.Locator("#submit");
            _txtsuccess = _page.Locator(".post-title");
            _txtlogout = _page.Locator("a[href='https://practicetestautomation.com/practice-test-login/']");
            // _msgconrats = _page.Locator("p[class='has-text-align-center'] strong");
            _msgconrats = page.Locator("text=Congratulations");
            _msginvalid = page.Locator(".show");
        }
        public async Task Login(string userNameText, string passWordText)
        {
            await Utilities.enterText(_txtusername, userNameText);
            await Utilities.enterText(_txtpassword, passWordText);
        }



    }
}
