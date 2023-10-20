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

            switch (Command.ToLower())
            {
                case "moveto":
                    HandlePositionCommand(commandParts);
                    break;
                case "pen":
                    HandlePenCommand(commandParts);
                    break;
                case "fill":
                    HandleFillCommand(commandParts);
                    break;
                case "clear":
                    HandleClearCommand();
                    break;
                case "reset":
                    HandleResetCommand();
                    break;
                case "rectangle":
                    HandleRectangleCommand(commandParts);
                    break;
                case "circle":
                    HandleCircleCommand(commandParts);
                    break;
                case "triangle":
                    HandleTriangleCommand(commandParts);
                    break;
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

        private void HandlePositionCommand(string[] commandParts)
        {
            
        }

        private void HandlePenCommand(string[] commandParts)
        {
           
        }

        private void HandleFillCommand(string[] commandParts)
        {
            
        }

        private void HandleClearCommand()
        {
           
        }

        private void HandleResetCommand()
        {
         
        }

        private void HandleRectangleCommand(string[] commandParts)
        {
         
        }

        private void HandleCircleCommand(string[] commandParts)
        {
        
        }

        private void HandleTriangleCommand(string[] commandParts)
        {
        
        }
    }
}
