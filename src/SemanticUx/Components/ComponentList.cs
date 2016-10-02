using System.Collections.Generic;

namespace SemanticUx.Components
{
    public class ComponentList : List<IComponent>, IComponentList
    {
        public void Render(IHtmlBuilder htmlBuilder)
        {
            foreach (var component in this)
            {
                htmlBuilder.Build(component);
            }
        }
    }
}
