using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Conventions;
using Nancy.ViewEngines;

namespace SemanticUx.Nancy.ViewEngine
{
    public class SemanticUiViewFactory : IViewFactory
    {
        public SemanticUiViewFactory(IViewResolver viewResolver, IEnumerable<IViewEngine> viewEngines,
            IRenderContextFactory renderContextFactory, ViewLocationConventions conventions,
            IRootPathProvider rootPathProvider)
        {
            ViewResolver = viewResolver;
            ViewEngines = viewEngines;
            RenderContextFactory = renderContextFactory;
            Conventions = conventions;
            RootPathProvider = rootPathProvider;
        }

        public Response RenderView(string viewName, dynamic model, ViewLocationContext viewLocationContext)
        {
            // TODO IViewLocator can also check for the attribute to assist in selection of engine
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var viewEngine = ViewEngines.FirstOrDefault(e => e.GetType() == typeof(SemanticUiViewEngine));
            var viewLocation = new ViewLocationResult(null, null, null, null);
            return viewEngine.RenderView(viewLocation, model, RenderContextFactory.GetRenderContext(viewLocationContext));
        }

        private ViewLocationConventions Conventions { get; }
        private IRenderContextFactory RenderContextFactory { get; }
        private IRootPathProvider RootPathProvider { get; }
        private IEnumerable<IViewEngine> ViewEngines { get; }
        private IViewResolver ViewResolver { get; }
    }
}
