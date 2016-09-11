using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IDropdownMenuExtensions
    {
        public static T WithIndicatorIcon<T>(this T self, string symbol)
            where T : IDropdownMenu
        {
            self.Indicator.Symbol = symbol;
            self.Indicator.ZOrder = 999;
            return self;
        }

    }
}
