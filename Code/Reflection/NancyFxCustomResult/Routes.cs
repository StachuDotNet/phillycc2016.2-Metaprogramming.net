using System;
using System.Collections.Generic;

namespace NancyFxCustomResult
{
    public class Routes : Dictionary<string, Func<Context, string>> { }
}
