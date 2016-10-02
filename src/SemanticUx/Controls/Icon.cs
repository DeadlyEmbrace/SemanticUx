using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("i")]
    [HtmlClass("icon")]
    public class Icon : ControlBase
    {
        public Icon(IComponent parent)
            : base(parent)
        {
        }

        public Icon(IComponent parent, string prefix)
            : this(parent, 0, prefix)
        {
        }

        public Icon(IComponent parent, int zorder)
            : this(parent, zorder, defaultPrefix)
        {
            ZOrder = zorder;
            Prefix = null;
        }

        public Icon(IComponent parent, int zorder, string prefix)
            : base(parent)
        {
            ZOrder = zorder;
            Prefix = prefix;
        }

        [HtmlClass]
        public string Symbol { get; set; }

        [HtmlClass]
        public Align Align { get; set; }

    }
}