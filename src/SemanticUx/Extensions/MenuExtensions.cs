using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    public static class MenuExtensions
    {
        public static IMenuItem Add(this Menu self, string symbol, string href)
        {
            return self.Add(symbol, null, href);
        }
    }
}
