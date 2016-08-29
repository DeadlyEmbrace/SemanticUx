using SemanticUx.Attributes;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("menu")]
    public class Menu : ControlBase
    {
        [HtmlClass("attached")]
        public bool Attached { get; set; }

        [HtmlClass("fixed")]
        public bool Fixed { get; set; }

        [HtmlClass("pointing")]
        public bool Pointing { get; set; }

        [HtmlClass]
        public MenuPosition Position { get; set; }

        [HtmlClass("secondary")]
        public bool Seconday { get; set; }

        [HtmlClass("tabular")]
        public bool Tabular { get; set; }

        [HtmlClass("text")]
        public bool TextOnly { get; set; }

        [HtmlClass("fluid")]
        public bool Fluid { get; set; }

        [HtmlClass("vertical")]
        public bool Vertical { get; set; }

        [HtmlClass("pagination")]
        public bool Pagination { get; set; }
    }

    [HtmlTag("a")]
    [HtmlClass("item", Prefix = null)]
    public class MenuItem : ControlBase
    {
        [HtmlAttribute("href")]
        public string Href { get; set; }

        [HtmlClass("active")]
        public bool Active { get; set; }

        [HtmlClass]
        public Color Color { get; set; }

        public string Title
        {
            get
            {
                return Content;
            }
            set
            {
                Content = value;
            }
        }
    }

    [HtmlTag("div")]
    [HtmlClass("header item")]
    public class MenuHeader : ControlBase
    {
        public string Title
        {
            get
            {
                return Content;
            }
            set
            {
                Content = value;
            }
        }
    }

    [HtmlTag("div")]
    [HtmlClass("item")]
    public class MenuGroup
    {
        //...
    }

    public enum MenuPosition
    {
        _,
        Left,
        Top,
        Right,
        Bottom
    }
}