using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    public static class IIconExtensions
    {
        public static T WithIcon<T>(this T self, string symbol) where T : IIcon
        {
            self.Icon.Symbol = symbol;
            return self;
        }
    }
}
