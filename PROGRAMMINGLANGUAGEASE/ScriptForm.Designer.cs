namespace PROGRAMMINGLANGUAGEASE
{
    partial class ScriptForm
    {
        private System.ComponentModel.IContainer components = null;
        private RichTextBox ScriptTextBox;
        private Button openButton;
        private Button saveButton;
        private Button loadScriptButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ScriptTextBox = new RichTextBox();
            openButton = new Button();
            saveButton = new Button();
            loadScriptButton = new Button();
            SuspendLayout();
            // 
            // ScriptTextBox
            // 
            ScriptTextBox.Location = new Point(12, 12);
            ScriptTextBox.Name = "ScriptTextBox";
            ScriptTextBox.Size = new Size(776, 396);
            ScriptTextBox.TabIndex = 0;
            ScriptTextBox.Text = "";
            // 
            // openButton
            // 
            openButton.Location = new Point(12, 414);
            openButton.Name = "openButton";
            openButton.Size = new Size(75, 23);
            openButton.TabIndex = 1;
            openButton.Text = "Open";
            openButton.UseVisualStyleBackColor = true;
            openButton.Click += openButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(93, 414);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // loadScriptButton
            // 
            loadScriptButton.Location = new Point(174, 414);
            loadScriptButton.Name = "loadScriptButton";
            loadScriptButton.Size = new Size(75, 23);
            loadScriptButton.TabIndex = 3;
            loadScriptButton.Text = "Load Script";
            loadScriptButton.UseVisualStyleBackColor = true;
            loadScriptButton.Click += loadScriptButton_Click;
            // 
            // ScriptForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(saveButton);
            Controls.Add(openButton);
            Controls.Add(loadScriptButton);
            Controls.Add(ScriptTextBox);
            Name = "ScriptForm";
            Text = "Script Editor";
            ResumeLayout(false);
        }
    }
}
