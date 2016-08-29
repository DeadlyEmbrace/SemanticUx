using AdminConsole.Modules.AccessControl.Models;
using Nancy;
using SemanticUx.Components;

namespace AdminConsole.Modules.AccessControl
{
    public class Module : NancyModule
    {
        public Module()
        {
            Get["/login"] = parameters => new LoginModel();

            Post["/login"] = parameters =>
            {
                // process login
                return "";
            };

            Get["/logout"] = parameters =>
            {
                var htmlDocument = new Html5Document
                {
                    Title = "Logout"
                };

                return htmlDocument;
            };
        }
    }
}