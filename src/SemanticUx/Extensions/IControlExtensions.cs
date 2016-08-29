using SemanticUx.Components;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IControlExtensions
    {
        public static void Show(this IControl self, Modal modal)
        {
            var showModal = $"$('#{modal.Id}').modal('show');";
            self.Id = self.GetHashCode()
                .ToString();
            var script = new Script
            {
                Content = $"$('#{self.Id}').on('click', function(e) {{{showModal}}});"
            };
            self.Add(script);
        }

        public static void Toggle(this IControl self, Sidebar sidebar)
        {
            var toggleSidebar = $"$('#{sidebar.Id}').sidebar('toggle');";
            self.Id = self.GetHashCode()
                .ToString();
            var script = new Script
            {
                Content = $"$('#{self.Id}').on('click', function(e) {{{toggleSidebar}}});"
            };
            self.Add(script);
        }

    }
}
