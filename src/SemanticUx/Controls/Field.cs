using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("field")]
    public class Field : ControlBase
    {
        public Field()
            : this(null)
        {
        }

        public Field(IComponent parent)
            : base(parent)
        {
            // TODO how can label not be rendered if it has no content
            label = new Label(this);
            input = new Input(this);
            Prefix = null;
        }

        public string PlaceHolder
        {
            get
            {
                return input.PlaceHolder;
            }
            set
            {
                input.PlaceHolder = value;
            }
        }

        [HtmlContent]
        public string Label { get; set; }

        public InputType Type
        {
            get
            {
                return input.Type;
            }
            set
            {
                input.Type = value;
            }
        }

        protected Input input;

        protected Label label;
    }
}
