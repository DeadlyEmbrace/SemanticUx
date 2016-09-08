using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("input")]
    public class Input : ComponentBase
    {
        public Input()
            : base(null)
        {
        }

        public Input(IComponent parent)
            : base(parent)
        {
        }

        [HtmlAttribute("type")]
        public InputType Type { get; set; }

        [HtmlAttribute("placeholder")]
        public string PlaceHolder { get; set; }

        [HtmlContent]
        public string Value { get; set; }
    }

    public enum InputType
    {
        Text,
        Email,
        Password
    }
}
