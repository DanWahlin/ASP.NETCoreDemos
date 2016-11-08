using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpersAndViewComponents.ViewComponents
{
    public class CustomersViewComponent : ViewComponent
    {
        private ILogger _logger;

        public CustomersViewComponent(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomLogger");
        }

        public async Task<IViewComponentResult> InvokeAsync(int max)
        {
            //Assume async operation occurs here
            var items = new List<string>();
            for (int i = 0; i < max; i++)
            {
                items.Add("Customer " + i.ToString());
            }
            _logger.LogInformation("Rendering CustomersViewComponent");
            return View(items);
        }
    }
}
