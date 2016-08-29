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
            messageHeader = new MessageHeader(this);
        }

        public string Header
        {
            get
            {
                return messageHeader.Content;
            }
            set
            {
                messageHeader.Content = value;
            }
        }

        protected MessageHeader messageHeader;
    }

    [HtmlTag("div")]
    [HtmlClass("header", Prefix = null)]
    public class MessageHeader : ComponentBase
    {
        public MessageHeader()
            : this(null)
        {
        }

        public MessageHeader(IComponent parent)
            : base(parent)
        {
        }
    }
}
