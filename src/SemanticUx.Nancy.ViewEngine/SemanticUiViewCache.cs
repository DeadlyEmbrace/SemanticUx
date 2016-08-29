using System;
using Nancy.ViewEngines;

namespace SemanticUx.Nancy.ViewEngine
{
    public class SemanticUiViewCache : IViewCache
    {
        public TCompiledView GetOrAdd<TCompiledView>(ViewLocationResult viewLocationResult, Func<ViewLocationResult, TCompiledView> valueFactory)
        {
            throw new NotImplementedException();
        }
    }
}
