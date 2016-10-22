using Nancy;

namespace NancyFxDemo
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Home";
            Get["/contact"] = _ => "Contact";
        }
    }
}
