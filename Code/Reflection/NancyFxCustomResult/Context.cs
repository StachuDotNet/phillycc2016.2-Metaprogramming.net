namespace NancyFxCustomResult
{
    public class Context
    {
        public string Headers { get; set; }
        public Verb Verb { get; set; }
    }

    public enum Verb
    {
        GET, DELETE, PUSH, PUT
    }
}
