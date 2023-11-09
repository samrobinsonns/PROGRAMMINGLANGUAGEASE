using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class RectangleCommand : GraphicsCommand
    {
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
