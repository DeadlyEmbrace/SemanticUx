using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("segment")]
    public class Segment : ComponentBase
    {
        public Segment(IComponent parent)
            : base(parent)
        {
        }

        [HtmlClass("disabled")]
        public bool Disabled { get; set; }

        [HtmlClass("inverted")]
        public bool Inverted { get; set; }

        [HtmlClass("attached")]
        public bool Attached { get; set; }

        [HtmlClass("padded")]
        public bool Padded { get; set; }

        [HtmlClass("compact")]
        public bool Compact { get; set; }

        [HtmlClass("loading")]
        public bool Loading { get; set; }

        [HtmlClass("piled")]
        public bool Piled { get; set; }

        [HtmlClass("raised")]
        public bool Raised { get; set; }

        [HtmlClass("stacked")]
        public bool Stacked { get; set; }

        [HtmlClass("vertical")]
        public bool Vertical { get; set; }

        [HtmlClass]
        public Color Color { get; set; }

        [HtmlClass("basic")]
        public bool Basic { get; set; }

        [HtmlClass("secondary")]
        public bool Secondary { get; set; }

        [HtmlClass("tertiary")]
        public bool Tertiary { get; set; }

        [HtmlClass("horizontal")]
        public bool Horizontal { get; set; }
    }
}
