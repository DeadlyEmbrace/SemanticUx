using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines;

namespace SemanticUx.Nancy.ViewEngine
{
    public class SemanticUiViewLocator : IViewLocator
    {
        public ViewLocationResult LocateView(string viewName, NancyContext context)
        {
            throw new NotSupportedException("SemanticUi.Nancy.ViewEngine does not require view locator support");
        }

        public IEnumerable<ViewLocationResult> GetAllCurrentlyDiscoveredViews()
        {
            throw new NotSupportedException("SemanticUi.Nancy.ViewEngine does not require view locator support");
        }
    }
}
