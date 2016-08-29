using AdminConsole.Views;
using SemanticUx.Components;
using SemanticUx.Controls;

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
                PlaceHolder = "Email Address",
                Type = InputType.Email
            };

            var passwordField = new Field(segment)
            {
                PlaceHolder = "Password",
                Type = InputType.Password
            };

            var button = new Button(segment)
            {
                Title = "Login",
                Fluid = true,
                Size = Size.Large
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

        }
    }
}
