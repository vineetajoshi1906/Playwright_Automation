using NUnit.Framework;
using PlaywrightAutomation.Drivers;
using PlaywrightAutomation.Pages;
using SpecflowCalculator.specs.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PlaywrightAutomation.StepDefinitions
{
    [Binding]
    public class TestingEcomApplicationStepDefinitions
    {
        public readonly Driver _driver;
        public readonly SignupPage _signupPage;
        public readonly ScenarioContext _scenarioContext;
        public TestingEcomApplicationStepDefinitions(ScenarioContext scenarioContext,Driver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _signupPage = new SignupPage(driver.Page);
        }
        [Given(@"User launch registration Url ""([^""]*)""")]
        public async Task GivenUserLaunchRegistrationUrl(string p0)
        {
            await _driver.Page.GotoAsync(p0);
            Console.WriteLine("this is first step");
            Thread.Sleep(6000);


        }

        [Given(@"I click on Register link")]
        public async Task GivenIClickOnRegisterLink()
        {
            await _signupPage.ClickRegisterLink();

        }

        [When(@"Enter required details")]
        public async Task  WhenEnterRequiredDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            //await _loginPage._txtusername.TypeAsync((String)data.User);
            await _signupPage.Fillinformation((String)data.FirstName, (String)data.LastName, (String)data.Email, (Int64)data.PhoneNumber,(String)data.Password, (String)data.Gender, (String)data.Occupation);
        }

        [When(@"I click on Register button")]
        public async Task WhenIClickOnRegisterButton()
        {
            await _signupPage.clickSubmit();
        }

        [Then(@"Verify that the new page contains text ""([^""]*)""")]
        public async Task ThenVerifyThatTheNewPageContainsText(string p0)
        {
            String Sucess=await _signupPage._success.TextContentAsync();
            Assert.IsTrue(Sucess.Equals(p0));
    
          

        }

        [Then(@"Verify the Login button displayed on the new page")]
        public async Task ThenVerifyTheLoginButtonDisplayedOnTheNewPage()
        {
            await _signupPage._login.IsVisibleAsync();
        }
        [Then(@"Verify error message displayed for all required field")]
        public async void ThenVerifyErrorMessageDisplayedForAllRequiredField()
        {
            await _signupPage._firstNameValidation.IsVisibleAsync();
            await _signupPage._PhoneValidation.IsVisibleAsync();
            await _signupPage._emailValidation.IsVisibleAsync();
            await _signupPage._ageValidation.IsVisibleAsync();
            await _signupPage._passwordValidation.IsVisibleAsync();
            await _signupPage._ConfirmPasswordValidation.IsVisibleAsync();
        }

    }
}
