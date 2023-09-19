using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Utility
{
    public class Utilities
    {
        public static async Task enterText(ILocator locator, string inputText)
        {
            await locator.FillAsync(inputText);
        }


    }
}
