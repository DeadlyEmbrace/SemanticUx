using SemanticUx.Components;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IDropdownExtensions
    {
        public static void Show(this IDropdown self)
        {
            var script = new Script
            {
                Content = $"$('#{self.Id}').dropdown();"
            };
            self.Add(script);
        }
    }
}