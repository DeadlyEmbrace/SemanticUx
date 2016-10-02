using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Nancy;
using Nancy.Responses;
using Nancy.ViewEngines;
using SemanticUx.Components;

namespace SemanticUx.Nancy.ViewEngine
{
    public class SemanticUiViewEngine : IViewEngine
    {
        public void Initialize(ViewEngineStartupContext viewEngineStartupContext)
        {            
        }

        public Response RenderView(ViewLocationResult viewLocationResult, dynamic model, IRenderContext renderContext)
        {
            object typedModel = model;
            var viewAttribute = typedModel
                .GetType()
                .GetCustomAttribute<SemanticUxViewAttribute>();

            if (viewAttribute == null)
            {
                throw new InvalidOperationException("Use `SemanticUiViewAttribute` to specify a view class on the model");
            }

            // TODO use stream writing HtmlComposer
            var htmlComposer = new DefaultHtmlBuilder();
            var view = Activator.CreateInstance(viewAttribute.ViewType, model);
            htmlComposer.Compose(view);

            return new HtmlResponse(contents: stream =>
            {
                var writer = new StreamWriter(stream);
                writer.Write(htmlComposer.ToString());
                writer.Flush();
            });
        }

        public IEnumerable<string> Extensions { get; }
    }
}
