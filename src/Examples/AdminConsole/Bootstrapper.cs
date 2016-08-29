using Nancy;
using Nancy.Conventions;
using SemanticUx.Nancy.ViewEngine;

namespace AdminConsole
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        public Bootstrapper()
        {
            // TODO what is really needed
            InternalConfiguration.ViewLocator = typeof(SemanticUiViewLocator);
            InternalConfiguration.ViewFactory = typeof(SemanticUiViewFactory);
            InternalConfiguration.ViewCache = typeof(SemanticUiViewCache);
            InternalConfiguration.ViewResolver = typeof(SemanticUiViewResolver);
            // END
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("assets", "assets"));
        }
    }
}
