﻿using System;
using System.Windows.Forms;
using System.Drawing;
using PROGRAMMINGLANGUAGEASE.Commands;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents a command to draw a line from the current position to a specified destination on the canvas.
    /// </summary>
    public class DrawToCommand : BasicCommand
    {
        /// <summary>
        /// Executes the 'drawto' command on the given canvas with the specified arguments.
        /// </summary>
        /// <param name="canvas">The canvas on which to draw the line.</param>
        /// <param name="args">The arguments for the 'drawto' command, expecting x and y coordinates as the first two arguments.</param>
        public override void Execute(Canvas canvas, string[] args)
        {
            if (args.Length == 2 && int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
            {
                // Get the destination point
                Point destination = new Point(x, y);

                // Draw a line from the current position to the destination with the current pen color
                using (Graphics graphics = canvas.DrawingPictureBox.CreateGraphics())
                {
                    graphics.DrawLine(canvas.DrawingPen, canvas.CurrentPosition, destination);
                }

                // Update the current position to the destination
                canvas.CurrentPosition = destination;
                // Use Invoke to update the commandTextBox on the UI thread
                canvas.CommandTextBox.Invoke((MethodInvoker)delegate
                {
                    canvas.CommandTextBox.Clear();
                });
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'drawto' command. Please provide valid coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
