using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingDependencyInjection.ViewModels
{
    public class DIViewModel
    {
        public int CalculatorResult { get; set; }
        public bool TransientsEqual { get; set; }
        public bool ScopedEqual { get; set; }
    }
}
