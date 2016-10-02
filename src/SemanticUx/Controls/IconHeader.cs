using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("icon header")]
    public class IconHeader : ControlBase
    {
        public IconHeader()
            : this(null)
        {
        }

        public IconHeader(IComponent parent)
            : base(parent)
        {
            Icon = new Icon(this);
            Content = new IconHeaderContent(this);
        }

        [HtmlClass]
        public Color Color { get; set; }

        public Icon Icon { get; }

        [HtmlClass]
        public Size Size { get; set; }

        [HtmlContent]
        public string Title { get; set; }

        public IconHeaderContent Content { get; }
    }

    [HtmlTag("div")]
    [HtmlClass("content")]
    public class IconHeaderContent : ControlBase
    {
        public IconHeaderContent(IComponent parent)
            : base(parent)
        {
            Prefix = null;
        }
    }
}
