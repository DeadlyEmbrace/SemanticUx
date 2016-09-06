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
            Parent = parent;
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

        public bool HasComponents => _components != null;

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

        public IComponent Parent { get; }

        public int ZOrder { get; set; }

        private IDictionary<string, string> _attributes;

        private IList<string> _classes;

        private IComponentList _components;

        public int CompareTo(object obj)
        {
            if (obj is IComponent)
            {
                if (ZOrder > ((IComponent) obj).ZOrder)
                {
                    return 1;
                } else if (ZOrder < ((IComponent) obj).ZOrder)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }
    }
}
