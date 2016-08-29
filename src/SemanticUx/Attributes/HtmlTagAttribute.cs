using System;

namespace SemanticUx.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HtmlTagAttribute : Attribute
    {
        public HtmlTagAttribute(string tag)
        {
            Tag = tag;
        }

        public string Tag { get; set; }

        public bool IsEmpty { get; set; }
    }
}