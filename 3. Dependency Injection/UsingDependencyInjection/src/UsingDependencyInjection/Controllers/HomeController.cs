using System;
using Microsoft.AspNet.Mvc;
using BizRules;
using UsingDependencyInjection.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UsingMVCMiddleware.Controllers
{
    public class HomeController : Controller
    {
        readonly ICalculator _Calculator;
        readonly bool _TransientsEqual;
        readonly bool _ScopedEqual;
        public HomeController(ICalculator calc, 
            IScoped scoped1,
            IScoped scoped2,
            ITransient transient1,
            ITransient transient2)
        {
            _Calculator = calc;
            _ScopedEqual = scoped1 == scoped2;
            _TransientsEqual = transient1 == transient2;
        }

        public IActionResult Index()
        {
            var vm = new DIViewModel
            {
                CalculatorResult = _Calculator.Add(5, 5),
                TransientsEqual = _TransientsEqual,
                ScopedEqual = _ScopedEqual
            };
            return View(vm);
        }
    }
}
