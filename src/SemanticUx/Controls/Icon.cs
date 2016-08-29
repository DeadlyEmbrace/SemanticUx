using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("i")]
    [HtmlClass("icon", Prefix = null)]
    public class Icon : ControlBase
    {
        public Icon(IComponent parent)
            : base(parent)
        {
        }

        [HtmlClass]
        public string Symbol { get; set; }

        [HtmlClass]
        public Align Align { get; set; }

    }
}