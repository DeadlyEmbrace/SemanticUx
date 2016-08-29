using SemanticUx.Components;
using SemanticUx.Controls;
using SemanticUx.Extensions;

namespace AdminConsole.Views
{
    public abstract class DefaultViewBase : ViewBase
    {
        protected DefaultViewBase()
        {            

            Navigator = new Sidebar(this);
            Container = new Pusher(this);
        }

        public Sidebar Navigator { get; }

        public Pusher Container { get; }
    }
}
