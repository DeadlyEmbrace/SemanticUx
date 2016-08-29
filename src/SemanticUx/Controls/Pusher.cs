using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("pusher")]
    public class Pusher : ControlBase
    {
        public Pusher()
            : base(null)
        {
        }

        public Pusher(IComponent parent)
            : base(parent)
        {
        }
    }
}
