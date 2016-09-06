using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("message")]
    public class Message : ControlBase
    {
        public Message()
            : this(null)
        {
        }

        public Message(IComponent parent)
            : base(parent)
        {
            Header = new MessageHeader(this);
        }

        public MessageHeader Header;
    }

    [HtmlTag("div")]
    [HtmlClass("header")]
    public class MessageHeader : ControlBase
    {
        public MessageHeader()
            : this(null)
        {
        }

        public MessageHeader(IComponent parent)
            : base(parent)
        {
            Prefix = null;
        }
    }
}
