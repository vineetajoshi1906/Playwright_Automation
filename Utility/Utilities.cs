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
        public static async Task enterText(ILocator locator, String inputText)
        {
            await locator.FillAsync(inputText);
        }

        public static async Task selectDropdown(ILocator locator,String option)
        {

            Console.WriteLine("dropdown option to be selected is "+option);
            await locator.SelectOptionAsync(option);
        }

        public static async Task Click(ILocator locator)
        {
            await locator.ClickAsync();
        }
        public static async Task enterNumber(ILocator locator, Int64 number)
        {
            
            
            await locator.FillAsync(number.ToString());
        }
    }
}
