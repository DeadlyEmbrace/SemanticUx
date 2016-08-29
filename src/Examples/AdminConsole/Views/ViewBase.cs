using SemanticUx.Components;

namespace AdminConsole.Views
{
    public abstract class ViewBase : Html5Document
    {
        protected ViewBase()
        {
            Title = "Admin Console";
            Scripts.Add("assets/jquery-3.1.0.min.js");
            Scripts.Add("assets/semantic.min.js");
            StyleSheets.Add("assets/semantic.min.css");
            StyleSheets.Add("assets/adminconsole.css");
        }
    }
}