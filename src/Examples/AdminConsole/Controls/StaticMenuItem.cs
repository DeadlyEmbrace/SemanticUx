using SemanticUx.Attributes;
using SemanticUx.Components;
using SemanticUx.Controls;

namespace AdminConsole.Controls
{
    [HtmlTag("div")]
    [HtmlClass("item")]
    public class StaticMenuItem : ControlBase
    {
        public StaticMenuItem()
            : this(null)
        {
        }

        public StaticMenuItem(IComponent parent)
            : base(parent)
        {
            Prefix = null;
        }

        [HtmlContent]
        public string Title { get; set; }
    }
}
