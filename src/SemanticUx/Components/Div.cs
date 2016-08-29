using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("div")]
    public class Div : ComponentBase
    {
        public Div(IComponent parent)
            : base(parent)
        {
        }
    }
}
