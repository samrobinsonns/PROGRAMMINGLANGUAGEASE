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
        }
        public TextBox CommandTextBox
        {
            get { return commandTextBox; }
        }

        public Canvas()
        {
            InitializeComponent();
            parser = new CommandParser("");
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string commandText = commandTextBox.Text;

            // Create an instance of the CommandParser.
            CommandParser parser = new CommandParser(commandText);

            // Execute the drawing commands based on the parsed command.
            ExecuteDrawing(parser);
        }

        private void commandTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                runButton_Click(sender, e); // Call runButton_Click method when Enter key is pressed
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
                pictureBox.MouseClick -= pictureBox_MouseClick;
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (mousePointerMode && e != null)
            {
                // Update the current position
                currentPosition = e.Location;

                // Display the position in the commandTextBox
                commandTextBox.Text = $"position {currentPosition.X} {currentPosition.Y}";

                commandTextBox.Clear();
            }
        }

        private void ExecuteDrawing(CommandParser parser)
        {
            using (Graphics graphics = pictureBox.CreateGraphics())
            {
                switch (parser.Command.ToLower())
                {
                    case "moveto":
                        PositionCommand.Execute(this, parser.Args);
                        break;
                    case "drawto":
                        DrawToCommand.Execute(this, parser.Args);
                        break;
                    case "fill":
                        FillCommand.Execute(this, parser.Args, drawingPen);
                        break;
                    case "reset":
                        ResetCommand.Execute(this);
                        break;
                    case "clear":
                        ClearCommand.Execute(this);
                        break;
                    case "rectangle":
                        RectangleCommand rectangleCommand = new RectangleCommand();
                        rectangleCommand.HandleRectangleCommand(graphics, parser.Args, currentPosition, drawingPen, commandTextBox);
                        break;
                    case "circle":
                        CircleCommand circleCommand = new CircleCommand();
                        circleCommand.HandleCircleCommand(graphics, parser.Args, currentPosition, drawingPen, commandTextBox);
                        break;
                    case "triangle":
                        TriangleCommand triangleCommand = new TriangleCommand();
                        triangleCommand.HandleTriangleCommand(graphics, parser.Args, currentPosition, drawingPen, commandTextBox);
                        break;
                    case "pen":
                        drawingPen = PenCommand.HandlePenCommand(drawingPen, parser.Args);
                        break;
                    default:
                        // Handle unrecognized command here, for example:
                        MessageBox.Show("Unrecognized command: " + parser.Command, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}
