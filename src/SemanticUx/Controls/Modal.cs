using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    public interface IModal : IComponent
    {
        bool Closable { get; }
    }

    [HtmlTag("div")]
    [HtmlClass("modal")]
    public sealed class Modal : ControlBase, IModal
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

        public string Title
        {
            get
            {
                return Header.Title;
            }
            set
            {
                Header.Title = value;
            }
        }

        [HtmlClass("closable")]
        public bool Closable { get; set; }

        [HtmlClass("fullscreen")]
        public bool FullScreen { get; set; }

        private ModalHeader Header { get; }

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

        [HtmlContent]
        public string Title { get; set; }
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
