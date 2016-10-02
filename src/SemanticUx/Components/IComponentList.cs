using System.Collections.Generic;

namespace SemanticUx.Components
{
    public interface IComponentList : IList<IComponent>
    {
        void Sort();
    }
}
