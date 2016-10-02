using AdminConsole.Modules.AccessControl.Views;
using SemanticUx.Nancy.ViewEngine;

namespace AdminConsole.Modules.AccessControl.Models
{
    [SemanticUxView(typeof(LoginView))]
    public class LoginModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
