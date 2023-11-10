using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents a command to draw a rectangle on the canvas.
    /// </summary>
    public class RectangleCommand : GraphicsCommand
    {
        /// <summary>
        /// Executes the 'rectangle' command on the given canvas with the specified arguments.
        /// </summary>
        /// <param name="graphics">The graphics object to be used for drawing the rectangle.</param>
        /// <param name="args">The arguments for the 'rectangle' command, expecting width and height as the first two arguments.</param>
        /// <param name="canvas">The canvas on which to draw the rectangle.</param>
        public override void Execute(Graphics graphics, string[] args, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (args.Length >= 2)
            {
                if (int.TryParse(args[0], out int width) && int.TryParse(args[1], out int height))
                {
                    // Rectangle should start from the current position
                    int x = currentPosition.X;
                    int y = currentPosition.Y;

                    // Check if filling is enabled and fill the rectangle if needed
                    if (canvas.IsFilling)
                    {
                        using (SolidBrush brush = new SolidBrush(canvas.FillColor))
                        {
                            // Fill the rectangle with the current fill color
                            graphics.FillRectangle(brush, x, y, width, height);
                        }
                    }

                    // Draw the outline of the rectangle regardless of filling
                    graphics.DrawRectangle(drawingPen, x, y, width, height);
                    commandTextBox.Clear();
                }
                else
                {
                    // Show an error message if the width and height are not valid integers
                    MessageBox.Show("Invalid arguments for 'rectangle' command. Please provide valid width and height.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show an error message if there are not enough arguments
                MessageBox.Show("Not enough arguments for 'rectangle' command. Please provide width and height.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
