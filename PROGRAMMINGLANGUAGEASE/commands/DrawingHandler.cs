using System;
using System.Drawing;
using System.Windows.Forms;
using PROGRAMMINGLANGUAGEASE.Commands;
using ProgrammingLanguageAssignment;

namespace PROGRAMMINGLANGUAGEASE
{
    public class DrawingHandler
    {
        private Canvas canvas;

        public DrawingHandler(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void ExecuteDrawing(CommandParser parser)
        {
            using (Graphics graphics = canvas.DrawingPictureBox.CreateGraphics())
            {
                switch (parser.Command.ToLower())
                {
                    case "moveto":
                        PositionCommand.Execute(canvas, parser.Args);
                        break;
                    case "drawto":
                        DrawToCommand.Execute(canvas, parser.Args);
                        break;
                    case "fill":
                        FillCommand.Execute(canvas, parser.Args, canvas.DrawingPen);
                        break;
                    case "reset":
                        ResetCommand.Execute(canvas);
                        break;
                    case "clear":
                        ClearCommand.Execute(canvas);
                        break;
                    case "rectangle":
                        RectangleCommand rectangleCommand = new RectangleCommand();
                        rectangleCommand.HandleRectangleCommand(graphics, parser.Args, canvas.CurrentPosition, canvas.DrawingPen, canvas.CommandTextBox);
                        break;
                    case "circle":
                        CircleCommand circleCommand = new CircleCommand();
                        circleCommand.HandleCircleCommand(graphics, parser.Args, canvas.CurrentPosition, canvas.DrawingPen, canvas.CommandTextBox);
                        break;
                    case "triangle":
                        TriangleCommand triangleCommand = new TriangleCommand();
                        triangleCommand.HandleTriangleCommand(graphics, parser.Args, canvas.CurrentPosition, canvas.DrawingPen, canvas.CommandTextBox);
                        break;
                    case "pen":
                        canvas.DrawingPen = PenCommand.HandlePenCommand(canvas.DrawingPen, parser.Args);
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
