using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    public sealed class Content : ComponentBase
    {
        public Content(string text)
            : this(text, 0)
        {
        }

        public Content(string text, int index)
        {
            _text = text;
            ZOrder = index;
        }

        private string _text { get; }

        public override string ToString()
        {
            return _text;
        }
    }
}
