using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightAutomation.Drivers
{
    public class Driver : IDisposable
    {
        public Task<IPage> _page;
        private IBrowser? _browser;
        public IPage Page => _page.Result;

        public Driver()
        {
            _page = InitializePlaywright();
        }
        private async Task<IPage> InitializePlaywright()
        {
            //initialize Playwright    
            var playwright = await Playwright.CreateAsync();

            //Initialize Browser
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 5000
               

            }); ;

            //page
            return await _browser.NewPageAsync();

        }
        public void Dispose()
        {
            _browser?.CloseAsync();

        }
    }
}
