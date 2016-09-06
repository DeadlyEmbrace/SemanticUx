using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SemanticUx.Attributes;
using SemanticUx.Controls;

namespace SemanticUx.Components
{
    public class DefaultHtmlBuilder : IHtmlBuilder
    {
        public DefaultHtmlBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        public string Compose(IComponent component)
        {
//#if DEBUG
//            var stopWatch = new Stopwatch();
//            stopWatch.Start();
//#endif            
            var tagAttribute = component.GetType()
                .GetCustomAttributes<HtmlTagAttribute>(true)
                .ToList()
                .FirstOrDefault();

            if (tagAttribute?.Tag != null)
            {
                _stringBuilder.Append("<")
                    .Append(tagAttribute.Tag);
                ComposeClassAttribute(component);
                ComposeAttributes(component);
                _stringBuilder.Append(">");
            }

            var htmlContentProperties = component.GetType()
                .GetProperties()
                .Where(propertyInfo => propertyInfo.GetCustomAttribute<HtmlContentAttribute>() != null);

            foreach (var htmlContentProperty in htmlContentProperties)
            {
                var value = htmlContentProperty.GetValue(component);
                var attr = htmlContentProperty.GetCustomAttribute<HtmlContentAttribute>();
                if (value != null)
                {
                    component.Components.Add(new Content(value.ToString(), attr.Index));
                }
            }

            if (component.Count > 0)
            {
                component.Components.Sort();
            }

            for (var i = 0; i < component.Count; i++)
            {
                if (component[i] is Content)
                {
                    _stringBuilder.Append(component[i]);
                }
                else
                {
                    Compose(component[i]);
                }                
            }

            if (tagAttribute?.Tag != null
                && !tagAttribute.IsEmpty)
            {
                _stringBuilder.Append("</")
                    .Append(tagAttribute.Tag)
                    .Append(">");
            }

//#if DEBUG
//            stopWatch.Stop();
//            _stringBuilder.Append("<!-- ")
//                .Append(stopWatch.ElapsedMilliseconds)
//                .Append(" ms -->");
//#endif

            return _stringBuilder.ToString();
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }

        private void ComposeAttributes(IComponent component)
        {
            var propertyInfos = component.GetType()
                .GetProperties();

            if (component.Id != null)
            {
                _stringBuilder.Append(" id")
                    .Append("=\"")
                    .Append(component.Id)
                    .Append("\"");
            }

            foreach (var propertyInfo in propertyInfos)
            {
                var htlmlAttributes = propertyInfo.GetCustomAttributes<HtmlAttributeAttribute>(true)
                    .ToList();

                foreach (var htmlAttribute in htlmlAttributes)
                {
                    var value = propertyInfo.GetValue(component);
                    if (value is bool)
                    {
                        if ((bool) value)
                        {
                            _stringBuilder.Append(" ")
                                .Append(htmlAttribute.Key)
                                .Append("=\"")
                                .Append(htmlAttribute.Value)
                                .Append("\"");
                        }
                    }
                    else
                    {
                        if (value != null)
                        {
                            _stringBuilder.Append(" ")
                                .Append(htmlAttribute.Key)
                                .Append("=\"")
                                .Append(value)
                                .Append("\"");
                        }
                    }
                }
            }
        }

        private void ComposeClassAttribute(IComponent component)
        {
            var classes = new List<string>();
            var propertyInfos = component.GetType()
                .GetProperties()
                .Where(propertyinfo => propertyinfo.GetCustomAttribute<HtmlClassAttribute>() != null);

            foreach (var propertyInfo in propertyInfos)
            {
                var htmlAttribute = propertyInfo.GetCustomAttribute<HtmlClassAttribute>();
                var value = propertyInfo.GetValue(component);
                if (value is bool)
                {
                    if ((bool) value)
                    {
                        classes.Add(htmlAttribute.Name);
                    }
                }
                else
                {
                    if (value != null
                        && value.ToString() != "_")
                    {
                        classes.Add(value.ToString()
                            .ToLower());
                    }
                }
            }

            var classClassAttribute = component.GetType()
                .GetCustomAttribute<HtmlClassAttribute>();

            if (classClassAttribute != null)
            {
                classes.Add(classClassAttribute.Name);
            }

            var control = component as IControl;
            if (control?.Prefix != null)
            {
                classes.Insert(0, control.Prefix);
            }

            // TODO not cool but works - cannot assume implementation type
            ComponentBase.Helper.CopyClasses((ComponentBase)component, classes);
            // END

            if (classes.Count > 0)
            {                
                _stringBuilder.Append(" class=\"");
                _stringBuilder.Append(string.Join(" ", classes));
                _stringBuilder.Append("\"");
            }
        }

        private readonly StringBuilder _stringBuilder;
    }
}
