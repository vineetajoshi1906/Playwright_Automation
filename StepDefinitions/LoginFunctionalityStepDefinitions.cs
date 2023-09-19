using Microsoft.Playwright;
using PlaywrightAutomation.Drivers;
using SpecflowCalculator.specs.Pages;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using PlaywrightAutomation.Utility;
using NUnit.Framework;

namespace PlaywrightAutomation.StepDefinitions
{
    [Binding]
    public class LoginFunctionalityStepDefinitions
    {
        public readonly Driver _driver;
        public readonly LoginPage _loginPage;
        public readonly ScenarioContext _context;
        public readonly String user;
        public readonly string password;

        public LoginFunctionalityStepDefinitions(Driver driver,ScenarioContext context) {
            _driver = driver;
            this._context = context;
            _loginPage = new LoginPage(_driver.Page);


        }
    
        
        [Given(@"Navigate to the application ""([^""]*)""")]
        public void GivenNavigateToTheApplication(string p0)
        {
            _driver.Page.GotoAsync(p0);

            


            
        }

        [When(@"I enter my valid creds")]
        public async Task WhenIEnterMyValidCreds(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            Console.WriteLine((string)data.User);

            Console.WriteLine((string)data.Password);
            await _loginPage._txtusername.TypeAsync((String)data.User);
           
            await _loginPage._txtpassword.TypeAsync((String)data.Password);



        }
        [When(@"I click the login button")]
        public async Task WhenIClickTheLoginButton()
        {
           await _loginPage._btnsubmit.ClickAsync();
        }
        [Then(@"Verify that the new url contains url ""([^""]*)""")]
        public void ThenVerifyThatTheNewUrlContainsUrl(string expectedUrl)
        {

            String actualUrl=_driver.Page.Url.ToString();

            Console.WriteLine("******************8"+(string)actualUrl);
            Console.WriteLine(expectedUrl);
            Assert.IsTrue(actualUrl.Contains(expectedUrl));
           
        }

        [Then(@"Verify that the new page contains text ""([^""]*)"" or ""([^""]*)""")]
        public async Task ThenVerifyThatTheNewPageContainsTextOr(string option1, string option2)
        {
            String actualTxt= await _loginPage._msgconrats.TextContentAsync();
            Console.WriteLine("hellooooooooooooooooooooooooooooooooo"+actualTxt);
            Assert.IsTrue(actualTxt.Contains(option1) || actualTxt.Contains(option2),
                "Page doesn't contains any message like '" + option1 + "' or '" + option2 + "' after login");


        }


        [Then(@"Verify the logout button displayed on the new page")]
        public async Task ThenVerifyTheLogoutButtonDisplayedOnTheNewPage()
        {
            Assert.IsTrue(await _loginPage._txtlogout.IsVisibleAsync(), "logout button is not available");
        }


        [When(@"User enter ""([^""]*)"" and ""([^""]*)""")]
        public async Task WhenUserEnterAnd(string incorrectUser, string p1)
        {
           await _loginPage._txtusername.TypeAsync(incorrectUser);
            await _loginPage._txtpassword.TypeAsync(incorrectUser);
        }

        [Then(@"Verify error message displayed")]
        public async Task ThenVerifyErrorMessageDisplayed()
        {
         
            Assert.IsTrue(await _loginPage._msginvalid.IsVisibleAsync());
        }

        [Then(@"Verify error message text is ""([^""]*)""")]
        public async Task ThenVerifyErrorMessageTextIs(string p0)
        {
            String invalidMsg = await _loginPage._msginvalid.TextContentAsync();
            Console.WriteLine(invalidMsg);
            Assert.IsTrue(invalidMsg.Equals(p0));
        }

    }
}
