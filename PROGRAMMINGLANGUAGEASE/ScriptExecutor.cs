using ProgrammingLanguageAssignment;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE
{
    public class ScriptExecutor
    {
        private Canvas canvas;
        private Form form; // To handle UI thread operations

        public ScriptExecutor(Canvas canvas, Form form)
        {
            this.canvas = canvas;
            this.form = form;
        }

        public void ExecuteScript(string scriptContent)
        {
            string[] lines = scriptContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var variables = new Dictionary<string, int>();
            int currentLine = 0;

            while (currentLine < lines.Length)
            {
                string line = lines[currentLine].Trim();

                if (IsVariableAssignment(line))
                {
                    ProcessVariableAssignment(line, variables);
                    currentLine++;
                    continue;
                }

                if (line.StartsWith("While"))
                {
                    currentLine = ExecuteWhileLoop(lines, currentLine, variables);
                    continue;
                }

                if (line.StartsWith("If"))
                {
                    currentLine = ExecuteIfStatement(lines, currentLine, variables);
                    continue;
                }

                if (line == "Endif")
                {
                    currentLine++;
                    continue;
                }

                if (IsRecognizedCommand(line))
                {
                    form.Invoke((MethodInvoker)delegate
                    {
                        CommandParser parser = new CommandParser(line);
                        canvas.drawingHandler.ExecuteDrawing(parser);
                    });
                }
                currentLine++;
            }
        }

        private bool IsVariableAssignment(string line)
        {
            return line.Contains("=");
        }

        private void ProcessVariableAssignment(string line, Dictionary<string, int> variables)
        {
            string[] parts = line.Split('=');
            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                if (int.TryParse(parts[1].Trim(), out int value))
                {
                    variables[variableName] = value;
                }
                else
                {
                    MessageBox.Show($"Invalid number format in assignment: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Invalid assignment format: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ExecuteWhileLoop(string[] lines, int startLine, Dictionary<string, int> variables)
        {
            string condition = lines[startLine].Substring(6); // Assuming "While " is 6 characters
            int endLoopLine = FindEndLoopLine(lines, startLine);

            int currentLine = startLine + 1;
            while (EvaluateCondition(condition, variables))
            {
                while (currentLine < endLoopLine)
                {
                    string loopLine = lines[currentLine].Trim();
                    if (IsRecognizedCommand(loopLine))
                    {
                        // Ensure that UI updates are done on the UI thread
                        form.Invoke((MethodInvoker)delegate
                        {
                            CommandParser parser = new CommandParser(loopLine);
                            canvas.drawingHandler.ExecuteDrawing(parser);
                        });
                    }
                    else if (IsVariableAssignment(loopLine))
                    {
                        // Process variable assignments immediately in the current thread
                        ProcessVariableAssignment(loopLine, variables);
                    }
                    currentLine++;
                }

                // Reset currentLine to start of loop for next iteration
                currentLine = startLine + 1;

                // Re-evaluate the condition with updated variables
                if (!EvaluateCondition(condition, variables))
                {
                    break;
                }
            }

            return endLoopLine + 1; // Return the line number after "Endloop"
        }


        private int FindEndLoopLine(string[] lines, int startLine)
        {
            for (int i = startLine + 1; i < lines.Length; i++)
            {
                if (lines[i].Trim() == "Endloop")
                {
                    return i;
                }
            }
            MessageBox.Show("Endloop not found for the while loop starting at line " + startLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1; // Return an invalid line number
        }

        private int ExecuteIfStatement(string[] lines, int startLine, Dictionary<string, int> variables)
        {
            string condition = lines[startLine].Substring(3).Trim(); // Assuming "If " is 3 characters
            int endIfLine = FindEndIfLine(lines, startLine);

            if (EvaluateCondition(condition, variables))
            {
                int currentLine = startLine + 1;
                while (currentLine < endIfLine)
                {
                    string ifLine = lines[currentLine].Trim();
                    if (IsRecognizedCommand(ifLine))
                    {
                        form.Invoke((MethodInvoker)delegate
                        {
                            CommandParser parser = new CommandParser(ifLine);
                            canvas.drawingHandler.ExecuteDrawing(parser);
                        });
                    }
                    currentLine++;
                }
            }

            return endIfLine + 1; // Return the line number after "Endif"
        }

        private int FindEndIfLine(string[] lines, int startLine)
        {
            for (int i = startLine + 1; i < lines.Length; i++)
            {
                if (lines[i].Trim() == "Endif")
                {
                    return i;
                }
            }
            MessageBox.Show("Endif not found for the if statement starting at line " + startLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1; // Return an invalid line number
        }

        private bool EvaluateCondition(string condition, Dictionary<string, int> variables)
        {
            // Basic implementation of condition evaluation
            // This needs to be expanded for more complex conditions
            string[] parts = condition.Split(new[] { '<', '>', '=', '!' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                if (variables.TryGetValue(variableName, out int variableValue) && int.TryParse(parts[1].Trim(), out int conditionValue))
                {
                    if (condition.Contains("<"))
                    {
                        return variableValue < conditionValue;
                    }
                    else if (condition.Contains(">"))
                    {
                        return variableValue > conditionValue;
                    }
                    else if (condition.Contains("=="))
                    {
                        return variableValue == conditionValue;
                    }
                    else if (condition.Contains("!="))
                    {
                        return variableValue != conditionValue;
                    }
                }
            }
            return false;
        }

        private bool IsRecognizedCommand(string line)
        {
            string command = line.Split(' ')[0].ToLower();
            var recognizedCommands = new HashSet<string> { "moveto", "drawto", "fill", "reset", "clear", "pen", "rectangle", "circle", "triangle" };
            return recognizedCommands.Contains(command);
        }
    }
}

