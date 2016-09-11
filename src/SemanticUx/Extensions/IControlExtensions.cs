using System;
using System.Collections.Generic;
using System.Linq;
using SemanticUx.Components;
using SemanticUx.Controls;

namespace SemanticUx.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IControlExtensions
    {
        public static T Show<T>(this T self, IModal modal, string onApprove = null, string onDeny = null)
            where T : IControl
        {
            var selector = $"$('#{modal.Id}')";
            var closable = $"closable: {modal.Closable}".ToLower();
            var approve = onApprove == null
                ? null
                : $"onApprove: function() {{{onApprove}}}";
            var deny = onDeny == null
                ? null
                : $"onDeny: function() {{{onDeny}}}";
            var elements = new List<string> { closable, approve, deny}.Where(s => s != null).ToArray();
            var settings = $".modal({{{string.Join(",", elements)}}})";
            var show = ".modal('show')";

            self.Id = self.GetHashCode()
                .ToString();
            var script = new Script
            {
                Content = $"$('#{self.Id}').on('click', function(e) {{{selector}{settings}{show};}});"
            };
            self.Add(script);

            return self;
        }

        public static TControl Load<TControl, TComponent>(this TControl self, TComponent target, string url)
            where TControl : IControl
            where TComponent : IComponent
        {
            return Load(self, target.Id, url);
        }

        public static T Load<T>(this T self, string url)
            where T : IControl
        {
            var handler = $"function( data ) {{ $('body').append(data); }}";
            var script = new Script
            {
                Content = $"$('#{self.Id}').on('click', function(e) {{$.get('{url}', {handler}, 'html');}});"
            };
            self.Add(script);

            return self;
        }

        public static T Load<T>(this T self, string target, string url)
            where T : IControl
        {
            var id = string.IsNullOrEmpty(target)
                ? "document.documentElement"
                : $"'#{target}'";
            var selector = $"$({id})";

            var script = new Script
            {
                Content = $"$('#{self.Id}').on('click', function(e) {{{selector}.load('{url}');}});"
            };
            self.Add(script);

            return self;
        }

        public static T Toggle<T>(this T self, Sidebar sidebar) where T : IControl
        {
            return Toggle<T>(self, sidebar, SidebarTransition.Push);
        }

        public static T Toggle<T>(this T self, Sidebar sidebar, SidebarTransition sidebarTransition) where T : IControl
        {
            var selector = $"$('#{sidebar.Id}')";
            var transition = $".sidebar('setting', 'transition', '{sidebarTransition}')";
            var toggle = ".sidebar('toggle')";
            self.Id = self.GetHashCode()
                .ToString();
            var script = new Script
            {
                Content = $"$('#{self.Id}').on('click', function(e) {{{selector}{transition}{toggle};}});"
            };
            self.Add(script);

            return self;
        }
    }
}
