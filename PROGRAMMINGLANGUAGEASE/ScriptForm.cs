using ProgrammingLanguageAssignment;
using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE
{
    /// <summary>
    /// Represents a form for loading, saving, and executing scripts for drawing commands.
    /// </summary>
    public partial class ScriptForm : Form
    {
        private Canvas canvas; // Store the Canvas object

        /// <summary>
        /// Initializes a new instance of the ScriptForm class with a reference to a Canvas object.
        /// </summary>
        /// <param name="canvas">The canvas to draw on.</param>
        public ScriptForm(Canvas canvas)
        {
            InitializeComponent();
            this.canvas = canvas;
        }

        /// <summary>
        /// Handles the Open button click event to open and load a script file.
        /// </summary>
        private void openButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files|*.txt|All files|*.*";
                openFileDialog.Title = "Open Script File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    try
                    {
                        string scriptContent = File.ReadAllText(fileName);
                        ScriptTextBox.Text = scriptContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Save button click event to save the script content to a file.
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files|*.txt|All files|*.*";
                saveFileDialog.Title = "Save Script File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    try
                    {
                        File.WriteAllText(fileName, ScriptTextBox.Text);
                        MessageBox.Show("Script saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Load Script button click event to execute the script commands.
        /// </summary>
        private async void loadScriptButton_Click(object sender, EventArgs e)
        {
            string scriptContent = ScriptTextBox.Text;
            await Task.Run(() => ExecuteScript(scriptContent));
        }

        private void ExecuteScript(string scriptContent)
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
                    // Do nothing; Endif is handled within ExecuteIfStatement
                    currentLine++;
                    continue;
                }

                if (IsRecognizedCommand(line))
                {
                    // Execute commands on the UI thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        CommandParser parser = new CommandParser(line);
                        canvas.drawingHandler.ExecuteDrawing(parser);
                    });
                }
                currentLine++;
            }
        }

        private bool IsRecognizedCommand(string line)
        {
            string command = line.Split(' ')[0].ToLower();
            // Add all your recognized commands here
            var recognizedCommands = new HashSet<string> { "moveto", "drawto", "fill", "reset", "clear", "pen", "rectangle", "circle", "triangle" };
            return recognizedCommands.Contains(command);
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
                        CommandParser parser = new CommandParser(loopLine);
                        canvas.drawingHandler.ExecuteDrawing(parser);
                    }
                    currentLine++;
                }

                // Reset currentLine to start of loop for next iteration
                currentLine = startLine + 1;
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
            string condition = lines[startLine].Substring(2).Trim(); // Assuming "If " is 2 characters
            int endIfLine = FindEndIfLine(lines, startLine);

            if (EvaluateCondition(condition, variables))
            {
                int currentLine = startLine + 1;
                while (currentLine < endIfLine)
                {
                    string ifLine = lines[currentLine].Trim();
                    if (IsRecognizedCommand(ifLine))
                    {
                        CommandParser parser = new CommandParser(ifLine);
                        canvas.drawingHandler.ExecuteDrawing(parser);
                    }
                    else if (IsVariableAssignment(ifLine))
                    {
                        ProcessVariableAssignment(ifLine, variables);
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
            string[] parts = condition.Split(new[] { '<', '>', '=', '=' }, 2);
            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                string valuePart = parts[1].Trim();

                if (variables.TryGetValue(variableName, out int variableValue))
                {
                    if (int.TryParse(valuePart, out int conditionValue))
                    {
                        if (condition.Contains("<"))
                        {
                            return variableValue < conditionValue;
                        }
                        else if (condition.Contains(">"))
                        {
                            return variableValue > conditionValue;
                        }
                        else if (condition.Contains("="))
                        {
                            return variableValue == conditionValue;
                        }
                        else if (condition.Contains("!="))
                        {
                            return variableValue != conditionValue;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Invalid number format in condition: {valuePart}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Variable '{variableName}' is not defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Invalid condition format: {condition}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
