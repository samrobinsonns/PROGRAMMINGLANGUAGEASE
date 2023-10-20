using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class CircleCommand
    {
        public void HandleCircleCommand(Graphics graphics, string[] args, Point currentPosition, Pen drawingPen, TextBox commandTextBox)
        {
            if (args.Length >= 1)
            {
                if (int.TryParse(args[0], out int radius))
                {
                    // Calculate the position so that the circle is drawn from the center
                    int x = currentPosition.X - radius;
                    int y = currentPosition.Y - radius;

                    graphics.DrawEllipse(drawingPen, x, y, 2 * radius, 2 * radius);
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
}
