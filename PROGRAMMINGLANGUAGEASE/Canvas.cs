using ProgrammingLanguageAssignment;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using PROGRAMMINGLANGUAGEASE.Commands;

namespace PROGRAMMINGLANGUAGEASE
{
    public partial class Canvas : Form
    {
        private CommandParser parser;
        private bool mousePointerMode = false;
        private Point currentPosition = new Point(40, 40); // Store the current position
        private Pen drawingPen = new Pen(Color.Black); // Default pen color is black

        public DrawingHandler drawingHandler;

        public PictureBox DrawingPictureBox
        {
            get { return pictureBox; }
        }

        public Point CurrentPosition
        {
            get { return currentPosition; }
            set { currentPosition = value; }
        }

        public Pen DrawingPen
        {
            get { return drawingPen; }
            set { drawingPen = value; }
        }

        public TextBox CommandTextBox
        {
            get { return commandTextBox; }
        }

        public Canvas()
        {
            InitializeComponent();
            parser = new CommandParser("");
            drawingHandler = new DrawingHandler(this);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string commandText = commandTextBox.Text;
            CommandParser parser = new CommandParser(commandText);
            drawingHandler.ExecuteDrawing(parser);
        }

        private void commandTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                runButton_Click(sender, e);
            }
        }

        private void mousePointerButton_Click(object sender, EventArgs e)
        {
            mousePointerMode = !mousePointerMode;

            if (mousePointerMode)
            {
                pictureBox.Cursor = Cursors.Cross;
                pictureBox.MouseClick += pictureBox_MouseClick;
            }
            else
            {
                pictureBox.Cursor = Cursors.Default;
                pictureBox. MouseClick -= pictureBox_MouseClick;
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (mousePointerMode && e != null)
            {
                currentPosition = e.Location;
                commandTextBox.Text = $"position {currentPosition.X} {currentPosition.Y}";
                commandTextBox.Clear();
            }
        }

        private void scriptButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Pass the current Canvas instance to the ScriptForm constructor
                ScriptForm newWindow = new ScriptForm(this);

                // Display the new window.
                newWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening the new window: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
