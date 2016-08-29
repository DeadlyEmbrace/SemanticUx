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

        public string Prefix { get; set; } = "ui";

        public string Name { get; set; }
    }
}