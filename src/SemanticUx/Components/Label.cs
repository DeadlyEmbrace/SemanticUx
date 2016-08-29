using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("label")]
    public class Label : ComponentBase
    {
        public Label(IComponent parent)
            : base(parent)
        {
        }
    }
}
