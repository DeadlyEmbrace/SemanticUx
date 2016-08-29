using System;

namespace SemanticUx.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HtmlAttributeAttribute : Attribute
    {
        public HtmlAttributeAttribute(string key)
            : this(key, null)
        {
        }

        public HtmlAttributeAttribute(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
