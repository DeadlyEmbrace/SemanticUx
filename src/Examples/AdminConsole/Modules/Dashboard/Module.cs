using Nancy;

namespace AdminConsole.Modules.Dashboard
{
    public class Module : NancyModule
    {
        public Module()
        {
            // TODO find a better way to map modules
            Get["/"] = parameters =>
            {
                return new Models.DashboardModel();
            };
        }
    }
}
