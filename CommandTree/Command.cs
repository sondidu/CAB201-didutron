﻿using ConstantsAndHelpers;
namespace CommandTree
{
    public class Command
    {
        public Dictionary<string, Command>? Children { get; }
        public Action<string[]> Execute { get; } = ErrorMessages.EmptyExecute;
        public string? UnspecifiedCommandKeyMsg { get; }
        public string? InvalidCommandKeyMsg { get; }
        public Command(Action<string[]> execute)
        {
            Execute = execute;
        }
        public Command(Dictionary<string, Command> children, string invalidCommandKeyMsg = ErrorMessages.InvalidCommandKey, string unspecifiedCommandKeyMsg = ErrorMessages.UnspecifiedCommandKey)
        {
            Children = children;
            InvalidCommandKeyMsg = invalidCommandKeyMsg;
            UnspecifiedCommandKeyMsg = unspecifiedCommandKeyMsg;
        }
    }
}