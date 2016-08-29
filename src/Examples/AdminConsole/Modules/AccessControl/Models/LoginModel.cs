using AdminConsole.Modules.AccessControl.Views;
using SemanticUx.Nancy.ViewEngine;

namespace AdminConsole.Modules.AccessControl.Models
{
    [SemanticUiView(typeof(LoginView))]
    public class LoginModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
