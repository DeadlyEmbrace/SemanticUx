using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("sidebar menu")]
    public class Sidebar : ControlBase
    {
        public Sidebar()
            : this(null)
        {
        }

        public Sidebar(IComponent parent)
            : base(parent)
        {
            Id = GetHashCode()
                .ToString();
        }

        public ISidebarItem Add(ISidebarItem sidebarItem)
        {
            Components.Add(sidebarItem);

            return sidebarItem;
        }

        public ISidebarItem Add(string title, string href)
        {
            var result = new SidebarItem
            {
                Title = title,
                Href = href
            };
            Components.Add(result);

            return result;
        }

        public ISidebarItem Add(string symbol, string title, string href)
        {
            var sidebarItem = new SidebarItem
            {
                Title = title,
                Href = href
            };
            sidebarItem.Icon.Symbol = symbol;
            Components.Add(sidebarItem);

            return sidebarItem;
        }

        [HtmlClass]
        public Align Align { get; set; }

        [HtmlClass("icon")]
        public bool Icons { get; set; }

        [HtmlClass("inverted")]
        public bool Inverted { get; set; } = true;

        [HtmlClass("labeled")]
        public bool Labeled { get; set; } = true;

        [HtmlClass]
        public SidebarPosition Position { get; set; }

        [HtmlClass("vertical")]
        public bool Vertical { get; set; } = true;

        [HtmlClass("visible")]
        public bool Visible { get; set; }

        [HtmlClass]
        public SidebarWidth Width { get; set; }
    }

    public interface ISidebarItem : IComponent
    {
        string Href { get; }
        Icon Icon { get; }
        string Title { get; }
    }

    [HtmlTag("a")]
    [HtmlClass("item")]
    public class SidebarItem : ControlBase,
        ISidebarItem
    {
        public SidebarItem()
            : this(null)
        {
        }

        public SidebarItem(IComponent parent)
            : base(parent)
        {
            Prefix = null;
        }

        public Icon Icon => icon ?? (icon = new Icon(this));

        [HtmlContent]
        public string Title { get; set; }

        [HtmlAttribute("href")]
        public string Href { get; set; }

        protected Icon icon;
    }

    public enum SidebarWidth
    {
        _,
        Very_Thin,
        Thin,
        Wide,
        Very_Wide
    }

    public enum SidebarPosition
    {
        _,
        Left,
        Top,
        Right,
        Bottom
    }

    public enum SidebarTransition
    {
        Overlay,
        Push,
        Scale_Down,
        Uncover,
        Slide_Along,
        Slide_Out
    }
}
