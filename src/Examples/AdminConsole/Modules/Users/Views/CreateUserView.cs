using AdminConsole.Views;
using SemanticUx.Components;
using SemanticUx.Controls;
using SemanticUx.Extensions;

namespace AdminConsole.Modules.Users.Views
{
    public class CreateUserView : ModalView
    {
        public CreateUserView(dynamic model)
        {
            var modal = new Modal(this)
            {
                Title = "Create User"
            };

            // TODO temp
            var form = new Form(modal.Content)
            {
                Method = FormMethod.Post
            };

            var emailField = new Field(form)
            {
                Label = "Email",
                Name = "email",
                PlaceHolder = "Email Address",
                Type = InputType.Email
            }.Email();

            var passwordField = new Field(form)
            {
                Label = "Password",
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

            // TODO cleanup dialog after popup
            modal.ShowModal();

            form.Validate();

        }
    }
}
