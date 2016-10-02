using System.Collections.Generic;
using System.Linq;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IFieldExtensions
    {
        public static T AddFieldValidationRule<T>(this T self, string rule, string message) where T : IField
        {
            return (T) self.ValidationRules.Add(new FieldValidationRule
            {
                Type = rule,
                Prompt = message
            });
        }

        public static T Checked<T>(this T self, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, "checked", message);
        }

        public static T Contains<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"contains[{pattern}]", message);
        }

        public static T ContainsExactly<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"containsExactly[{pattern}]", message);
        }

        public static T CreditCard<T>(this T self, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, "creditCard", message);
        }

        public static T CreditCard<T>(this T self, List<CreditCardType> providers, string message = null)
            where T : IField
        {
            return AddFieldValidationRule(self,
                $"creditCard[{string.Join(",", providers.Select(e => e.ToString()))}]",
                message);
        }

        public static T Decimal<T>(this T self, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, "decimal", message);
        }

        public static T Different<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"different[{pattern}]", message);
        }

        public static T DoesntContain<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"doesntContain[{pattern}]", message);
        }

        public static T DoesntContainExactly<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"doesntContainExactly[{pattern}]", message);
        }

        public static T Email<T>(this T self, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, "email", message);
        }

        public static T ExactCount<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"exactCount[{pattern}]", message);
        }

        public static T Exactength<T>(this T self, int size, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"exactLength[{size}]", message);
        }

        public static T Integer<T>(this T self, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, "integer", message);
        }

        public static T Integer<T>(this T self, int start, int end, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"integer[{start}..{end}]", message);
        }

        public static T Is<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"is[{pattern}]", message);
        }

        public static T IsExactly<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"isExactly[{pattern}]", message);
        }

        public static T Match<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"match[{pattern}]", message);
        }

        public static T MaxCount<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"maxCount[{pattern}]", message);
        }

        public static T MaxLength<T>(this T self, int size, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"maxLength[{size}]", message);
        }

        public static T MinCount<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"minCount[{pattern}]", message);
        }

        public static T MinLength<T>(this T self, int size, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"minLength[{size}]", message);
        }

        public static T Not<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"not[{pattern}]", message);
        }

        public static T NotExactly<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"notExactly[{pattern}]", message);
        }

        public static T Number<T>(this T self, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, "number", message);
        }

        public static T Required<T>(this T self, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, "empty", message);
        }

        public static T RexExp<T>(this T self, string pattern, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"regExp[{pattern}]", message);
        }

        public static T Url<T>(this T self, string message = null) where T : IField
        {
            return AddFieldValidationRule(self, $"url", message);
        }
    }
}
