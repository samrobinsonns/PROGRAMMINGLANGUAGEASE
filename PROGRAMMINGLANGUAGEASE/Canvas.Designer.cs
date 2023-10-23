namespace PROGRAMMINGLANGUAGEASE
{
    partial class Canvas
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBox; // Added PictureBox control
        private TextBox commandTextBox;
        private Button runButton;
        private Button mousePointerButton;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            topPanel = new Panel();
            runButton = new Button();
            commandTextBox = new TextBox();
            mousePointerButton = new Button();
            pictureBox = new PictureBox();
            scriptButton = new Button();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(224, 224, 224);
            topPanel.Controls.Add(scriptButton);
            topPanel.Controls.Add(runButton);
            topPanel.Controls.Add(commandTextBox);
            topPanel.Controls.Add(mousePointerButton);
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1444, 40);
            topPanel.TabIndex = 0;
            // 
            // runButton
            // 
            runButton.Location = new Point(320, 10);
            runButton.Name = "runButton";
            runButton.Size = new Size(75, 23);
            runButton.TabIndex = 1;
            runButton.Text = "Run";
            runButton.Click += runButton_Click;
            // 
            // commandTextBox
            // 
            commandTextBox.AcceptsReturn = true;
            commandTextBox.Location = new Point(10, 10);
            commandTextBox.Name = "commandTextBox";
            commandTextBox.Size = new Size(300, 23);
            commandTextBox.TabIndex = 0;
            commandTextBox.KeyUp += commandTextBox_KeyUp;
            // 
            // mousePointerButton
            // 
            mousePointerButton.Location = new Point(722, 10);
            mousePointerButton.Name = "mousePointerButton";
            mousePointerButton.Size = new Size(75, 23);
            mousePointerButton.TabIndex = 2;
            mousePointerButton.Text = "Mouse Pointer";
            mousePointerButton.Click += mousePointerButton_Click;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Left;
            pictureBox.Location = new Point(0, 39);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1444, 602);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // scriptButton
            // 
            scriptButton.Location = new Point(1200, 9);
            scriptButton.Name = "scriptButton";
            scriptButton.Size = new Size(75, 23);
            scriptButton.TabIndex = 3;
            scriptButton.Text = "Use Script";
            scriptButton.UseVisualStyleBackColor = true;
            scriptButton.Click += scriptButton_Click;
            // 
            // Canvas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1443, 639);
            Controls.Add(pictureBox);
            Controls.Add(topPanel);
            Name = "Canvas";
            Text = "Paint";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Button scriptButton;
    }
}
