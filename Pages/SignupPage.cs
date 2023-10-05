using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightAutomation.Drivers;
using PlaywrightAutomation.Utility;

namespace PlaywrightAutomation.Pages
{
    public class SignupPage
    {
        IPage _page;
        public readonly ILocator _register;
        public readonly ILocator _firstname;
        public readonly ILocator _lastname;
        public readonly ILocator _email;
        public readonly ILocator _phone;
        public readonly ILocator _occupation;
        public readonly ILocator _password;
        public readonly ILocator _confirmPassword;
        public readonly ILocator _gender;
        public readonly ILocator _age;
        public readonly ILocator _submit;
        public readonly Utilities _Utilities;
        public readonly ILocator _success;
        public readonly ILocator _login;
        public readonly ILocator _firstNameValidation;
        public readonly ILocator _PhoneValidation;
        public readonly ILocator _emailValidation;
        public readonly ILocator _passwordValidation;
        public readonly ILocator _ageValidation;
        public readonly ILocator _ConfirmPasswordValidation;



        public SignupPage(IPage page)
        {

            _page = page;
            _register = _page.Locator(".text-reset");
            _firstname =_page.Locator("#firstName");
            _lastname = _page.Locator("#lastName");
            _email = _page.Locator("#userEmail");
            _phone = _page.Locator("#userMobile");
            _occupation = _page.Locator("Select[formcontrolname='occupation']");
            _gender = _page.Locator("input[value='Male']");
            _password = _page.Locator("#userPassword");
            _confirmPassword = page.Locator("#confirmPassword");
            _age = _page.Locator("input[type='checkbox']");
            _submit = _page.Locator("#login");
            _success = _page.Locator("text=Account Created Successfully");
            _login = _page.Locator("text=Login");
            _firstNameValidation = page.Locator("text=*First Name is required");
            _emailValidation = page.Locator("text=*Email is required");
            _PhoneValidation = page.Locator("text=*Phone Number is required");
            _passwordValidation = page.Locator("text=*Password is required");
            _ConfirmPasswordValidation = page.Locator("text=Confirm Password is required");
            _ageValidation = page.Locator("text=*Please check above checkbox");
        }

        public async Task Fillinformation(String FirstName, String LastName, String Email, Int64 Phone, String Password, String Gender, String Occupation)
        {
            await Utilities.enterText(_firstname, FirstName);
            await Utilities.enterText(_lastname, LastName);
            await Utilities.enterText(_email, Email);
            await Utilities.enterNumber(_phone, Phone);
            await Utilities.Click(_gender);
            await Utilities.selectDropdown(_occupation, Occupation);
            await Utilities.Click(_age);
            await Utilities.enterText(_password, Password);
            await Utilities.enterText(_confirmPassword, Password);
        }

        public async Task ClickRegisterLink()
        {
            await _register.ClickAsync();
        }
        public async Task clickSubmit()
        {
            await _submit.ClickAsync();
        }
    }

}
