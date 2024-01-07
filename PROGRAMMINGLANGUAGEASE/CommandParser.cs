using System;
using System.Collections.Generic;
using System.Threading;

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
            Thread parseThread = new Thread(() => ParseCommand(commandText));
            parseThread.Start();
            parseThread.Join(); // Wait for the thread to complete
        }

        /// <summary>
        /// Parses the command string into the Command and Args properties.
        /// </summary>
        /// <param name="commandText">The command string to parse.</param>
        private void ParseCommand(string commandText)
        {
            string[] commandParts = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Split by space and Remove Empty Entries.

            if (commandParts.Length == 0)
            {
                Command = "";
                Args = Array.Empty<string>(); // If there are no parts set Command and Args to empty values.
                return;
            }

            Command = commandParts[0]; // Assign first part as the Command.

            if (commandParts.Length > 1) // If more parts exist PraseArguments is called to extract and assign the arguments.
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
        private string[] ParseArguments(string[] commandParts, int startIndex) // CommandParts represent the Command, Start Index represents the index from which to start parsing the arguments.
        {
            List<string> arguments = new List<string>(); // List initialized to to store the parsed arguments.

            for (int i = startIndex; i < commandParts.Length; i++) // Iterate over the commandParts array.
            {
                arguments.Add(commandParts[i]); // Adding Command Parts to arguments list.
            }

            return arguments.ToArray(); // Convert arguments list back to array.
        }
    }
}