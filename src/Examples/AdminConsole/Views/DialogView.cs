using SemanticUx.Components;
using SemanticUx.Extensions;

namespace AdminConsole.Views
{
    public class DialogView : ViewBase
    {
        public DialogView()
        {
            StyleSheets.Add("assets/dialog.css");

            var outer = new Div(Body);
            outer.Classes.Add("ui", "middle", "aligned", "center", "aligned", "grid");
            var inner = new Div(outer);
            inner.Classes.Add("column");
            Container = inner;
        }

        public Div Container { get; }
    }
}