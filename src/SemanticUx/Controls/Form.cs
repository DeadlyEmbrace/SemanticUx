using System.Collections.Generic;
using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    public interface IForm : IControl
    {
        IList<IField> Fields { get; }
    }

    [HtmlTag("form")]
    [HtmlClass("form")]
    public class Form : ControlBase, IForm
    {
        public Form()
            : this(null)
        {
        }

        public Form(IComponent parent)
            : base(parent)
        {
            Id = GetHashCode()
                .ToString();
        }

        public void AddToFields(IComponent component)
        {
            var item = component as IField;
            if (item != null)
            {
                Fields.Add(item);
            }
        }

        public IList<IField> Fields
        {
            get
            {
                var result = new List<IField>();
                GetFields(this, result);
                return result;
            }
        }

        [HtmlAttribute("name")]
        public string Name { get; set; }

        [HtmlAttribute("enctype")]
        public string Encoding { get; set;}

        [HtmlAttribute("autocomplete")]
        public AutoComplete AutoComplete { get; set; }

        [HtmlAttribute("method")]
        public FormMethod Method { get; set; }

        [HtmlAttribute("action")]
        public string Action { get; set; }

        [HtmlClass]
        public Size Size { get; set; }

        private static void GetFields(IComponent component, IList<IField> fields)
        {
            foreach (var item in component.Components)
            {
                var field = item as IField;
                if (field != null)
                {
                    fields.Add(field);
                }

                if (item.Count > 0)
                {
                    GetFields(item, fields);
                }
            }
        }

    }

    public enum FormMethod
    {
        Get,
        Post
    }

    public enum AutoComplete
    {
        On,
        Off
    }

    public static class Encoding
    {
        public const string Application = "application/x-www-form-urlencoded";
        public const string MultiPart = "multipart/form-data";
        public const string Text = "text/plain";
    }
}
