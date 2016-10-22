using System;

namespace NancyFxCustomResult
{
    public abstract class BaseModule
    {
        public Routes Routes = new Routes();

        protected void Register(string url, Func<Context, string> action)
        {
            Routes.Add(url.ToLower(), action);
        }
    }
}
