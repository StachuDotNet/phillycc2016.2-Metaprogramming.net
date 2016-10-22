
namespace NancyFxCustomResult
{
    public class HomeModule : BaseModule
    {
        public HomeModule()
        {
            Register("/", _ => "Home");
            Register("/contact", _ => "Contact");
        }
    }
}
