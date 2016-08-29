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

        public string Title
        {
            get
            {
                return Content.Content;
            }

            set
            {
                Content.Content = value;
            }
        }

        public new IconHeaderContent Content { get; }
    }

    [HtmlTag("div")]
    [HtmlClass("content", Prefix = null)]
    public class IconHeaderContent : ComponentBase
    {
        public IconHeaderContent(IComponent parent)
            : base(parent)
        {
        }
    }
}
