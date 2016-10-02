using System.Collections.Generic;
using System.Linq;
using SemanticUx.Components;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IModalExtensions
    {
        public static T ShowModal<T>(this T self, string onApprove = null, string onDeny = null) where T : IModal
        {
            var selector = $"$('#{self.Id}')";
            var closable = $"closable: {self.Closable}".ToLower();
            var approve = onApprove == null
                ? null
                : $"onApprove: function() {{{onApprove}}}";
            var deny = onDeny == null
                ? null
                : $"onDeny: function() {{{onDeny}}}";
            var elements = new List<string>
                {
                    closable,
                    approve,
                    deny
                }.Where(s => s != null)
                .ToArray();
            var settings = $".modal({{{string.Join(",", elements)}}})";
            var show = ".modal('show')";

            var script = new Script
            {
                Content = $"{selector}{settings}{show}"
            };
            self.Add(script);

            return self;
        }
    }
}
