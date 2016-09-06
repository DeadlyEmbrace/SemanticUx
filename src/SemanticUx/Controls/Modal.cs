using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("modal")]
    public class Modal : ControlBase
    {
        public Modal(IComponent parent)
            : base(parent)
        {
            Id = GetHashCode()
                .ToString();
            CloseIcon = new Icon(this);
            Header = new ModalHeader(this);
            Content = new ModalContent(this);
            Actions = new ModalActions(this);
        }

        public ModalActions Actions { get; }
        public Icon CloseIcon { get; }
        public ModalContent Content { get; }

        [HtmlClass("fullscreen")]
        public bool FullScreen { get; set; }

        public ModalHeader Header { get; }

        [HtmlClass]
        public ModalSize Size { get; set; }

        [HtmlClass]
        public ModalType Type { get; set; }
    }

    [HtmlTag("div")]
    [HtmlClass("header")]
    public class ModalHeader : ComponentBase
    {
        public ModalHeader(IComponent parent)
            : base(parent)
        {
        }
    }

    [HtmlTag("div")]
    [HtmlClass("content")]
    public class ModalContent : ComponentBase
    {
        public ModalContent(IComponent parent)
            : base(parent)
        {
        }
    }

    [HtmlTag("div")]
    [HtmlClass("actions")]
    public class ModalActions : ComponentBase
    {
        public ModalActions(IComponent parent)
            : base(parent)
        {
        }
    }

    public enum ModalSize
    {
        _,
        Small,
        Large
    }

    public enum ModalType
    {
        Modal,
        Basic
    }
}
