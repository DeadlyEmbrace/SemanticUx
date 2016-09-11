using AdminConsole.Controls;
using SemanticUx.Controls;
using SemanticUx.Extensions;

namespace AdminConsole.Views
{
    public class DefaultView : DefaultViewBase
    {
        public DefaultView(dynamic model)
        {
            // TODO make more composable by tracking registred modules and paths
            Navigator.Add(Symbols.WebContent.Home, "Home", "/");
            Navigator.Add(Symbols.WebContent.Calendar, "Projects", "/");
            Navigator.Add(Symbols.WebContent.Cloud, "Tasks", "/");
            MainMenu.Add(Symbols.WebContent.Sidebar, "#")
                .Toggle(Navigator);
            MainMenu.Add(new StaticMenuItem
            {
                Title = "Home"
            });

            var searchControl = new Input(new MenuItem(ControlMenu))
            {
                Inverted = true,
                PlaceHolder = "Search",
                Size = InputSize.Small
            }.WithIcon(Symbols.WebContent.Search);

            var controlDropdown = new DropdownMenu(ControlMenu)
            {
                Title = "Bob Jones"
            }.Show();

            controlDropdown.Add(Symbols.UserTypes.User, "Profile", "/");
            controlDropdown.Add(Symbols.WebContent.Settings, "Settings", "/");
            controlDropdown.AddDivider();
            controlDropdown.Add(Symbols.Computer.Power, "Sign Out", "/");

        }
    }
}
