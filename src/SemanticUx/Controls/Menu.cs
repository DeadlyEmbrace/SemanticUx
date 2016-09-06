using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    public interface IMenu : IControl
    {
    }

    [HtmlTag("div")]
    [HtmlClass("menu")]
    public sealed class Menu : ControlBase,
        IMenu
    {
        public Menu(IComponent parent)
            : base(parent)
        {
        }

        public IMenuItem Add(string symbol, string title, string href)
        {
            var menuItem = new MenuItem
            {
                Href = href,
                Title = title,
            };
            menuItem.Icon.Symbol = symbol;
            Add(menuItem);

            return menuItem;
        }

        [HtmlClass]
        public MenuAlignment Alignment
        {
            get
            {
                return _align;
            }

            set
            {
                _align = value;
                Prefix = _align == MenuAlignment.Right
                    ? null
                    : defaultPrefix;
            }
        }

        [HtmlClass("attached")]
        public bool Attached { get; set; }

        [HtmlClass("borderless")]
        public bool Borderless { get; set; }

        [HtmlClass]
        public Color Color { get; set; }

        [HtmlClass("compact")]
        public bool Compact { get; set; }

        [HtmlClass("fixed")]
        public bool Fixed { get; set; }

        [HtmlClass("fluid")]
        public bool Fluid { get; set; }

        [HtmlClass("icon")]
        public bool Icon { get; set; }

        [HtmlClass("inverted")]
        public bool Inverted { get; set; }

        [HtmlClass]
        public bool Labeled { get; set; }

        [HtmlClass("pagination")]
        public bool Pagination { get; set; }

        [HtmlClass("pointing")]
        public bool Pointing { get; set; }

        [HtmlClass("secondary")]
        public bool Seconday { get; set; }

        [HtmlClass]
        public MenuSize Size { get; set; }

        [HtmlClass("tabular")]
        public bool Tabular { get; set; }

        [HtmlClass("text")]
        public bool TextOnly { get; set; }

        [HtmlClass("vertical")]
        public bool Vertical { get; set; }

        private MenuAlignment _align;
    }

    public interface IMenuItem : IControl
    {
        bool Active { get; set; }
        Color Color { get; set; }
        string Href { get; set; }
        Icon Icon { get; }
        string Title { get; set; }
    }

    [HtmlTag("a")]
    [HtmlClass("item")]
    public class MenuItem : ControlBase,
        IMenuItem
    {
        public MenuItem()
        {
            Prefix = null;
        }

        [HtmlAttribute("href")]
        public string Href { get; set; }

        [HtmlClass("active")]
        public bool Active { get; set; }

        public Icon Icon => icon ?? (icon = new Icon(this, null));

        [HtmlClass]
        public Color Color { get; set; }

        [HtmlContent]
        public string Title { get; set; }

        protected Icon icon;
    }

    [HtmlTag("div")]
    [HtmlClass("header item")]
    public class MenuHeader : ControlBase
    {

        [HtmlContent]
        public string Title { get; set; }
    }

    [HtmlTag("div")]
    [HtmlClass("item")]
    public class MenuGroup
    {
        //...
    }

    [HtmlTag("div")]
    [HtmlClass("dropdown item")]
    public sealed class DropdownMenu : ControlBase,
        IMenu,
        IDropdown
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public DropdownMenu(IMenu menu)
            : base(menu)
        {
            Id = GetHashCode()
                .ToString();
            _menu = new Menu(this);
            // TODO differentiate between icon and dropdown icon
            Indicator.Symbol = Symbols.Dropdown;
            Indicator.ZOrder = 999;
        }

        public IMenuItem Add(string symbol, string title, string href)
        {
            var menuItem = new MenuItem
            {
                Href = href,
                Title = title,
            };
            menuItem.Icon.Symbol = symbol;
            _menu.Add(menuItem);

            return menuItem;
        }

        public void AddDivider()
        {
            new Divider(_menu);
        }

        public Icon Indicator => _indicator ?? (_indicator = new Icon(this));

        public Icon Icon => _icon ?? (_icon = new Icon(this));

        [HtmlContent]
        public string Title { get; set; }

        private Icon _indicator;

        private Icon _icon;

        private readonly Menu _menu;
    }

    [HtmlTag("div")]
    [HtmlClass("divider")]
    public class Divider : ControlBase
    {
        public Divider(IComponent parent)
            : base(parent)
        {
            Prefix = null;
        }
    }

    public enum MenuAlignment
    {
        _,
        Left,
        Right
    }

    public enum MenuSize
    {
        _,
        Mini,
        Tiny,
        Small,
        Large,
        Huge,
        Massive
    }

}
