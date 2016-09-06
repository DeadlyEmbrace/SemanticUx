using SemanticUx.Controls;

namespace AdminConsole.Views
{
    public abstract class DefaultViewBase : ViewBase
    {
        protected DefaultViewBase()
        {
            Navigator = new Sidebar(this);

            Container = new Pusher(this);

            MainMenu = new Menu(Container)
            {
                Id = MainMenuCssClass,
                Icon = true,
                Inverted = true,
                Color = Color.Blue
            };

            ControlMenu = new Menu(MainMenu)
            {
                Alignment = MenuAlignment.Right,
                ZOrder = 999
            };
        }

        public Pusher Container { get; }

        public Menu ControlMenu { get; }

        public Menu MainMenu { get; }

        public Sidebar Navigator { get; }

        private const string MainMenuCssClass = "mainmenu";
    }
}
