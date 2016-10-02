using System;

namespace SemanticUx.Nancy.ViewEngine
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SemanticUxViewAttribute : Attribute
    {
        public SemanticUxViewAttribute(Type viewType)
        {
            ViewType = viewType;
        }

        public Type ViewType { get; set; }
    }
}
