using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("a")]
    public class A : ComponentBase
    {
        public A()
            : this(null)
        {
        }

        public A(IComponent parent)
            : base(parent)
        {
        }

        [HtmlContent]
        public string Content { get; set; }

        [HtmlAttribute("href")]
        public string Href { get; set; }

        [HtmlAttribute("target")]
        public Target Target { get; set; }
    }
}
