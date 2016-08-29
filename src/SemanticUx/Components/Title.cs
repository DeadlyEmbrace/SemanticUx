using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("title")]
    public class Title : ComponentBase
    {
        public Title()
            : base(null)
        {
        }

        public Title(IComponent parent)
            : base(parent)
        {
        }
    }
}
