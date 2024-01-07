using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents a command to draw a triangle on the canvas.
    /// </summary>
    public class TriangleCommand : GraphicsCommand
    {
        /// <summary>
        /// Executes the triangle command on the given canvas using specified graphics and arguments.
        /// </summary>
        /// <param name="graphics">The graphics object to draw the triangle.</param>
        /// <param name="args">The arguments for the triangle command, expecting a side length as the first argument.</param>
        /// <param name="canvas">The canvas on which to draw the triangle.</param>
        public override void Execute(Graphics graphics, string[] args, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (args.Length == 1)
            {
                if (int.TryParse(args[0], out int sideLength))
                {
                    // Calculate the vertices of the triangle
                    int x1 = currentPosition.X;
                    int y1 = currentPosition.Y;
                    int x2 = x1 + sideLength;
                    int y2 = y1;
                    int x3 = x1 + sideLength / 2;
                    int y3 = y1 - (int)(Math.Sqrt(3) * sideLength / 2);

                    Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };

                    // Check if filling is enabled and fill the triangle if needed
                    if (canvas.IsFilling)
                    {
                        using (SolidBrush brush = new SolidBrush(canvas.FillColor))
                        {
                            graphics.FillPolygon(brush, points);
                        }
                    }

                    // Draw the outline of the triangle
                    graphics.DrawPolygon(drawingPen, points);
                    // Use Invoke to update the commandTextBox on the UI thread
                    commandTextBox.Invoke((MethodInvoker)delegate
                    {
                        commandTextBox.Clear();
                    });
                }
                else
                {
                    MessageBox.Show("Invalid arguments for 'triangle' command. Please provide a valid side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Not enough arguments for 'triangle' command. Please provide a side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
