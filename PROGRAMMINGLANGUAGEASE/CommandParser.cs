using System;
using System.Collections.Generic;

namespace ProgrammingLanguageAssignment
{
    public class CommandParser
    {
        public string Command { get; private set; } = "";
        public string[] Args { get; private set; } = Array.Empty<string>();

        public CommandParser(string commandText)
        {
            ParseCommand(commandText);
        }

        private void ParseCommand(string commandText)
        {
            string[] commandParts = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (commandParts.Length == 0)
            {
                Command = "";
                Args = Array.Empty<string>();
                return;
            }

            Command = commandParts[0];

            if (commandParts.Length > 1)
            {
                Args = ParseArguments(commandParts, 1);
            }
            else
            {
                Args = Array.Empty<string>();
            }
        }

        private string[] ParseArguments(string[] commandParts, int startIndex)
        {
            List<string> arguments = new List<string>();

            for (int i = startIndex; i < commandParts.Length; i++)
            {
                arguments.Add(commandParts[i]);
            }

            return arguments.ToArray();
        }
    }
}
