using AdminConsole.Controls;
using SemanticUx.Components;
using SemanticUx.Controls;
using SemanticUx.Extensions;
using Input = SemanticUx.Controls.Input;

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
            }.ShowDropdown();

            controlDropdown.Add(Symbols.UserTypes.User, "Profile", "/");
            controlDropdown.Add(Symbols.WebContent.Settings, "Settings", "/");
            controlDropdown.AddDivider();
            controlDropdown.Add(Symbols.Computer.Power, "Sign Out", "/");


            var modal = new Modal(this)
            {
                Title = "Hello World"
            };

            // TODO temp
            var form = new Form(modal.Content)
            {
                Method = FormMethod.Post
            };

            var emailField = new Field(form)
            {
                Name = "email",
                PlaceHolder = "Email Address",
                Type = InputType.Email
            }.Email();

            var passwordField = new Field(form)
            {
                Name = "password",
                PlaceHolder = "Password",
                Type = InputType.Password
            }.Required();

            var validationMessage = new Message(form)
            {
                Kind = MessageKind.Error
            };

            var buttonOk = new Button(modal.Actions)
            {
                Title = "OK",
                Positive = true
            };

            var buttonCancel = new Button(modal.Actions)
            {
                Title = "Cancel",
                Negative = true
            };

            form.Validate();

            // END


            var buttonOne = new Button(Container)
            {
                Id = "123",
                Title = "Load Remote Dialog"
            };
            buttonOne.Load("/users/create");  // TODO temp

            var buttonTwo = new Button(Container)
            {
                Id = "456",
                Title = "Local Dialog with validation"
            };
            buttonTwo.Show(modal, form.DoValidateSubmit());



        }
    }
}
