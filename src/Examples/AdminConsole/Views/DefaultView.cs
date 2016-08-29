using SemanticUx.Controls;
using SemanticUx.Extensions;

namespace AdminConsole.Views
{
    public class DefaultView : DefaultViewBase
    {
        public DefaultView(dynamic model)
        {
            // TODO make more composable by tracking registred modules and paths
            Navigator.Add(Symbols.WebContent.Sidebar, "Home", "/");
            Navigator.Add(Symbols.WebContent.Calendar, "Projects", "/");
            Navigator.Add(Symbols.WebContent.Cloud, "Tasks", "/");

            var modal = new Modal(Container)
            {
                Type = ModalType.Basic
            };

            var button = new Button(Container)
            {
                Title = "Beep"
            };

            //button.Show(modal);
            button.Toggle(Navigator);

        }
    }
}
