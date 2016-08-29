using System;

namespace SemanticUx.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HtmlDocTypeAttribute : Attribute
    {
        public HtmlDocTypeAttribute(string docType)
        {
            DocType = docType;
        }

        public string DocType { get; set; }
    }

}
