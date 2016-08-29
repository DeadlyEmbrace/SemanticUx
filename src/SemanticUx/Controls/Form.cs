using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("form")]
    [HtmlClass("form")]
    public class Form : ControlBase
    {
        public Form()
            : this(null)
        {
        }

        public Form(IComponent parent)
            : base(parent)
        {
        }

        [HtmlAttribute("name")]
        public string Name { get; set; }

        [HtmlAttribute("enctype")]
        public string Encoding { get; set;}

        [HtmlAttribute("autocomplete")]
        public AutoComplete AutoComplete { get; set; }

        [HtmlAttribute("method")]
        public FormMethod Method { get; set; }

        [HtmlAttribute("action")]
        public string Action { get; set; }

        [HtmlClass]
        public Size Size { get; set; }

    }

    public enum FormMethod
    {
        Get,
        Post
    }

    public enum AutoComplete
    {
        On,
        Off
    }

    public static class Encoding
    {
        public const string Application = "application/x-www-form-urlencoded";
        public const string MultiPart = "multipart/form-data";
        public const string Text = "text/plain";
    }
}
