using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    public static class IFieldExtensions
    {
        public static T AddFieldValidationRule<T>(this T self, string rule, string message)
            where T : IField
        {
            return (T)self.ValidationRules.Add(new FieldValidationRule
            {
                Type = rule,
                Prompt = message
            });
        }

        public static T Required<T>(this T self, string message = null)
            where T : IField
        {
            return AddFieldValidationRule(self, "empty", message);
        }

        public static Field MinLength(this Field self, int size, string message = null)
        {
            return AddFieldValidationRule(self, $"minLength[{size}]", message);
        }

        public static Field MaxLength(this Field self, int size, string message = null)
        {
            return AddFieldValidationRule(self, $"maxLength[{size}]", message);
        }

        public static Field Exactength(this Field self, int size, string message = null)
        {
            return AddFieldValidationRule(self, $"exactLength[{size}]", message);
        }

        public static Field Checked(this Field self, string message = null)
        {
            return AddFieldValidationRule(self, "checked", message);
        }

        public static Field Email(this Field self, string message = null)
        {
            return AddFieldValidationRule(self, "email", message);
        }

        public static Field Url(this Field self, string message = null)
        {
            return AddFieldValidationRule(self, $"url", message);
        }

        public static Field Integer(this Field self, string message = null)
        {
            return AddFieldValidationRule(self, "integer", message);
        }

        public static Field Integer(this Field self, int start, int end, string message = null)
        {
            return AddFieldValidationRule(self, $"integer[{start}..{end}]", message);
        }

        public static Field Decimal(this Field self, string message = null)
        {
            return AddFieldValidationRule(self, "decimal", message);
        }

        public static Field Number(this Field self, string message = null)
        {
            return AddFieldValidationRule(self, "number", message);
        }

        public static Field RexExp(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"regExp[{pattern}]", message);
        }

        public static Field CreditCard(this Field self, string message = null)
        {
            return AddFieldValidationRule(self, "creditCard", message);
        }

        public static Field CreditCard(this Field self, List<CreditCardType> providers, string message = null)
        {
            return AddFieldValidationRule(self, $"creditCard[{string.Join(",", providers.Select(e => e.ToString()))}]", message);
        }

        public static Field Contains(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"contains[{pattern}]", message);
        }

        public static Field ContainsExactly(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"containsExactly[{pattern}]", message);
        }

        public static Field DoesntContain(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"doesntContain[{pattern}]", message);
        }

        public static Field DoesntContainExactly(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"doesntContainExactly[{pattern}]", message);
        }

        public static Field Is(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"is[{pattern}]", message);
        }

        public static Field IsExactly(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"isExactly[{pattern}]", message);
        }

        public static Field Not(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"not[{pattern}]", message);
        }

        public static Field NotExactly(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"notExactly[{pattern}]", message);
        }

        public static Field Match(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"match[{pattern}]", message);
        }

        public static Field Different(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"different[{pattern}]", message);
        }

        public static Field MinCount(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"minCount[{pattern}]", message);
        }

        public static Field ExactCount(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"exactCount[{pattern}]", message);
        }

        public static Field MaxCount(this Field self, string pattern, string message = null)
        {
            return AddFieldValidationRule(self, $"maxCount[{pattern}]", message);
        }
    }
}
