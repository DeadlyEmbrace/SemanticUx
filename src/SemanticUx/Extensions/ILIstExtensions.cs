using System.Collections.Generic;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class ILIstExtensions
    {
        public static void Add<T>(this IList<T> self, params T[] items)
        {
            foreach (var item in items)
            {
                self.Add(item);
            }
        }
    }
}
