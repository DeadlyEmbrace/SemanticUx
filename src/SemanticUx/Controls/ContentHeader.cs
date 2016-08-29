using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("header")]
    public class ContentHeader : ControlBase
    {
        public ContentHeader()
            : this(null)
        {
        }

        public ContentHeader(IComponent parent)
            : base(parent)
        {
        }

        [HtmlClass]
        public Color Color { get; set; }

        [HtmlClass]
        public Size Size { get; set; }

        [HtmlContent]
        public string Title { get; set; }
    }
}
