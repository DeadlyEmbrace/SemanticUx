using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("link", IsEmpty = true)]
    public class StyleSheet : ComponentBase
    {
        public StyleSheet()
        {
            Rel = "stylesheet";
            Type = "text/css";
        }

        public StyleSheet(string href)
            : this()
        {
            Href = href;
        }

        [HtmlAttribute("href")]
        public string Href { get; set; }

        [HtmlAttribute("rel")]
        public string Rel { get; set; } 

        [HtmlAttribute("type")]
        public string Type { get; set; }

    }
}
