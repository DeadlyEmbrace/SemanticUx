using SemanticUx.Components;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IDropdownExtensions
    {
        public static T ShowDropdown<T>(this T self)
            where T : IDropdown
        {
            var script = new Script
            {
                Content = $"$('#{self.Id}').dropdown();"
            };
            self.Add(script);
            return self;
        }
    }
}