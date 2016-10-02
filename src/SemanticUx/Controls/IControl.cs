using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    public interface IControl : IComponent
    {
        string Prefix { get; }
    }
}
