using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    public sealed class Content : ComponentBase
    {
        public Content(string text)
        {
            Text = text;
        }

        [HtmlContent]
        public string Text { get; }
    }
}
