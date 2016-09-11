using AdminConsole.Views;
using SemanticUx.Components;
using SemanticUx.Controls;
using SemanticUx.Extensions;

namespace AdminConsole.Modules.AccessControl.Views
{
    public class LoginView : DialogView
    {
        public LoginView(dynamic model)
        {
            Title = "Login";

            var header = new ContentHeader(Container)
            {
                Color = Color.Blue,
                Title = "Login to the AdminConsole",
                Size = Size.Large
            };

            var form = new Form(Container)
            {
                Size = Size.Large,
                Method = FormMethod.Post
            };

            var segment = new Segment(form)
            {
                Color = Color.Blue,
                Inverted = true,
                Raised = true
            };

            var emailField = new Field(segment)
            {
                Name = "email",
                PlaceHolder = "Email Address",
                Type = InputType.Email
            }.Email();

            var passwordField = new Field(segment)
            {
                Name = "password",
                PlaceHolder = "Password",
                Type = InputType.Password
            }.Required();

            var button = new Button(segment)
            {
                Title = "Login",
                Fluid = true,
                Size = Size.Large,
                Submit = true
            };

            var validationMessage = new Message(segment)
            {
                Kind = MessageKind.Error
            };

            var message = new Message(Container);
            var signupLink = new A(message)
            {
                Href = "/signup",
                Content = "Not registered yet or "
            };

            var loginHelpLink = new A(message)
            {
                Href = "/loginassist",
                Content = "need help?"
            };

            form.Validate();

        }
    }
}
