namespace CommandTree
{
    public class Command
    {
        public Dictionary<string, Command>? Children { get; } = null;
        public Action<string[]>? Execute { get; } = null;
        public Command(Action<string[]> execute)
        {
            Execute = execute;
        }
        public Command(Dictionary<string, Command>? children)
        {
            Children = children;
        }
    }
}
