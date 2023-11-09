using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class CircleCommand : GraphicsCommand
    {
        public override void Execute(Graphics graphics, string[] args, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (args.Length >= 1)
            {
                if (int.TryParse(args[0], out int radius))
                {
                    // Calculate the position so that the circle is drawn from the center
                    int x = currentPosition.X - radius;
                    int y = currentPosition.Y - radius;

                    // Check if filling is enabled and fill the circle if needed
                    if (canvas.IsFilling)
                    {
                        using (SolidBrush brush = new SolidBrush(canvas.FillColor))
                        {
                            graphics.FillEllipse(brush, x, y, 2 * radius, 2 * radius);
                        }
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
}
