using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using SemanticUx.Components;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IFormExtensions
    {
        public static T Submit<T>(this T self)
            where T : IForm
        {
            var selector = $"$('#{self.Id}')";
            var script = new Script
            {
                Content = $"{selector}.form('submit');"
            };
            self.Add(script);

            return self;
        }

        public static string DoSubmit(this IForm self)
        {
            var selector = $"$('#{self.Id}')";
            return $"{selector}.form('submit');";
        }

        public static string DoValidateSubmit(this IForm self)
        {
            var selector = $"$('#{self.Id}')";
            return $"return {selector}.form('validate form');";
        }

        public static T Reset<T>(this T self)
            where T : IForm
        {
            var selector = $"$('#{self.Id}')";
            var script = new Script
            {
                Content = $"{selector}.form('reset');"
            };
            self.Add(script);

            return self;
        }

        public static T Clear<T>(this T self)
            where T : IForm
        {
            var selector = $"$('#{self.Id}')";
            var script = new Script
            {
                Content = $"{selector}.form('clear');"
            };
            self.Add(script);

            return self;
        }

        public static T Validate<T>(this T self)
            where T : IForm
        {

            var fields = self.Fields;

            if (fields.Count == 0)
            {
                return self;
            }

            var scriptBuilder = new StringBuilder();

            self.Id = self.GetHashCode()
                .ToString();
            scriptBuilder.Append("{fields:{");

            var fieldCount = 0;

            foreach (var field in fields)
            {
                if (fieldCount > 0)
                {
                    scriptBuilder.Append(",");
                }

                scriptBuilder.Append(field.Name)
                    .Append(":{")
                    .Append("identifier: '")
                    .Append(field.Name)
                    .Append("',")
                    .Append("rules:[");

                var ruleCount = 0;

                foreach (var fieldValidationRule in field.ValidationRules)
                {
                    if (ruleCount > 0)
                    {
                        scriptBuilder.Append(",");
                    }

                    scriptBuilder.Append("{");
                    scriptBuilder.Append("type:'")
                        .Append(fieldValidationRule.Type)
                        .Append("'");

                    if (fieldValidationRule.Prompt != null)
                    {
                        scriptBuilder.Append(",prompt: '")
                            .Append(fieldValidationRule.Prompt)
                            .Append("'");
                    }
                    scriptBuilder.Append("}");

                    ruleCount++;
                }

                scriptBuilder.Append("]}");
                fieldCount++;
            }

            scriptBuilder.Append("}}");
            var script = new Script
            {
                Content = $"$('#{self.Id}').form({scriptBuilder});"
            };
            self.Add(script);

            return self;
        }
    }
}
