using System.Collections.Generic;

namespace SemanticUx.Components
{
    public class ComponentList : List<IComponent>, IComponentList
    {
        public void Render(IHtmlComposer htmlComposer)
        {
            foreach (var component in this)
            {
                htmlComposer.Compose(component);
            }
        }
    }
}
