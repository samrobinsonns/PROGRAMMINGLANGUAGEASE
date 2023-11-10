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
        private void loadScriptButton_Click(object sender, EventArgs e)
        {
            string scriptContent = ScriptTextBox.Text;
            string[] lines = scriptContent.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                CommandParser parser = new CommandParser(line);
                canvas.drawingHandler.ExecuteDrawing(parser);
            }
        }
    }
}
