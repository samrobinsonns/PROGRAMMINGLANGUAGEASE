using ProgrammingLanguageAssignment;
using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE
{

    public partial class ScriptForm : Form
    {
        private Canvas canvas; // Store the Canvas object

        public ScriptForm(Canvas canvas)
        {
            InitializeComponent();
            this.canvas = canvas;
        }

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
                        // Read the selected script file and load it into ScriptTextBox.
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
                        // Save the script content from ScriptTextBox to the selected file.
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

        private void loadScriptButton_Click(object sender, EventArgs e)
        {
            // Get the script content from the ScriptTextBox.
            string scriptContent = ScriptTextBox.Text;

            // Split the script content into individual lines.
            string[] lines = scriptContent.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                // Create an instance of the CommandParser for the current line.
                CommandParser parser = new CommandParser(line);

                // Execute the drawing command based on the parsed command.
                canvas.drawingHandler.ExecuteDrawing(parser);
            }
        }
    }
}
