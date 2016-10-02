using AdminConsole.Modules.Users.Models;
using Nancy;
using SemanticUx.Components;

namespace AdminConsole.Modules.Users
{
    public class Module : NancyModule
    {
        public Module()
            : base("users")
        {
            Get["/signup"] = parameters =>
            {
                var htmlDocument = new Html5Document
                {
                    Title = "Login"
                };

                return htmlDocument;
            };

            Get["/confirm"] = parameters =>
            {
                var htmlDocument = new Html5Document
                {
                    Title = "Confirm"
                };

                return htmlDocument;
            };

            Get["/create"] = parameters => new CreateUserModel();

        }
    }
}
