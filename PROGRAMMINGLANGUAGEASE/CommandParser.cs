using System;
using System.Collections.Generic;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Parses a command string into a command and its arguments.
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// Gets the parsed command.
        /// </summary>
        public string Command { get; private set; } = "";

        /// <summary>
        /// Gets the parsed arguments of the command.
        /// </summary>
        public string[] Args { get; private set; } = Array.Empty<string>();

        /// <summary>
        /// Initializes a new instance of the CommandParser class with a command string.
        /// </summary>
        /// <param name="commandText">The command string to parse.</param>
        public CommandParser(string commandText)
        {
            ParseCommand(commandText);
        }

        /// <summary>
        /// Parses the command string into the Command and Args properties.
        /// </summary>
        /// <param name="commandText">The command string to parse.</param>
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

        /// <summary>
        /// Parses the arguments from the command parts starting from a given index.
        /// </summary>
        /// <param name="commandParts">The array of command parts.</param>
        /// <param name="startIndex">The start index for parsing arguments.</param>
        /// <returns>An array of arguments.</returns>
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