using SemanticUx.Components;

namespace SemanticUx.Extensions
{
    public static class Html5DocumentExtensions
    {
        public static string Render(this Html5Document self)
        {
            var htmlComposer = new DefaultHtmlBuilder();
            htmlComposer.Compose(self);
            return htmlComposer.ToString();
        }
    }
}