using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    public interface IDropdown : IControl
    {
    }

    public abstract class DropdownBase : ComponentBase
    {
        protected DropdownBase(IComponent parent)
            : base(parent)
        {
            Id = GetHashCode()
                .ToString();
            DropdownIcon = new DropdownIcon(this, 999);
        }

        [HtmlContent]
        public string Title { get; set; }

        [HtmlClass("compact")]
        public bool Compact { get; set; }

        [HtmlClass("fluid")]
        public bool Fluid { get; set; }

        [HtmlClass("scrolling")]
        public bool Scrolling { get; set; }

        [HtmlClass("inverted")]
        public bool Inverted { get; set; }

        [HtmlClass("item")]
        public bool IsMenuItem => Parent is Menu; // TODO use IMenu e.g. Parent?.Implements<IMenu>

        [HtmlClass]
        public Color Color { get; set; }

        protected DropdownTitle DropdownTitle => dropdownTitle ?? (dropdownTitle = new DropdownTitle(this, 1));

        public DropdownIcon DropdownIcon { get; set; }

        protected DropdownTitle dropdownTitle;
    }

    [HtmlTag("div")]
    [HtmlClass("text")]
    public class DropdownTitle : ControlBase
    {
        public DropdownTitle(IComponent parent)
            : base(parent)
        {
        }

        public DropdownTitle(IComponent parent, int zorder)
            : base(parent)
        {
            ZOrder = zorder;
            Prefix = null;
        }
    }

    [HtmlTag("div")]
    [HtmlClass("dropdown")]
    public class Dropdown : DropdownBase
    {
        public Dropdown(IComponent parent)
            : base(parent)
        {
        }
    }

    public class DropdownIcon : Icon
    {
        public DropdownIcon(IComponent parent)
            : this(parent, 0)
        {
        }

        public DropdownIcon(IComponent parent, int zorder)
            : base(parent, zorder)
        {
            Symbol = Symbols.Dropdown;
        }
    }


    [HtmlTag("div")]
    [HtmlClass("selection dropdown")]
    public class SelectionDropdown : DropdownBase
    {
        public SelectionDropdown(IComponent parent)
            : base(parent)
        {
        }
    }

}
