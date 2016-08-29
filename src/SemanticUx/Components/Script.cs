using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("script")]
    public class Script : ComponentBase
    {
        [HtmlAttribute("src")]
        public string Src { get; set; }

        [HtmlAttribute("type")]
        public string Type { get; set; }

    }
}
