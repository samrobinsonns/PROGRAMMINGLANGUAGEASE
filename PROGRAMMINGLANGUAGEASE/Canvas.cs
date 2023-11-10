using ProgrammingLanguageAssignment;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using PROGRAMMINGLANGUAGEASE.Commands;

namespace PROGRAMMINGLANGUAGEASE
{
    /// <summary>
    /// Represents the main canvas for drawing and executing commands in the application.
    /// </summary>
    public partial class Canvas : Form
    {
        private CommandParser parser;
        private bool mousePointerMode = false;
        private Point currentPosition = new Point(40, 40); // Store the current position
        private Pen drawingPen = new Pen(Color.Black); // Default pen color is black
        private bool isFilling = false;
        private Color fillColor = Color.Black; // Default fill color is black

        public DrawingHandler drawingHandler;

        /// <summary>
        /// Gets or sets a value indicating whether the canvas is in filling mode.
        /// </summary>
        public bool IsFilling
        {
            get { return isFilling; }
            set { isFilling = value; }
        }

        /// <summary>
        /// Gets or sets the fill color for shapes.
        /// </summary>
        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        /// <summary>
        /// Gets the PictureBox used for drawing.
        /// </summary>
        public PictureBox DrawingPictureBox
        {
            get { return pictureBox; }
        }

        /// <summary>
        /// Gets or sets the current position on the canvas.
        /// </summary>
        public Point CurrentPosition
        {
            get { return currentPosition; }
            set { currentPosition = value; }
        }

        /// <summary>
        /// Gets or sets the pen used for drawing.
        /// </summary>
        public Pen DrawingPen
        {
            get { return drawingPen; }
            set { drawingPen = value; }
        }

        /// <summary>
        /// Gets the TextBox for command input.
        /// </summary>
        public TextBox CommandTextBox
        {
            get { return commandTextBox; }
        }

        /// <summary>
        /// Initializes a new instance of the Canvas class.
        /// </summary>
        public Canvas()
        {
            InitializeComponent();
            parser = new CommandParser("");
            drawingHandler = new DrawingHandler(this);
        }

        /// <summary>
        /// Handles the Run button click event to execute the command entered in the command text box.
        /// </summary>
        private void runButton_Click(object sender, EventArgs e)
        {
            string commandText = commandTextBox.Text;
            CommandParser parser = new CommandParser(commandText);
            drawingHandler.ExecuteDrawing(parser);
        }

        /// <summary>
        /// Handles the KeyUp event of the command text box to execute commands on pressing Enter.
        /// </summary>
        private void commandTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                runButton_Click(sender, e);
            }
        }

        /// <summary>
        /// Toggles the mouse pointer mode between drawing and normal modes.
        /// </summary>
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
                pictureBox.MouseClick -= pictureBox_MouseClick;
            }
        }

        /// <summary>
        /// Handles mouse clicks on the PictureBox to set the current position for drawing.
        /// </summary>
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (mousePointerMode && e != null)
            {
                currentPosition = e.Location;
                commandTextBox.Text = $"position {currentPosition.X} {currentPosition.Y}";
                commandTextBox.Clear();
            }
        }

        /// <summary>
        /// Opens a new script window for loading and executing scripts.
        /// </summary>
        private void scriptButton_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptForm newWindow = new ScriptForm(this);
                newWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening the new window: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

