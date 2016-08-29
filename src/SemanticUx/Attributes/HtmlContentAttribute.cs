using System;

namespace SemanticUx.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HtmlContentAttribute : Attribute
    {
        public HtmlContentAttribute()
            : this(0)
        {
        }

        public HtmlContentAttribute(int index)
        {
            Index = index;
        }

        public int Index { get; set; }
    }
}