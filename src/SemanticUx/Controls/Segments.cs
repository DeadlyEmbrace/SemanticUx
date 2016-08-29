using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("segments")]
    public class Segments : ComponentBase
    {
        [HtmlClass("horizontal")]
        public bool Horizontal { get; set; }

        [HtmlClass("piled")]
        public bool Piled { get; set; }

        [HtmlClass("raised")]
        public bool Raised { get; set; }

        [HtmlClass("secondary")]
        public bool Secondary { get; set; }

        [HtmlClass("stacked")]
        public bool Stacked { get; set; }
    }
}
