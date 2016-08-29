using System.Collections.Generic;
using System.Linq;
using SemanticUx.Attributes;
using SemanticUx.Extensions;

namespace SemanticUx.Components
{
    public abstract class ComponentBase : IComponent
    {
        protected ComponentBase()
        {
        }

        protected ComponentBase(IComponent parent)
        {
            parent?.Components.Add(this);
        }

        public void AddTo(IComponent component)
        {
            component.Add(this);
        }

        public IComponentList Components => _components ?? (_components = new ComponentList());

        public void Add(IComponent component)
        {
            Components.Add(component);
        }

        public string Id { get; set; }

        public IComponent this[int index] => _components?[index];

        public int Count => _components?.Count ?? 0;

        public IDictionary<string, string> Attributes => _attributes ?? (_attributes = new Dictionary<string, string>())
            ;

        public IList<string> Classes => _classes ?? (_classes = new List<string>());

        [HtmlContent]
        public string Content { get; set; }

        public bool HasComponents => _components != null;

        public int ZOrder { get; set; }

        private IDictionary<string, string> _attributes;

        private IList<string> _classes;

        private IComponentList _components;

        public static class Helper
        {
            public static void CopyClasses(ComponentBase source, IList<string> dest)
            {
                if (source._classes == null)
                {
                    return;
                }

                dest.Add(source._classes.ToArray());
            }
        }
    }
}
