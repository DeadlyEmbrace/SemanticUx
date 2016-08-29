using System;

namespace SemanticUx.Nancy.ViewEngine
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SemanticUiViewAttribute : Attribute
    {
        public SemanticUiViewAttribute(Type viewType)
        {
            ViewType = viewType;
        }

        public Type ViewType { get; set; }
    }
}
