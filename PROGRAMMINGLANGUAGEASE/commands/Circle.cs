using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents a command to draw a circle on the canvas.
    /// </summary>
    public class CircleCommand : GraphicsCommand
    {
        /// <summary>
        /// Executes the circle command on the given canvas using specified graphics and arguments.
        /// </summary>
        /// <param name="graphics">The graphics object to draw the circle.</param>
        /// <param name="args">The arguments for the circle command, expecting a radius as the first argument.</param>
        /// <param name="canvas">The canvas on which to draw the circle.</param>
        public override void Execute(Graphics graphics, string[] args, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (args.Length == 1 && int.TryParse(args[0], out int radius))
            {
                // Calculate the position so that the circle is drawn from the center
                int x = currentPosition.X - radius;
                int y = currentPosition.Y - radius;

                // Check if filling is enabled and fill the circle if needed
                if (canvas.IsFilling)
                {
                    SolidBrush brush = new SolidBrush(canvas.FillColor);
                    graphics.FillEllipse(brush, x, y, 2 * radius, 2 * radius);                   
                }
                else
                {
                    graphics.DrawEllipse(drawingPen, x, y, 2 * radius, 2 * radius);
                }

                commandTextBox.Clear();
            }
            else
            {
                // Handle parsing errors here
                MessageBox.Show("Invalid arguments for 'circle' command. Please provide a valid radius.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

