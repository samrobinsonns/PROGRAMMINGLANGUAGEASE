﻿using System;
using System.Drawing;
using System.Windows.Forms;
using PROGRAMMINGLANGUAGEASE.Commands;
using ProgrammingLanguageAssignment;
using System.Collections.Generic;

namespace PROGRAMMINGLANGUAGEASE
{
    /// <summary>
    /// Handles the execution of drawing commands on a canvas.
    /// </summary>
    public class DrawingHandler
    {
        private readonly object graphicsLock = new object();
        private Canvas canvas;

        /// <summary>
        /// Stores basic drawing commands.
        /// </summary>
        private Dictionary<String, BasicCommand> basicCommands = new Dictionary<String, BasicCommand>
        {
            { "moveto", new PositionCommand() },
            { "drawto", new DrawToCommand() },
            { "fill", new FillCommand() },
            { "reset", new ResetCommand() },
            { "clear", new ClearCommand() },
            { "pen", new PenCommand() }
        };

        /// <summary>
        /// Stores graphics commands for shapes.
        /// </summary>
        private Dictionary<String, GraphicsCommand> graphicsCommands = new Dictionary<String, GraphicsCommand>
        {
            { "rectangle", new RectangleCommand() },
            { "circle", new CircleCommand() },
            { "triangle", new TriangleCommand() },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingHandler"/> class with a specified canvas.
        /// </summary>
        /// <param name="canvas">The canvas to draw on.</param>
        public DrawingHandler(Canvas canvas)
        {
            this.canvas = canvas;
        }

        /// <summary>
        /// Executes the drawing command parsed by the CommandParser.
        /// </summary>
        /// <param name="parser">The CommandParser containing the command to execute.</param>
        public void ExecuteDrawing(CommandParser parser)
        {
            // Check if invoke is required (if called from a non-UI thread)
            if (canvas.InvokeRequired)
            {
                // Check the execution back to the UI thread
                canvas.Invoke(new Action(() => ExecuteDrawingInternal(parser)));
            }
            else
            {
                ExecuteDrawingInternal(parser);
            }
        }

        /// <summary>
        /// Executes the drawing command internally, ensuring thread safety.
        /// </summary>
        /// <param name="parser">The CommandParser containing the command to execute.</param>
        private void ExecuteDrawingInternal(CommandParser parser)
        {
            lock (graphicsLock)
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
                            basicCommands[parser.Command.ToLower()].Execute(canvas, parser.Args);
                            break;
                        case "rectangle":
                        case "circle":
                        case "triangle":
                            graphicsCommands[parser.Command.ToLower()].Execute(graphics, parser.Args, canvas);
                            break;
                        default:
                            MessageBox.Show("Unrecognized command: " + parser.Command, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }
    }
}
