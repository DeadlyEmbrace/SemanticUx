using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    // TODO add input labels as compositions

    [HtmlTag("div")]
    [HtmlClass("input")]
    public class Input : ControlBase, IIcon
    {
        public Input()
            : this(null)
        {
        }

        public Input(IComponent parent)
            : base(parent)
        {
            _input = new Components.Input(this);
        }

        [HtmlClass("fluid")]
        public bool Fluid { get; set; }

        [HtmlClass("inverted")]
        public bool Inverted { get; set; }

        [HtmlClass]
        public InputLabeled Labeled { get; set; }

        [HtmlClass]
        public InputAction Action { get; set; }

        [HtmlClass("transparent")]
        public bool Transparent { get; set; }

        [HtmlClass]
        public InputState State { get; set; }

        [HtmlClass]
        public InputSize Size { get; set; }

        public string PlaceHolder {
            get
            {
                return _input.PlaceHolder;
            }
            set
            {
                _input.PlaceHolder = value;
            }
        }

        public InputType Type
        {
            get
            {
                return _input.Type;
            }
            set
            {
                _input.Type = value;
            }
        }

        public string Value
        {
            get
            {
                return _input.Value;
            }
            set
            {
                _input.Value = value;
            }
        }

        public Icon Icon
        {
            get
            {
                Iconed = true;
                return _icon ?? (_icon = new Icon(this));
            }
        }

        [HtmlClass("icon")]
        public bool Iconed { get; set; }

        protected Icon _icon;

        protected readonly Components.Input _input;
    }


    public enum InputAction
    {
        _,
        Action,
        Left_Action,
        Right_Action
    }

    public enum InputLabeled
    {
        _,
        Labeled,
        Left_Labeled,
        Right_Labeled
    }

    public enum InputState
    {
        _,
        Focus,
        Loading,
        Disabled,
        Error
    }

    public enum InputSize
    {
        _,
        Mini,
        Small,
        Large,
        Big,
        Huge,
        Massive
    }
}
