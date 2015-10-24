using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpersAndViewComponents.ViewComponents
{
    public class CustomersViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int max)
        {
            var items = new List<string>();
            for (int i = 0; i < max; i++)
            {
                items.Add("Customer " + i.ToString());
            }        
            return View(items);
        }
    }
}
