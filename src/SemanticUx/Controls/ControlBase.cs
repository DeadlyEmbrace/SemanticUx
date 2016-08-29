using SemanticUx.Components;

namespace SemanticUx.Controls
{
    public abstract class ControlBase : ComponentBase,
        IControl
    {
        protected ControlBase()
        {
        }

        protected ControlBase(IComponent parent)
            : base(parent)
        {
        }
    }
}
