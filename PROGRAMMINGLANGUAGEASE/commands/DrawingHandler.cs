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

        private Dictionary<String, BasicCommand> basicCommands = new Dictionary<String, BasicCommand>
        {
            { "moveto", new PositionCommand() },
            { "drawto", new DrawToCommand() },
            { "fill", new FillCommand() },
            { "reset", new ResetCommand() },
            { "clear", new ClearCommand() },
            { "pen", new PenCommand() }
        };

        private Dictionary<String, GraphicsCommand> graphicsCommands = new Dictionary<String, GraphicsCommand>
        {
            { "rectangle", new RectangleCommand() },
            { "circle", new CircleCommand() },
            { "triangle", new TriangleCommand() },
        };


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
                    case "drawto":                      
                    case "fill":                
                    case "reset":
                    case "clear":
                    case "pen":
                        this.basicCommands[parser.Command.ToLower()].Execute(this.canvas, parser.Args);
                        break;
                    case "rectangle":
                    case "circle":
                    case "triangle":
                        this.graphicsCommands[parser.Command.ToLower()].Execute(graphics, parser.Args, this.canvas);
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
