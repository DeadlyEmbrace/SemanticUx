using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("button")]
    [HtmlClass("button")]
    public class Button : ControlBase
    {
        public Button()
        {
        }

        public Button(IComponent parent)
            : base(parent)
        {
        }

        public Icon Icon => _icon ?? (_icon ?? new Icon(this));

        [HtmlAttribute("tabindex", "0")]
        public bool Focusable { get; set; }

        [HtmlClass("primary")]
        public bool Primary { get; set; }

        [HtmlClass("secondary")]
        public bool Secondary { get; set; }

        [HtmlClass("basic")]
        public bool Basic { get; set; }

        [HtmlClass("inverted")]
        public bool Inverted { get; set; }

        [HtmlClass("positive")]
        public bool Positive { get; set; }

        [HtmlClass("negative")]
        public bool Negative { get; set; }

        [HtmlClass("compact")]
        public bool Compact { get; set; }

        [HtmlClass("circular")]
        public bool Circular { get; set; }

        [HtmlClass("fluid")]
        public bool Fluid { get; set; }

        [HtmlClass("toggle")]
        public bool Toggle { get; set; }

        [HtmlClass]
        public ButtonState State { get; set; }
        
        // attach using value_value and replace _ so you get `value value`

        [HtmlAttribute("type")]
        public ButtonType Type { get; set; }

        [HtmlAttribute("name")]
        public string Name { get; set; }

        [HtmlAttribute("value")]
        public string Value { get; set; }

        [HtmlClass]
        public Color Color { get; set; }

        [HtmlClass]
        public Size Size { get; set; }

        [HtmlContent]
        public string Title { get; set; }

        protected Icon _icon;
    }

    public enum ButtonType
    {
        _,
        Button,
        Reset,
        Submit
    }

    public enum ButtonState
    {
        _,
        Active,
        Disabled,
        Loading
    }
}
