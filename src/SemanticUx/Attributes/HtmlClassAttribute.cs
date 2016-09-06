using System;

namespace SemanticUx.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class HtmlClassAttribute : Attribute
    {
        public HtmlClassAttribute()
        {
        }

        public HtmlClassAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}