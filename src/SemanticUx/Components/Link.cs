using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("link", IsEmpty = true)]
    public class Link : ComponentBase
    {
        [HtmlAttribute("href")]
        public string Href { get; set; }

        [HtmlAttribute("rel")]
        public string Rel { get; set; }

        [HtmlAttribute("type")]
        public string Type { get; set; }

        [HtmlAttribute("title")]
        public string Title { get; set; }
    }
}
